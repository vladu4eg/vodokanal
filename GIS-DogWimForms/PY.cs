using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class PY
    {
        Excel py = new Excel();
        Excel doppy = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);
        public void AddIPY(string path)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;
            //Сейчас запрос ищет новые водомеры на новых ЛС, а нужно по инв номеру

            myCommand.CommandText = string.Format(@"SELECT distinct '', 
				mb_ipy.inv, 
                'Индивидуальный', 
                mb_ipy.type, 
                mb_ipy.type, 
                '', 
                CASE 
                WHEN SUBSTRING(gis_ls.id_dom, 1, 1) <> 9  THEN gis_ls.id_dom  
                ELSE '' END AS adr1, 
                CASE 
                WHEN SUBSTRING(gis_ls.id_dom, 1, 1) = 9 THEN gis_ls.id_dom 
                ELSE '' END AS adr2,
                '',
                gis_ls.ls_jky,
                'Нет',
                '',
                'нет',
                '',
                '',
                'Холодная вода',
                'Кубический метр',
                'Однотарифный',
                mb_ipy.last_pokaz1,
                '', '', '',
                date_format(STR_TO_DATE(mb_ipy.data_set, '%d/%m/%Y'),'%d.%m.%Y'),
                date_format(STR_TO_DATE(mb_ipy.data_set, '%d/%m/%Y'),'%d.%m.%Y'), 
                date_format(STR_TO_DATE(mb_ipy.data_gp, '%d/%m/%Y'),'%d.%m.%Y'),
                '',
                case when mb_ipy.interval = '1' then concat(mb_ipy.interval, ' год')
                when mb_ipy.interval in ('2', '3', '4') then concat(mb_ipy.interval, ' года')  
                else concat(mb_ipy.interval, ' лет') end let,
                'Нет',
                '',
                'Нет',
                '' 
                FROM mb_ipy, gis_ls 
                where mb_ipy.ls = gis_ls.id 
                and mb_ipy.data_off = '' 
                and mb_ipy.inv not in (select gis_py_main.nomer from gis_py_main where gis_py_main.`type` = 'Индивидуальный' and gis_py_main.status_py = 'Активный') 
                and DATE_ADD(STR_TO_DATE(mb_ipy.data_gp, '%d/%m/%Y'), INTERVAL mb_ipy.interval YEAR)  >= date_format(DATE_ADD(now(), INTERVAL 2 month), '%Y-%m-%d') 
                and trim(mb_ipy.inv) not in ('*', '-') 
                order by mb_ipy.inv; ");

            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();

            int y = 1;
            int z = 1;

            while (MyDataReader.Read())
            {
                    py.AddRow(MyDataReader.GetString(0),
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
                           MyDataReader.GetString(30));
                z++;
                if (z % 5000 == 0)
                {
                    py.FileSave(path,"c:\\gis\\PY" + y + "k.xlsx",1,1);
                    py.Rows.Clear();

                    y++;
                }
            }

            py.FileSave(path,"c:\\gis\\PY-Final.xlsx",1,1);

            py.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }

        public void AddODPY(string path)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(@"SELECT distinct PY.id,  
                PY.inv,
                PY.type,
                PY.type_name,
                PY.type_name,
                PY.ulica,
                CASE
                WHEN PY.type = 'Индивидуальный' and SUBSTRING(id_ls.id_dom, 1, 1) <> 9  THEN id_ls.id_dom
                WHEN PY.`type` = 'Коллективный (общедомовой)' THEN id_ls.id_dom
                ELSE '' END AS adr1,
                CASE
                WHEN PY.`type` = 'Индивидуальный' and SUBSTRING(id_ls.id_dom, 1, 1) = 9 THEN id_ls.id_dom
                WHEN PY.`type` = 'Общий (квартирный)' THEN id_ls.id_dom
                ELSE '' END AS adr2,
                '',
                id_ls.ls_jky,
                'Нет',
                '',
                'нет',
                '',
                '',
                PY.type_resursa,
                'Кубический метр',
                'Однотарифный',
                PY.last_indication,
                '', '', '',
                PY.dat_set,
                '',
                PY.ldat_testing,
                '',
                case when PY.gos_poverka = '1' then concat(PY.gos_poverka, ' год')
                when PY.gos_poverka in ('2', '3', '4') then concat(PY.gos_poverka, ' года')  
                else concat(PY.gos_poverka, ' лет') end let,
                'Нет',
                '',
                'Нет',
                '',
                '' 
                FROM PY, id_ls 
                where PY.id = id_ls.id 
                and PY.status = 'прибор учета' 
                mb_ipy.data_off = ''
                and PY.inv not in (select id_py_main.nomer from id_py_main) 
               -- and PY.ndat_testing > date_format(DATE_ADD(now(), INTERVAL 2 month), '%Y-%m-%d')  ??????????
                and trim(PY.inv) not in ('*', '-') 
                order by PY.inv,PY.id ");

            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();

            int y = 1;
            int z = 1;
            string temp123 = null;

            while (MyDataReader.Read())
            {
                if (temp123 != MyDataReader.GetString(1) && MyDataReader.GetString(2) == "Индивидуальный")
                {
                    py.AddRow(MyDataReader.GetString(1),
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
                           MyDataReader.GetString(30));
                }
                else if (temp123 != MyDataReader.GetString(1) && MyDataReader.GetString(2) == "Коллективный (общедомовой)")
                {
                    py.AddRow(MyDataReader.GetString(1),
                    MyDataReader.GetString(2),
                    MyDataReader.GetString(3),
                    MyDataReader.GetString(4),
                    "",
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
                    MyDataReader.GetString(23),
                    MyDataReader.GetString(25),
                    MyDataReader.GetString(26),
                    MyDataReader.GetString(27),
                    MyDataReader.GetString(28),
                    MyDataReader.GetString(29),
                    MyDataReader.GetString(30));
                }
                else if (temp123 == MyDataReader.GetString(1) && MyDataReader.GetString(2) == "Коллективный (общедомовой)")
                {
                    doppy.AddRow("",
                    MyDataReader.GetString(1),
                    MyDataReader.GetString(2),
                    MyDataReader.GetString(3),
                    MyDataReader.GetString(9));
                }
                else
                {
                    //тут нужно подумать
                }
                z++;
                if (z % 5000 == 0)
                {
                    py.FileSave(path,"c:\\gis\\PY" + y + "k.xlsx",1,1);
                    py.Rows.Clear();

                    doppy.FileSave("c:\\gis\\PY" + y + "k.xlsx", "c:\\gis\\PY" + y + "k.xlsx",2,1);
                    doppy.Rows.Clear();

                    y++;
                }
                temp123 = MyDataReader.GetString(1);
            }
            py.FileSave(path,"c:\\gis\\PY-Final.xlsx",1,1);
            doppy.FileSave("c:\\gis\\PY - Final.xlsx","c:\\gis\\PY-Final.xlsx",2,1);

            py.Rows.Clear();
            doppy.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }

        public void DeleteIPY(string path)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(@"select distinct gis_py_main.id_gis, 'Замена по иной причине' from mb_ipy,gis_py_main where mb_ipy.inv = gis_py_main.nomer
                                    and mb_ipy.ls = gis_py_main.LS
                                    and gis_py_main.`type` = 'Индивидуальный'
                                    and gis_py_main.status_py = 'Активный'
                                    and mb_ipy.data_off <> ''
                                    and mb_ipy.inv not in (select gis_py_main.nomer from mb_ipy,gis_py_main where mb_ipy.inv = gis_py_main.nomer
								  	    and mb_ipy.ls = gis_py_main.LS 
									    and gis_py_main.`type` = 'Индивидуальный' 
                                        and gis_py_main.status_py = 'Активный' 
									    and mb_ipy.data_off = ''); ");

            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();

            int y = 1;
            int z = 1;

            while (MyDataReader.Read())
            {
                py.AddRow(MyDataReader.GetString(0),
                       MyDataReader.GetString(1));
                z++;
                if (z % 40000 == 0)
                {
                    py.FileSave(path,"c:\\gis\\DelPY" + y + "k.xlsx",1,1);
                    py.Rows.Clear();

                    y++;
                }
            }

            py.FileSave(path,"c:\\gis\\DelPY-Final.xlsx",1,1);

            py.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
