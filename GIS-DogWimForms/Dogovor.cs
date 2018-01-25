using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class Dogovor
    {
        Excel dogovor = new Excel();
        Excel object1 = new Excel();
        Excel vkh = new Excel();
        Excel kyandkr = new Excel();
        Excel kr = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);
        public void CreateDogovor()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT distinct import_lischt.A," +
                "import_lischt.PUBL_B," +
                "import_lischt.NUM_DOG_C," +
                "import_lischt.DAT_DOG_D," +
                "import_lischt.DAT_VST_E," +
                "''," +
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
                "import_with.A,import_with.B,import_with.C,import_with.DATA1,import_with.DATA2, " +
                "''," +
                "ipadr_new.id," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then 'МКД' else '' end pomeshen," +
                "ipadr_new.adr," +
                "ipadr_new.ipadr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                "ipadr_new.id," +
                "ipadr_new.adr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                "''," +
                "import_with.B," +
                "import_with.C," +
                "import_with.DATA1," +
                "import_with.DATA2," +
                "ipadr_new.id," +
                "ipadr_new.adr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                "''," +
                "import_with.B," +
                "import_with.C," +
                "'Соответствие показателей качества холодной воды требованиям законодательства Российской Федерации'," +
                "'', '', ''," +
                "'Соответствует', " +
                "import_with.D,import_with.E " +
                "FROM import_lischt " +
                "JOIN ipadr_new ON import_lischt.A = ipadr_new.id " +
                "JOIN import_with ON import_lischt.A = import_with.A " +
                "where import_lischt.A NOT IN " +
                "(" +
                    "SELECT id_gis.id " +
                    "FROM id_gis " +
                    "WHERE id_gis.status in ('Проект','Размещен') " +
                ")");

            myCommand.Prepare();//подготавливает строку

            MyDataReader = myCommand.ExecuteReader();

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

                if (MyDataReader.GetString(67) == "Отведение сточных вод")
                {
                    object1.AddRow(MyDataReader.GetString(37),
                    MyDataReader.GetString(67),
                    MyDataReader.GetString(68),
                    MyDataReader.GetString(40),
                    MyDataReader.GetString(41));

                    kyandkr.AddRow(MyDataReader.GetString(48),
                    MyDataReader.GetString(49),
                    MyDataReader.GetString(50),
                    MyDataReader.GetString(51),
                    "Отведение сточных вод",
                    "Сточные воды",
                    MyDataReader.GetString(54),
                    MyDataReader.GetString(55));
                    /* нет показателей качества для какаш )
                    kr.AddRow(MyDataReader.GetString(56),
                    MyDataReader.GetString(57),
                    MyDataReader.GetString(58),
                    MyDataReader.GetString(59),
                    "Отведение сточных вод",
                    "Сточные воды",
                    "",
                    MyDataReader.GetString(63),
                    MyDataReader.GetString(64),
                    MyDataReader.GetString(65),
                    MyDataReader.GetString(66));
                    */
                }

                z++;
                if (z % 1000 == 0)
                {
                    dogovor.FileSave("c:\\gis\\DOG" + y + "k.xlsx");
                    dogovor.Rows.Clear();

                    object1.FileSave("c:\\gis\\object" + y + "k.xlsx");
                    object1.Rows.Clear();

                    vkh.FileSave("c:\\gis\\vkh" + y + "k.xlsx");
                    vkh.Rows.Clear();

                    kyandkr.FileSave("c:\\gis\\KYandKR" + y + "k.xlsx");
                    kyandkr.Rows.Clear();

                    kr.FileSave("c:\\gis\\KR" + y + "k.xlsx");
                    kr.Rows.Clear();

                    y++;
                }
            }
            dogovor.FileSave("c:\\gis\\DOG-Final.xlsx");
            object1.FileSave("c:\\gis\\object-Final.xlsx");
            vkh.FileSave("c:\\gis\\vkh-Final.xlsx");
            kyandkr.FileSave("c:\\gis\\KYandKR-Final.xlsx");
            kr.FileSave("c:\\gis\\KR-Final.xlsx");

            dogovor.Rows.Clear();
            object1.Rows.Clear();
            vkh.Rows.Clear();
            kyandkr.Rows.Clear();
            kr.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }

        public void ProjectDogovor()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();

            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT distinct import_lischt.A," +
                "import_lischt.PUBL_B," +
                "import_lischt.NUM_DOG_C," +
                "import_lischt.DAT_DOG_D," +
                "import_lischt.DAT_VST_E," +
                "''," +
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
                "import_with.A,import_with.B,import_with.C,import_with.DATA1,import_with.DATA2, " +
                "''," +
                "ipadr_new.id," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then 'МКД' else '' end pomeshen," +
                "ipadr_new.adr," +
                "ipadr_new.ipadr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                "ipadr_new.id," +
                "ipadr_new.adr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                "''," +
                "import_with.B," +
                "import_with.C," +
                "import_with.DATA1," +
                "import_with.DATA2," +
                "ipadr_new.id," +
                "ipadr_new.adr," +
                "case when import_lischt.G = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen," +
                "''," +
                "import_with.B," +
                "import_with.C," +
                "'Соответствие показателей качества холодной воды требованиям законодательства Российской Федерации'," +
                "'', '', ''," +
                "'Соответствует', " +
                "import_with.D,import_with.E " +
                "FROM id_gis " +
                "JOIN ipadr_new ON id_gis.id = ipadr_new.id " +
                "JOIN import_lischt ON id_gis.id = import_lischt.A " +
                "JOIN import_with ON id_gis.id = import_with.A " +
                "where id_gis.status = 'Проект' ");

            myCommand.Prepare();

            MyDataReader = myCommand.ExecuteReader();
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

                if (MyDataReader.GetString(67) == "Отведение сточных вод")
                {
                    object1.AddRow(MyDataReader.GetString(37),
                    MyDataReader.GetString(67),
                    MyDataReader.GetString(68),
                    MyDataReader.GetString(40),
                    MyDataReader.GetString(41));

                    kyandkr.AddRow(MyDataReader.GetString(48),
                    MyDataReader.GetString(49),
                    MyDataReader.GetString(50),
                    MyDataReader.GetString(51),
                    "Отведение сточных вод",
                    "Сточные воды",
                    MyDataReader.GetString(54),
                    MyDataReader.GetString(55));

                    kr.AddRow(MyDataReader.GetString(56),
                    MyDataReader.GetString(57),
                    MyDataReader.GetString(58),
                    MyDataReader.GetString(59),
                    "Отведение сточных вод",
                    "Сточные воды",
                    "",
                    MyDataReader.GetString(63),
                    MyDataReader.GetString(64),
                    MyDataReader.GetString(65),
                    MyDataReader.GetString(66));
                }

                z++;
                if (z % 1000 == 0)
                {
                    dogovor.FileSave("c:\\gis\\DOG" + y + "k.xlsx");
                    dogovor.Rows.Clear();

                    object1.FileSave("c:\\gis\\object" + y + "k.xlsx");
                    object1.Rows.Clear();

                    vkh.FileSave("c:\\gis\\vkh" + y + "k.xlsx");
                    vkh.Rows.Clear();

                    kyandkr.FileSave("c:\\gis\\KYandKR" + y + "k.xlsx");
                    kyandkr.Rows.Clear();

                    kr.FileSave("c:\\gis\\KR" + y + "k.xlsx");
                    kr.Rows.Clear();

                    y++;
                }
            }
            dogovor.FileSave("c:\\gis\\DOG-Final.xlsx");
            object1.FileSave("c:\\gis\\object-Final.xlsx");
            vkh.FileSave("c:\\gis\\vkh-Final.xlsx");
            kyandkr.FileSave("c:\\gis\\KYandKR-Final.xlsx");
            kr.FileSave("c:\\gis\\KR-Final.xlsx");

            dogovor.Rows.Clear();
            object1.Rows.Clear();
            vkh.Rows.Clear();
            kyandkr.Rows.Clear();
            kr.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
