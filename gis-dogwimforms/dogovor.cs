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

            myCommand.CommandText = string.Format(@"SELECT distinct import_lischt.id, 
                'Да', 
                import_lischt.id, 
                import_lischt.data_dogovor, 
                import_lischt.data_dogovor, 
                '', '','',
                import_lischt.type_home, 
                'Физическое лицо', 
                import_lischt.famil, 
                import_lischt.imen, 
                import_lischt.otch, 
                '', 
                import_lischt.data_rojden, 
                import_lischt.SNILS, 
                import_lischt.type_doc, 
                import_lischt.num_doc, 
                import_lischt.seria_doc, 
                import_lischt.data_doc, 
                '', '', '', '',
                '9', 
                'Cледующего месяца за расчетным', 
                '10', 
                'Cледующего месяца за расчетным', 
                '', '', '',
                '20', 
                'Нет', 
                '26', 
                'Нет', 
                'Да',
                'Нормативный правовой акт', 
                'В разрезе договора', 
                'РСО', 
                'Да', 
                'В разрезе договора',
                'Нет', 
                '', 
                '', 
                import_with.id,import_with.type_uslug,import_with.type_resurs,import_with.data_start,import_with.data_end,  
                ipadr_new.id, 
                case when import_lischt.type_home = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then 'МКД' else '' end pomeshen, 
                ipadr_new.adr, 
                ipadr_new.ipadr, 
                case when import_lischt.type_home = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen, 
                ipadr_new.id, 
                ipadr_new.adr, 
                case when import_lischt.type_home = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen, 
                '', 
					 import_with.type_uslug,
					 import_with.type_resurs,
					 import_with.data_start,
					 import_with.data_end, 
                ipadr_new.id, 
                ipadr_new.adr, 
                case when import_lischt.type_home = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen, 
                '', 
                import_with.type_uslug, 
                import_with.type_resurs, 
                'Соответствие показателей качества холодной воды требованиям законодательства Российской Федерации', 
                '', '', '', 
                'Соответствует',  
                import_with.type_uslug2,import_with.type_resurs2 
                FROM import_lischt  
                JOIN ipadr_new ON import_lischt.id = ipadr_new.id  
                JOIN import_with ON import_lischt.id = import_with.id  
                where import_lischt.id NOT IN  
                ( 
                    SELECT id_gis.id  
                    FROM id_gis  
                    WHERE id_gis.status in ('Проект','Размещен')  
                )");

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
                           MyDataReader.GetString(35),
                           MyDataReader.GetString(36),
                           MyDataReader.GetString(37),
                               MyDataReader.GetString(38),
                               MyDataReader.GetString(39),
                               MyDataReader.GetString(40),
                               MyDataReader.GetString(41),
                               MyDataReader.GetString(42),
                               MyDataReader.GetString(43));

                object1.AddRow(MyDataReader.GetString(44),
                               MyDataReader.GetString(45),
                               MyDataReader.GetString(46),
                               MyDataReader.GetString(47),
                               MyDataReader.GetString(48));

                vkh.AddRow(MyDataReader.GetString(49),
                MyDataReader.GetString(50),
                MyDataReader.GetString(51),
                MyDataReader.GetString(52),
                MyDataReader.GetString(53));

                kyandkr.AddRow(MyDataReader.GetString(54),
                MyDataReader.GetString(55),
                MyDataReader.GetString(56),
                MyDataReader.GetString(57),
                MyDataReader.GetString(58),
                MyDataReader.GetString(59),
                MyDataReader.GetString(60),
                MyDataReader.GetString(61));

                kr.AddRow(MyDataReader.GetString(62),
                MyDataReader.GetString(63),
                MyDataReader.GetString(64),
                MyDataReader.GetString(64),
                MyDataReader.GetString(65),
                MyDataReader.GetString(66),
                MyDataReader.GetString(67),
                MyDataReader.GetString(68),
                MyDataReader.GetString(69),
                MyDataReader.GetString(70),
                MyDataReader.GetString(71));

                if (MyDataReader.GetString(73) == "Отведение сточных вод")
                {

                    object1.AddRow(MyDataReader.GetString(44),
               MyDataReader.GetString(73),
               MyDataReader.GetString(46),
               MyDataReader.GetString(47),
               MyDataReader.GetString(48));

                    kyandkr.AddRow(MyDataReader.GetString(54),
                    MyDataReader.GetString(55),
                    MyDataReader.GetString(56),
                    MyDataReader.GetString(57),
                    "Отведение сточных вод",
                    "Сточные воды",
                    MyDataReader.GetString(60),
                    MyDataReader.GetString(61));
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

            myCommand.CommandText = string.Format(@"SELECT distinct import_lischt.id, 
                'Да',
                import_lischt.id,
                import_lischt.data_dogovor,
                import_lischt.data_dogovor,
                '', '', '',
                import_lischt.type_home,
                'Физическое лицо',
                import_lischt.famil,
                import_lischt.imen,
                import_lischt.otch,
                '',
                import_lischt.data_rojden,
                import_lischt.SNILS,
                import_lischt.type_doc,
                import_lischt.num_doc,
                import_lischt.seria_doc,
                import_lischt.data_doc,
                '', '', '', '',
                '9',
                'Cледующего месяца за расчетным',
                '10',
                'Cледующего месяца за расчетным',
                '', '', '',
                '20',
                'Нет',
                '26',
                'Нет',
                'Да',
                'Нормативный правовой акт',
                'В разрезе договора',
                'РСО',
                'Да',
                'В разрезе договора',
                'Нет',
                '',
                '',
                import_with.id, import_with.type_uslug, import_with.type_resurs, import_with.data_start, import_with.data_end,
                ipadr_new.id,
                case when import_lischt.type_home = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then 'МКД' else '' end pomeshen,
                ipadr_new.adr,
                ipadr_new.ipadr,
                case when import_lischt.type_home = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen,
                ipadr_new.id,
                ipadr_new.adr,
                case when import_lischt.type_home = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen,
                '',
                     import_with.type_uslug,
                     import_with.type_resurs,
                     import_with.data_start,
                     import_with.data_end,
                ipadr_new.id,
                ipadr_new.adr,
                case when import_lischt.type_home = 'Собственник или пользователь жилого (нежилого) помещения в МКД' then ipadr_new.pomesh else '' end pomeshen,
                '',
                import_with.type_uslug,
                import_with.type_resurs,
                'Соответствие показателей качества холодной воды требованиям законодательства Российской Федерации',
                '', '', '',
                'Соответствует',
                import_with.type_uslug2, import_with.type_resurs2 
                FROM id_gis 
                JOIN ipadr_new ON id_gis.id = ipadr_new.id 
                JOIN import_lischt ON id_gis.id = import_lischt.id 
                JOIN import_with ON id_gis.id = import_with.id 
                where id_gis.status = 'Проект' ");

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
                           MyDataReader.GetString(35),
                           MyDataReader.GetString(36),
                           MyDataReader.GetString(37),
                               MyDataReader.GetString(38),
                               MyDataReader.GetString(39),
                               MyDataReader.GetString(40),
                               MyDataReader.GetString(41),
                               MyDataReader.GetString(42),
                               MyDataReader.GetString(43));

                object1.AddRow(MyDataReader.GetString(44),
                               MyDataReader.GetString(45),
                               MyDataReader.GetString(46),
                               MyDataReader.GetString(47),
                               MyDataReader.GetString(48));

                vkh.AddRow(MyDataReader.GetString(49),
                MyDataReader.GetString(50),
                MyDataReader.GetString(51),
                MyDataReader.GetString(52),
                MyDataReader.GetString(53));

                kyandkr.AddRow(MyDataReader.GetString(54),
                MyDataReader.GetString(55),
                MyDataReader.GetString(56),
                MyDataReader.GetString(57),
                MyDataReader.GetString(58),
                MyDataReader.GetString(59),
                MyDataReader.GetString(60),
                MyDataReader.GetString(61));

                kr.AddRow(MyDataReader.GetString(62),
                MyDataReader.GetString(63),
                MyDataReader.GetString(64),
                MyDataReader.GetString(64),
                MyDataReader.GetString(65),
                MyDataReader.GetString(66),
                MyDataReader.GetString(67),
                MyDataReader.GetString(68),
                MyDataReader.GetString(69),
                MyDataReader.GetString(70),
                MyDataReader.GetString(71));

                if (MyDataReader.GetString(73) == "Отведение сточных вод")
                {

                    object1.AddRow(MyDataReader.GetString(44),
               MyDataReader.GetString(73),
               MyDataReader.GetString(46),
               MyDataReader.GetString(47),
               MyDataReader.GetString(48));

                    kyandkr.AddRow(MyDataReader.GetString(54),
                    MyDataReader.GetString(55),
                    MyDataReader.GetString(56),
                    MyDataReader.GetString(57),
                    "Отведение сточных вод",
                    "Сточные воды",
                    MyDataReader.GetString(60),
                    MyDataReader.GetString(61));
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
