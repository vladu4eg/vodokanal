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
                GisExport.FileOpen(ofd.FileName, 1, textBox1.Text);
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
            Task.Factory.StartNew(() => BDExport.FileOpen(ofd.FileName, 1, textBox2.Text));
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
    }
}
