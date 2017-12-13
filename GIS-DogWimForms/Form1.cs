using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Threading;
using System.Globalization;
using BotAgent.DataExporter;
using MySql.Data.MySqlClient;

namespace GIS_DogWimForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
        }

        public static Excel GisExport = new Excel();
        public static Excel BDExport = new Excel();
        public Excel TempExcel = new Excel();


        private void button1_Click(object sender, EventArgs e)
        {
            GisExport.Rows.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "Выберите документ для загрузки данных";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Загрузка данных...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //Task.Factory.StartNew(() => GisExport.FileOpen(ofd.FileName, 1, textBox2.Text));

            }
            catch { }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BDExport.Rows.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "Выберите документ для загрузки данных";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Загрузка данных...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //BDExport.FileOpen(ofd.FileName, 1);
            //TempExcel.Rows = BDExport.Rows;
            //MessageBox.Show("Готово! БД");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            List<string> ListGis = new List<string>();
            List<string> ListBD = new List<string>();
            listBox2.Items.Clear();
            int count = 0;

            if (String.IsNullOrEmpty(textBox1.Text))
                MessageBox.Show("Введите номер столбца в ГИС!");
            else if (String.IsNullOrEmpty(textBox2.Text))
                MessageBox.Show("Введите номер столбца в BD!");
            else if (BDExport.Rows.Count <= 0)
                MessageBox.Show("Загрузите экспорт БД");
            else if (GisExport.Rows.Count <= 0)
                MessageBox.Show("Загрузите экспорт ГИС");
            else if (GisExport.Rows[1].Count <= Convert.ToInt32(textBox1.Text) - 1)
                MessageBox.Show("Нет такого столбца в экспорте ГИСа");
            else if (BDExport.Rows[1].Count <= Convert.ToInt32(textBox2.Text) - 1)
                MessageBox.Show("Нет такого столбца в экспорте БД");
            else if (Convert.ToInt32(textBox1.Text) <= 0 | Convert.ToInt32(textBox2.Text) <= 0)
                MessageBox.Show("Число должно быть больше нуля");
            else
            {
                for (int i = 0; i < GisExport.Rows.Count; i++)
                    ListGis.Add(GisExport.Rows[i][Convert.ToInt32(textBox1.Text) - 1]);
                for (int i = 0; i < BDExport.Rows.Count; i++)
                    ListBD.Add(BDExport.Rows[i][Convert.ToInt32(textBox2.Text) - 1]);
                foreach (string s in ListBD.Except(ListGis))
                {
                    count++;
                    listBox2.Items.Add(s);
                    label3.Text = count.ToString();
                }
                ListBD.Clear();
                ListGis.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            int count2 = 0;

            if (String.IsNullOrEmpty(textBox1.Text))
                MessageBox.Show("Введите номер столбца в ГИС!");
            else if (GisExport.Rows.Count <= 0)
                MessageBox.Show("Загрузите экспорт ГИС");
            //   else if (GisExport.Rows[1].Count <= Convert.ToInt32(textBox1.Text) - 1)
            //      MessageBox.Show("Нет такого столбца");
            else if (Convert.ToInt32(textBox1.Text) <= 0)
                MessageBox.Show("Число должно быть больше нуля");
            else
            {
                string[] templist = new string[GisExport.Rows.Count];
                for (int i = 0; i < GisExport.Rows.Count; i++)
                    if (!string.IsNullOrEmpty(GisExport.Rows[i][0]))
                        templist[i] = GisExport.Rows[i][0];

                foreach (string val in templist.Distinct())
                {
                    var count = templist.Where(x => x == val).Count();
                    if (count > 1)
                    {
                        listBox1.Items.Add(val + " - " + templist.Count(x => x == val) + " раз");
                        count2++;
                    }
                }
                label4.Text = count2.ToString();
                templist = null;
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            TableWork wrk = new TableWork(); ;
            wrk.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Csv LS = new Csv();
            Csv adress = new Csv();
            Csv dogovor = new Csv();

            string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";
            MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("select LS.l_schet, " +
                "LS.l_schet, " +
                "LS.ident, " +
                "LS.lsrso, " +
                "LS.Yav, " +
                "LS.Pomesh, " +
                "LS.Famil, " +
                "LS.Imen, " +
                "LS.Otch, " +
                "LS.IDENT_NO, " +
                "LS.O, " +
                "LS.DOC_NO, " +
                "LS.DOC_SE, " +
                "LS.DOC_DATE," +
                "'', '', '', '', '', ''," +
                "LS.KOL_GIL," +
                "LS.l_schet," +
                "''," +
                "ipadr_new.ipadr," +
                "'Жилое помещение'," +
                "ipadr_new.pomesh," +
                "LS.l_schet," +
                "'Договор ресурсоснабжения (ЛС РСО или ЛС РЦ)'," +
                "id_gis.id_gis " +
                "from LS, id_gis, ipadr_new " +
                "where LS.l_schet = ipadr_new.id " +
                "and LS.l_schet = id_gis.id " +
               // "and id_gis.status = 'Проект' " +
                "group by LS.l_schet " +
                "order by LS.l_schet; ");
            myCommand.Prepare();//подготавливает строку

            MySqlDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            int i = 0;
            int y = 1;
            int z = 1;
            while (MyDataReader.Read())
            {
                LS.AddRow(MyDataReader.GetString(0),
                           MyDataReader.GetString(1),
                           MyDataReader.GetString(2),
                           MyDataReader.GetString(3),
                           MyDataReader.GetString(4),
                           MyDataReader.GetString(5),
                           MyDataReader.GetString(6),
                           MyDataReader.GetString(7),
                           MyDataReader.GetString(8),
                           MyDataReader.GetString(9),
                           MyDataReader.GetString(10),
                           MyDataReader.GetString(11),
                           MyDataReader.GetString(12),
                           MyDataReader.GetString(13),
                           MyDataReader.GetString(14),
                           MyDataReader.GetString(15),
                           MyDataReader.GetString(16),
                           MyDataReader.GetString(17),
                           MyDataReader.GetString(18),
                           MyDataReader.GetString(19),
                           MyDataReader.GetString(20));

                adress.AddRow(MyDataReader.GetString(21),
                               MyDataReader.GetString(22),
                               MyDataReader.GetString(23),
                               MyDataReader.GetString(24),
                               MyDataReader.GetString(25));

                dogovor.AddRow(MyDataReader.GetString(26),
                                MyDataReader.GetString(27),
                                MyDataReader.GetString(28));

                i += 29;
                z++;
                if (z % 1000 == 0)
                {

                    LS.FileSave("c:\\gis\\LS" + y + "k.csv");
                    LS.Rows.Clear();

                    adress.FileSave("c:\\gis\\adress" + y + "k.csv");
                    adress.Rows.Clear();

                    dogovor.FileSave("c:\\gis\\DOGLS" + y + "k.csv");
                    dogovor.Rows.Clear();

                    y++;
                }
            }
            dogovor.FileSave("c:\\gis\\DOGLS-Final.csv");
            adress.FileSave("c:\\gis\\adress-Final.csv");
            LS.FileSave("c:\\gis\\LS-Final.csv");


            dogovor.Rows.Clear();
            LS.Rows.Clear();
            adress.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Csv dogovor = new Csv();
            Csv object1 = new Csv();
            Csv vkh = new Csv();
            Csv kyandkr = new Csv();
            Csv kr = new Csv();

            string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";
            MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT distinct import_lischt.A," +
                "import_lischt.PUBL_B," +
                "import_lischt.NUM_DOG_C," +
                "import_lischt.DAT_DOG_D," +
                "import_lischt.DAT_VST_E," +
                "import_lischt.F," +
                "import_lischt.G," +
                "import_lischt.H," +
                "import_lischt.FAMIL_NAME_R," +
                "import_lischt.IMEN_NAME_R," +
                "import_lischt.OTCH_NAME_R," +
                "import_lischt.POL_L," +
                "import_lischt.M," +
                "import_lischt.SNILS," +
                "import_lischt.O," +
                "import_lischt.Q," +
                "import_lischt.P," +
                "import_lischt.R," +
                "'', '', ''," +
                "import_lischt.SROK1," +
                "import_lischt.`СЛЕДУЮЩЕГОМЕСЯЦАЗАРАСЧЕТНЫМ`," +
                "import_lischt.SROR2," +
                "import_lischt.`СЛЕДУЮЩЕГОМЕСЯЦАЗАРАСЧЕТНЫМ2`," +
                "'', ''," +
                "import_lischt.DAT_NACH," +
                "import_lischt.`НЕТ`," +
                "import_lischt.DAT_OK," +
                "import_lischt.`НЕТ2`," +
                "'Нормативный правовой акт'," +
                "'РСО'," +
                "'В разрезе договора'," +
                "'Нет'," +
                "id_gis.id_gis," +
                "''," +
                //with
                "import_with.*," +
                "''," +
                //адрес
                "ipadr_new.id," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then 'МКД' else '' end pomeshen," +
                "ipadr_new.adr," +
                "ipadr_new.ipadr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                //
                "ipadr_new.id," +
                "ipadr_new.adr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                "''," +
                "import_with.B," +
                "import_with.C," +
                "import_with.DATA1," +
                "import_with.DATA2," +
                //
                "ipadr_new.id," +
                "ipadr_new.adr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                "''," +
                "import_with.B," +
                "import_with.C," +
                "'Соответствие показателей качества холодной воды требованиям законодательства Российской Федерации'," +
                "'', '', ''," +
                "'Соответствует' " +
                //
                "FROM id_gis " +
                "JOIN ipadr_new ON id_gis.id = ipadr_new.id " +
                "JOIN import_lischt ON id_gis.id = import_lischt.A " +
                "JOIN import_with ON id_gis.id = import_with.A " +

                "where id_gis.status = 'Проект'");

            myCommand.Prepare();//подготавливает строку

            MySqlDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            int i = 0;
            int y = 1;
            int z = 1;
            while (MyDataReader.Read())
            {
                dogovor.AddRow(MyDataReader.GetString(0),
                           MyDataReader.GetString(1),
                           MyDataReader.GetString(2),
                           MyDataReader.GetString(3),
                           MyDataReader.GetString(4),
                           MyDataReader.GetString(5),
                           MyDataReader.GetString(6),
                           MyDataReader.GetString(7),
                           MyDataReader.GetString(8),
                           MyDataReader.GetString(9),
                           MyDataReader.GetString(10),
                           MyDataReader.GetString(11),
                           MyDataReader.GetString(12),
                           MyDataReader.GetString(13),
                           MyDataReader.GetString(14),
                           MyDataReader.GetString(15),
                           MyDataReader.GetString(16),
                           MyDataReader.GetString(17),
                           MyDataReader.GetString(18),
                           MyDataReader.GetString(19),
                           MyDataReader.GetString(20),
                           MyDataReader.GetString(21),
                           MyDataReader.GetString(22),
                           MyDataReader.GetString(23),
                           MyDataReader.GetString(24),
                           MyDataReader.GetString(25),
                           MyDataReader.GetString(26),
                           MyDataReader.GetString(27),
                           MyDataReader.GetString(28),
                           MyDataReader.GetString(29),
                           MyDataReader.GetString(30),
                           MyDataReader.GetString(31),
                           MyDataReader.GetString(32),
                           MyDataReader.GetString(33),
                           MyDataReader.GetString(34),
                           MyDataReader.GetString(35));

                object1.AddRow(MyDataReader.GetString(37),
                               MyDataReader.GetString(38),
                               MyDataReader.GetString(39),
                               MyDataReader.GetString(40),
                               MyDataReader.GetString(41));

                vkh.AddRow(MyDataReader.GetString(43),
                MyDataReader.GetString(44),
                MyDataReader.GetString(45),
                MyDataReader.GetString(46),
                MyDataReader.GetString(47));

                kyandkr.AddRow(MyDataReader.GetString(48),
                MyDataReader.GetString(49),
                MyDataReader.GetString(50),
                MyDataReader.GetString(51),
                MyDataReader.GetString(52),
                MyDataReader.GetString(53),
                MyDataReader.GetString(54),
                MyDataReader.GetString(55));

                kr.AddRow(MyDataReader.GetString(56),
                MyDataReader.GetString(57),
                MyDataReader.GetString(58),
                MyDataReader.GetString(59),
                MyDataReader.GetString(60),
                MyDataReader.GetString(61),
                MyDataReader.GetString(62),
                MyDataReader.GetString(63),
                MyDataReader.GetString(64),
                MyDataReader.GetString(65),
                MyDataReader.GetString(66));

                i += 67;
                z++;
                if (z % 1000 == 0)
                {
                    dogovor.FileSave("c:\\gis\\DOG" + y + "k.csv");
                    dogovor.Rows.Clear();

                    object1.FileSave("c:\\gis\\object" + y + "k.csv");
                    object1.Rows.Clear();

                    vkh.FileSave("c:\\gis\\vkh" + y + "k.csv");
                    vkh.Rows.Clear();

                    kyandkr.FileSave("c:\\gis\\KYandKR" + y + "k.csv");
                    kyandkr.Rows.Clear();

                    kr.FileSave("c:\\gis\\KR" + y + "k.csv");
                    kr.Rows.Clear();

                    y++;
                }
            }
            dogovor.FileSave("c:\\gis\\DOG-Final.csv");
            object1.FileSave("c:\\gis\\object-Final.csv");
            vkh.FileSave("c:\\gis\\vkh-Final.csv");
            kyandkr.FileSave("c:\\gis\\KYandKR-Final.csv");
            kr.FileSave("c:\\gis\\KR-Final.csv");

            dogovor.Rows.Clear();
            object1.Rows.Clear();
            vkh.Rows.Clear();
            kyandkr.Rows.Clear();
            kr.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Csv dogovor = new Csv();
            Csv object1 = new Csv();
            Csv vkh = new Csv();
            Csv kyandkr = new Csv();
            Csv kr = new Csv();

            string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";
            MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT distinct import_lischt.A," +
                "import_lischt.PUBL_B," +
                "import_lischt.NUM_DOG_C," +
                "import_lischt.DAT_DOG_D," +
                "import_lischt.DAT_VST_E," +
                "import_lischt.F," +
                "import_lischt.G," +
                "import_lischt.H," +
                "import_lischt.FAMIL_NAME_R," +
                "import_lischt.IMEN_NAME_R," +
                "import_lischt.OTCH_NAME_R," +
                "import_lischt.POL_L," +
                "import_lischt.M," +
                "import_lischt.SNILS," +
                "import_lischt.O," +
                "import_lischt.Q," +
                "import_lischt.P," +
                "import_lischt.R," +
                "'', '', ''," +
                "import_lischt.SROK1," +
                "import_lischt.`СЛЕДУЮЩЕГОМЕСЯЦАЗАРАСЧЕТНЫМ`," +
                "import_lischt.SROR2," +
                "import_lischt.`СЛЕДУЮЩЕГОМЕСЯЦАЗАРАСЧЕТНЫМ2`," +
                "'', ''," +
                "import_lischt.DAT_NACH," +
                "import_lischt.`НЕТ`," +
                "import_lischt.DAT_OK," +
                "import_lischt.`НЕТ2`," +
                "'Нормативный правовой акт'," +
                "'РСО'," +
                "'В разрезе договора'," +
                "'Нет'," +
                "''," +
                "''," +
                //with
                "import_with.*," +
                "''," +
                //адрес
                "ipadr_new.id," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then 'МКД' else '' end pomeshen," +
                "ipadr_new.adr," +
                "ipadr_new.ipadr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                //
                "ipadr_new.id," +
                "ipadr_new.adr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                "''," +
                "import_with.B," +
                "import_with.C," +
                "import_with.DATA1," +
                "import_with.DATA2," +
                //
                "ipadr_new.id," +
                "ipadr_new.adr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                "''," +
                "import_with.B," +
                "import_with.C," +
                "'Соответствие показателей качества холодной воды требованиям законодательства Российской Федерации'," +
                "'', '', ''," +
                "'Соответствует' " +
                //
                "FROM import_lischt " +
                "JOIN ipadr_new ON import_lischt.A = ipadr_new.id " +
                "JOIN import_with ON import_lischt.A = import_with.A " +
                // "where (id_gis.status = 'Размещен' or id_gis.status = 'Проект') " +
                //поиск проектов. НЕ ЗАБУДЬ УДАЛИТЬ!!!!!!
                "where import_lischt.A NOT IN " +
                "(" +
                    "SELECT distinct import_lischt.A " +
                    "FROM import_lischt, id_gis " +
                    "WHERE import_lischt.A = id_gis.id " +
                    "AND id_gis.status in ('Проект','Размещен') " +
                ")");
            myCommand.Prepare();//подготавливает строку

            MySqlDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            int i = 0;
            int y = 1;
            int z = 1;
            while (MyDataReader.Read())
            {
                dogovor.AddRow(MyDataReader.GetString(0),
                           MyDataReader.GetString(1),
                           MyDataReader.GetString(2),
                           MyDataReader.GetString(3),
                           MyDataReader.GetString(4),
                           MyDataReader.GetString(5),
                           MyDataReader.GetString(6),
                           MyDataReader.GetString(7),
                           MyDataReader.GetString(8),
                           MyDataReader.GetString(9),
                           MyDataReader.GetString(10),
                           MyDataReader.GetString(11),
                           MyDataReader.GetString(12),
                           MyDataReader.GetString(13),
                           MyDataReader.GetString(14),
                           MyDataReader.GetString(15),
                           MyDataReader.GetString(16),
                           MyDataReader.GetString(17),
                           MyDataReader.GetString(18),
                           MyDataReader.GetString(19),
                           MyDataReader.GetString(20),
                           MyDataReader.GetString(21),
                           MyDataReader.GetString(22),
                           MyDataReader.GetString(23),
                           MyDataReader.GetString(24),
                           MyDataReader.GetString(25),
                           MyDataReader.GetString(26),
                           MyDataReader.GetString(27),
                           MyDataReader.GetString(28),
                           MyDataReader.GetString(29),
                           MyDataReader.GetString(30),
                           MyDataReader.GetString(31),
                           MyDataReader.GetString(32),
                           MyDataReader.GetString(33),
                           MyDataReader.GetString(34),
                           MyDataReader.GetString(35));

                object1.AddRow(MyDataReader.GetString(37),
                               MyDataReader.GetString(38),
                               MyDataReader.GetString(39),
                               MyDataReader.GetString(40),
                               MyDataReader.GetString(41));

                vkh.AddRow(MyDataReader.GetString(43),
                MyDataReader.GetString(44),
                MyDataReader.GetString(45),
                MyDataReader.GetString(46),
                MyDataReader.GetString(47));

                kyandkr.AddRow(MyDataReader.GetString(48),
                MyDataReader.GetString(49),
                MyDataReader.GetString(50),
                MyDataReader.GetString(51),
                MyDataReader.GetString(52),
                MyDataReader.GetString(53),
                MyDataReader.GetString(54),
                MyDataReader.GetString(55));

                kr.AddRow(MyDataReader.GetString(56),
                MyDataReader.GetString(57),
                MyDataReader.GetString(58),
                MyDataReader.GetString(59),
                MyDataReader.GetString(60),
                MyDataReader.GetString(61),
                MyDataReader.GetString(62),
                MyDataReader.GetString(63),
                MyDataReader.GetString(64),
                MyDataReader.GetString(65),
                MyDataReader.GetString(66));

                i += 67;
                z++;
                if (z % 1000 == 0)
                {
                    dogovor.FileSave("c:\\gis\\DOG" + y + "k.csv");
                    dogovor.Rows.Clear();

                    object1.FileSave("c:\\gis\\object" + y + "k.csv");
                    object1.Rows.Clear();

                    vkh.FileSave("c:\\gis\\vkh" + y + "k.csv");
                    vkh.Rows.Clear();

                    kyandkr.FileSave("c:\\gis\\KYandKR" + y + "k.csv");
                    kyandkr.Rows.Clear();

                    kr.FileSave("c:\\gis\\KR" + y + "k.csv");
                    kr.Rows.Clear();

                    y++;
                }
            }
            dogovor.FileSave("c:\\gis\\DOG-Final.csv");
            object1.FileSave("c:\\gis\\object-Final.csv");
            vkh.FileSave("c:\\gis\\vkh-Final.csv");
            kyandkr.FileSave("c:\\gis\\KYandKR-Final.csv");
            kr.FileSave("c:\\gis\\KR-Final.csv");

            dogovor.Rows.Clear();
            object1.Rows.Clear();
            vkh.Rows.Clear();
            kyandkr.Rows.Clear();
            kr.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Csv LS = new Csv();
            Csv adress = new Csv();
            Csv dogovor = new Csv();

            string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=vlad19957";
            MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("select distinct LS.l_schet, " +
                "LS.l_schet, " +
                "LS.ident, " +
                "LS.lsrso, " +
                "LS.Yav, " +
                "LS.Pomesh, " +
                "LS.Famil, " +
                "LS.Imen, " +
                "LS.Otch, " +
                "LS.IDENT_NO, " +
                "LS.O, " +
                "LS.DOC_NO, " +
                "LS.DOC_SE, " +
                "LS.DOC_DATE," +
                "'', '', '', '', '', ''," +
                "LS.KOL_GIL," +
                "LS.l_schet," +
                "''," +
                "ipadr_new.ipadr," +
                "case when object_adress.id_kvt != '' " +
                "then 'Жилое помещение' " +
                "else '' " +
                "end JIL, " +
                "case when object_adress.id_kvt != '' " +
                "then ipadr_new.pomesh " +
                "else '' " +
                "end pomesh, " +
                "LS.l_schet," +
                "'Договор ресурсоснабжения (ЛС РСО или ЛС РЦ)'," +
                "id_gis.id_gis " +
                "from LS, ipadr_new, object_adress,id_gis " +
                "where LS.l_schet NOT IN " +
                "(" +
                "SELECT distinct LS.l_schet " +
                "FROM LS, id_ls " +
                "WHERE LS.l_schet = id_ls.id " +
                ") " +
                "and LS.l_schet = ipadr_new.id " +
                "and LS.l_schet = id_gis.id " +
                "and ipadr_new.ipadr = object_adress.HOUSEGUID_fias " +
                "and ipadr_new.pomesh = object_adress.kv " +
                "and id_gis.`status` = 'Размещен' " +
                "order by LS.l_schet; ");
            myCommand.Prepare();//подготавливает строку

            MySqlDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            int i = 0;
            int y = 1;
            int z = 1;
            while (MyDataReader.Read())
            {
                LS.AddRow(MyDataReader.GetString(0),
                           MyDataReader.GetString(1),
                           MyDataReader.GetString(2),
                           MyDataReader.GetString(3),
                           MyDataReader.GetString(4),
                           MyDataReader.GetString(5),
                           MyDataReader.GetString(6),
                           MyDataReader.GetString(7),
                           MyDataReader.GetString(8),
                           MyDataReader.GetString(9),
                           MyDataReader.GetString(10),
                           MyDataReader.GetString(11),
                           MyDataReader.GetString(12),
                           MyDataReader.GetString(13),
                           MyDataReader.GetString(14),
                           MyDataReader.GetString(15),
                           MyDataReader.GetString(16),
                           MyDataReader.GetString(17),
                           MyDataReader.GetString(18),
                           MyDataReader.GetString(19),
                           MyDataReader.GetString(20));

                adress.AddRow(MyDataReader.GetString(21),
                               MyDataReader.GetString(22),
                               MyDataReader.GetString(23),
                               MyDataReader.GetString(24),
                               MyDataReader.GetString(25));

                dogovor.AddRow(MyDataReader.GetString(26),
                                MyDataReader.GetString(27),
                                MyDataReader.GetString(28));

                i += 29;
                z++;
                if (z %1000 == 0)
                {

                    LS.FileSave("c:\\gis\\LS" + y + "k.csv");
                    LS.Rows.Clear();

                    adress.FileSave("c:\\gis\\adress" + y + "k.csv");
                    adress.Rows.Clear();

                    dogovor.FileSave("c:\\gis\\DOGLS" + y + "k.csv");
                    dogovor.Rows.Clear();

                    y++;
                }
            }
            dogovor.FileSave("c:\\gis\\DOGLS-Final.csv");
            adress.FileSave("c:\\gis\\adress-Final.csv");
            LS.FileSave("c:\\gis\\LS-Final.csv");


            dogovor.Rows.Clear();
            LS.Rows.Clear();
            adress.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Csv mkd = new Csv();
            Csv jill = new Csv();

            string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";
            MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT DISTINCT ipadr_new.adr, " +
                "ipadr_new.ipadr," +
                "'35729000001'," +
                "'Симферополь'," +
                "ipadr_new.adr," +
                "ipadr_new.pomesh " +
                "FROM ipadr_new, object " +
                "WHERE ipadr_new.id = object.id " +
                "AND object.statushome = 'жилое' " +
                "AND object.typehome = 'МКД' " +
                "AND ipadr_new.pomesh <> '' " +
                "AND ipadr_new.pomesh REGEXP '^[0-9]+$' " +
                "AND ipadr_new.pomesh <> '0' " +
                "AND ipadr_new.id NOT IN " +
                "(" +
                "SELECT id_ls.id " +
                "FROM id_ls " +
                ")" +
                "ORDER BY ipadr_new.pomesh;");
            myCommand.Prepare();//подготавливает строку

            MySqlDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            int i = 0;
            int y = 1;
            int z = 1;
            while (MyDataReader.Read())
            {
                mkd.AddRow(MyDataReader.GetString(0),
                           MyDataReader.GetString(1),
                           MyDataReader.GetString(2),
                           MyDataReader.GetString(3));

                jill.AddRow(MyDataReader.GetString(4),
                               MyDataReader.GetString(5));


                i += 29;
                z++;
                if (z % 1000 == 0)
                {

                    mkd.FileSave("c:\\gis\\mkd" + y + "k.csv");
                    mkd.Rows.Clear();

                    jill.FileSave("c:\\gis\\jill" + y + "k.csv");
                    jill.Rows.Clear();

                    y++;
                }
            }
            mkd.FileSave("c:\\gis\\MKD-Final.csv");
            jill.FileSave("c:\\gis\\MKD-Final.csv");


            mkd.Rows.Clear();
            jill.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
