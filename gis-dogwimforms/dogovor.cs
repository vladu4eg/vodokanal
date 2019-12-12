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
        public void CreateDogovor(string path)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(@"SELECT distinct mb_ls.ls, 
                'Да', 
                mb_ls.ls, 
                case when mb_dogovor.dog_data <> '' 
				then
				date_format(STR_TO_DATE(mb_dogovor.dog_data,   '%d/%m/%Y'),'%d.%m.%Y') 
			    else '' end,
                case when mb_dogovor.dog_data <> '' 
				then
				date_format(STR_TO_DATE(mb_dogovor.dog_data,   '%d/%m/%Y'),'%d.%m.%Y') 
				else '' end,
                'Нет', 'Да','31.12.2999',
                case when mb_dogovor.type_home = 'общежитие' or mb_dogovor.type_home = 'многоквартирный дом' 
                then 'Собственник или пользователь жилого (нежилого) помещения в МКД'
                else 'Собственник или пользователь жилого дома (домовладения)' end type_home_ls,
                'Физическое лицо', 
                '', '', '', '', '', '', '', '', '',  '', '', '', '', '',
                '9', 
                'следующего месяца за расчетным', 
                '10', 
                'следующего месяца за расчетным', 
                '', '', '',
                '20', 
                'Нет', 
                '25', 
                'Нет', 
                'Да',
                'Нормативный правовой акт', 
                '', 
                '', 
                'Да', 
                'В разрезе договора',
                'Нет', 
                '', 
                '', 
                mb_uslugi.id,
					 case when mb_uslugi.type_uslug <> ''
					 then mb_uslugi.type_uslug 
					 else 'Холодное водоснабжение' end, 
					 case when mb_uslugi.type_resurs <> ''
					 then mb_uslugi.type_resurs
					 else 'Питьевая вода' end, 
                case when mb_dogovor.dog_data <> '' 
					 then
				    date_format(STR_TO_DATE(mb_dogovor.dog_data,   '%d/%m/%Y'),'%d.%m.%Y') 
			       else date_format(STR_TO_DATE(mb_ls.data1,   '%d/%m/%Y'),'%d.%m.%Y')  end,
					 '31.12.2999',  
                tmp_ipadr_new.id, 
                case when mb_dogovor.type_home = 'многоквартирный дом' 
					 	or mb_dogovor.type_home = 'общежитие' 
						  then 'МКД' 
					  else 'ЖД' end type_pomeshen, 
                tmp_ipadr_new.adr, 
                tmp_ipadr_new.ipadr, 
                case when mb_dogovor.type_home = 'жилой частный дом' 
                or mb_dogovor.type_home = 'дача' 
					 then '' 
					  else tmp_ipadr_new.pomesh end pomeshen, 
                tmp_ipadr_new.id, 
                tmp_ipadr_new.adr, 
                                case when mb_dogovor.type_home = 'жилой частный дом' 
                or mb_dogovor.type_home = 'дача' 
					 then '' 
					  else tmp_ipadr_new.pomesh end pomeshen, 
                '', 
                case when mb_uslugi.type_uslug <> ''
					 then mb_uslugi.type_uslug 
					 else 'Холодное водоснабжение' end, 
					 case when mb_uslugi.type_resurs <> '' 
					 then mb_uslugi.type_resurs 
					 else 'Питьевая вода' end, 
                case when mb_dogovor.dog_data <> '' 
					 then
					 date_format(STR_TO_DATE(mb_dogovor.dog_data,   '%d/%m/%Y'),'%d.%m.%Y') 
			    else date_format(STR_TO_DATE(mb_ls.data1,   '%d/%m/%Y'),'%d.%m.%Y') end,
					 '31.12.2999',  
                tmp_ipadr_new.id, 
                tmp_ipadr_new.adr, 
                case when mb_dogovor.type_home = 'жилой частный дом' 
                or mb_dogovor.type_home = 'дача' 
					 then '' 
					  else tmp_ipadr_new.pomesh end pomeshen,  
                '', 
                case when mb_uslugi.type_uslug <> '' 
					 then mb_uslugi.type_uslug 
					 else 'Холодное водоснабжение' end, 
					 case when mb_uslugi.type_resurs <> ''
					 then mb_uslugi.type_resurs 
					 else 'Питьевая вода' end, 
                'Соответствие показателей качества холодной воды требованиям законодательства Российской Федерации', 
                '', '', '', 
                'Соответствует',  
                mb_uslugi.type_uslug2,mb_uslugi.type_resurs2  
                FROM mb_ls left join mb_dogovor on mb_ls.ls = mb_dogovor.ls ,
                tmp_ipadr_new,mb_uslugi 
                where mb_ls.ls = tmp_ipadr_new.id  
                and mb_ls.ls = mb_uslugi.id  
                and mb_ls.ls NOT IN  
                ( 
                    SELECT gis_id.id  
                    FROM gis_id  
                    WHERE gis_id.status in ('Проект','Размещен')  
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


                if (MyDataReader.GetString(73) == "Отведение сточных вод")
                {

                    object1.AddRow(MyDataReader.GetString(44),
                    MyDataReader.GetString(73),
                    MyDataReader.GetString(74),
                    MyDataReader.GetString(47),
                    MyDataReader.GetString(48));

                    kyandkr.AddRow(MyDataReader.GetString(54),
                    MyDataReader.GetString(55),
                    MyDataReader.GetString(56),
                    MyDataReader.GetString(57),
                    MyDataReader.GetString(73),
                    MyDataReader.GetString(74),
                    MyDataReader.GetString(60),
                    MyDataReader.GetString(61));
                }

                z++;
                if (z % 1000 == 0)
                {
                    string pathFinal = "c:\\gis\\DOG" + y + "k.xlsx";

                    dogovor.FileSave(path, pathFinal, 1,2);
                    dogovor.Rows.Clear();

                    object1.FileSave(pathFinal, pathFinal, 3,2);
                    object1.Rows.Clear();

                    vkh.FileSave(pathFinal, pathFinal, 4,1);
                    vkh.Rows.Clear();

                    kyandkr.FileSave(pathFinal, pathFinal, 5,2);
                    kyandkr.Rows.Clear();

                    y++;
                }
            }

            dogovor.FileSave(path, "c:\\gis\\DOG-Final.xlsx", 1,2);
            object1.FileSave("c:\\gis\\DOG-Final.xlsx", "c:\\gis\\DOG-Final.xlsx", 3,2);
            vkh.FileSave("c:\\gis\\DOG-Final.xlsx", "c:\\gis\\DOG-Final.xlsx", 4,1);
            kyandkr.FileSave("c:\\gis\\DOG-Final.xlsx", "c:\\gis\\DOG-Final.xlsx", 5,2);

            dogovor.Rows.Clear();
            object1.Rows.Clear();
            vkh.Rows.Clear();
            kyandkr.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }

        public void ProjectDogovor(string path)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();

            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(@"SELECT distinct mb_ls.ls, 
                'Да', 
                mb_ls.ls, 
                case when mb_dogovor.dog_data <> '' 
				then
				date_format(STR_TO_DATE(mb_dogovor.dog_data,   '%d/%m/%Y'),'%d.%m.%Y') 
			    else '' end,
                case when mb_dogovor.dog_data <> '' 
				then
				date_format(STR_TO_DATE(mb_dogovor.dog_data,   '%d/%m/%Y'),'%d.%m.%Y') 
				else '' end,
                'Нет', 'Да','31.12.2999',
                case when mb_dogovor.type_home = 'общежитие' or mb_dogovor.type_home = 'многоквартирный дом' 
                then 'Собственник или пользователь жилого (нежилого) помещения в МКД'
                else 'Собственник или пользователь жилого дома (домовладения)' end type_home_ls,
                'Физическое лицо', 
                '', '', '', '', '', '', '', '', '',  '', '', '', '', '',
                '9', 
                'следующего месяца за расчетным', 
                '10', 
                'следующего месяца за расчетным', 
                '', '', '',
                '20', 
                'Нет', 
                '26', 
                'Нет', 
                'Да',
                'Нормативный правовой акт', 
                '', 
                '', 
                'Да', 
                'В разрезе договора',
                'Нет', 
                '', 
                gis_id.id_gis, 
                mb_uslugi.id,
					 case when mb_uslugi.type_uslug <> ''
					 then mb_uslugi.type_uslug 
					 else 'Холодное водоснабжение' end, 
					 case when mb_uslugi.type_resurs <> ''
					 then mb_uslugi.type_resurs
					 else 'Питьевая вода' end, 
                case when mb_dogovor.dog_data <> '' 
					 then
				    date_format(STR_TO_DATE(mb_dogovor.dog_data,   '%d/%m/%Y'),'%d.%m.%Y') 
			       else date_format(STR_TO_DATE(mb_ls.data1,   '%d/%m/%Y'),'%d.%m.%Y')  end,
					 '31.12.2999',  
                tmp_ipadr_new.id, 
                case when mb_dogovor.type_home = 'многоквартирный дом' 
					 	or mb_dogovor.type_home = 'общежитие' 
						  then 'МКД' 
					  else 'ЖД' end type_pomeshen, 
                tmp_ipadr_new.adr, 
                tmp_ipadr_new.ipadr, 
                case when mb_dogovor.type_home = 'жилой частный дом' 
                or mb_dogovor.type_home = 'дача' 
					 then '' 
					  else tmp_ipadr_new.pomesh end pomeshen, 
                tmp_ipadr_new.id, 
                tmp_ipadr_new.adr, 
                                case when mb_dogovor.type_home = 'жилой частный дом' 
                or mb_dogovor.type_home = 'дача' 
					 then '' 
					  else tmp_ipadr_new.pomesh end pomeshen, 
                '', 
                case when mb_uslugi.type_uslug <> ''
					 then mb_uslugi.type_uslug 
					 else 'Холодное водоснабжение' end, 
					 case when mb_uslugi.type_resurs <> '' 
					 then mb_uslugi.type_resurs 
					 else 'Питьевая вода' end, 
                case when mb_dogovor.dog_data <> '' 
					 then
					 date_format(STR_TO_DATE(mb_dogovor.dog_data,   '%d/%m/%Y'),'%d.%m.%Y') 
			    else date_format(STR_TO_DATE(mb_ls.data1,   '%d/%m/%Y'),'%d.%m.%Y') end,
					 '31.12.2999',  
                tmp_ipadr_new.id, 
                tmp_ipadr_new.adr, 
                case when mb_dogovor.type_home = 'жилой частный дом' 
                or mb_dogovor.type_home = 'дача' 
					 then '' 
					  else tmp_ipadr_new.pomesh end pomeshen,  
                '', 
                case when mb_uslugi.type_uslug <> '' 
					 then mb_uslugi.type_uslug 
					 else 'Холодное водоснабжение' end, 
					 case when mb_uslugi.type_resurs <> ''
					 then mb_uslugi.type_resurs 
					 else 'Питьевая вода' end, 
                'Соответствие показателей качества холодной воды требованиям законодательства Российской Федерации', 
                '', '', '', 
                'Соответствует',  
                mb_uslugi.type_uslug2,mb_uslugi.type_resurs2  
                FROM mb_ls left join mb_dogovor on mb_ls.ls = mb_dogovor.ls ,
                tmp_ipadr_new,mb_uslugi,gis_object_adress,gis_id,tmp_jky,gis_ls
                where mb_ls.ls = tmp_ipadr_new.id  
                and mb_ls.ls = mb_uslugi.id  
                and tmp_ipadr_new.ipadr = gis_object_adress.HOUSEGUID_fias 
                and mb_ls.ls = gis_id.id 
                and mb_ls.ls = gris_ls.id 
                and gis_object_adress.data_delete = '' 
                and gis_ls.ls_jky = tmp_jky.jky ");

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

                if (MyDataReader.GetString(73) == "Отведение сточных вод")
                {

                    object1.AddRow(MyDataReader.GetString(44),
                    MyDataReader.GetString(73),
                    MyDataReader.GetString(74),
                    MyDataReader.GetString(47),
                    MyDataReader.GetString(48));

                    kyandkr.AddRow(MyDataReader.GetString(54),
                    MyDataReader.GetString(55),
                    MyDataReader.GetString(56),
                    MyDataReader.GetString(57),
                    MyDataReader.GetString(73),
                    MyDataReader.GetString(74),
                    MyDataReader.GetString(60),
                    MyDataReader.GetString(61));
                }

                z++;
                if (z % 1000 == 0)
                {
                    string pathFinal = "c:\\gis\\DOG" + y + "k.xlsx";

                    dogovor.FileSave(path, pathFinal, 1,2);
                    dogovor.Rows.Clear();

                    object1.FileSave(pathFinal, pathFinal,3,2);
                    object1.Rows.Clear();

                    vkh.FileSave(pathFinal, pathFinal,4,1);
                    vkh.Rows.Clear();

                    kyandkr.FileSave(pathFinal, pathFinal,5,2);
                    kyandkr.Rows.Clear();

                    y++;
                }
            }

            dogovor.FileSave(path, "c:\\gis\\DOG-Final.xlsx",1,2);
            object1.FileSave("c:\\gis\\DOG-Final.xlsx", "c:\\gis\\DOG-Final.xlsx",3,2);
            vkh.FileSave("c:\\gis\\DOG-Final.xlsx", "c:\\gis\\DOG-Final.xlsx",4,1);
            kyandkr.FileSave("c:\\gis\\DOG-Final.xlsx", "c:\\gis\\DOG-Final.xlsx",5,2);

            dogovor.Rows.Clear();
            object1.Rows.Clear();
            vkh.Rows.Clear();
            kyandkr.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
