using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class PY
    {
        Excel py = new Excel();
        Excel doppy = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";

        public void AddPY()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT distinct PY.id_ls, " +
                "PY.inv, " +
                "PY.type, " +
                "PY.type_name," +
                "PY.type_name2," +
                "PY.ulica, " +
                "CASE " +
                "WHEN PY.type = 'Индивидуальный' and SUBSTRING(id_ls.id_dom, 1, 1) <> 9  THEN id_ls.id_dom " +
                "WHEN PY.`type` = 'Коллективный (общедомовой)' THEN id_ls.id_dom " +
                "ELSE '' END AS adr1, " +
                "CASE " +
                "WHEN PY.`type` = 'Индивидуальный' and SUBSTRING(id_ls.id_dom, 1, 1) = 9 THEN id_ls.id_dom " +
                "WHEN PY.`type` = 'Общий (квартирный)' THEN id_ls.id_dom " +
                "ELSE '' END AS adr2, " +
                "''," +
                "id_ls.ls_jky," +
                "'Нет'," +
                "''," +
                "'нет'," +
                "'', " +
                "''," +
                "PY.voda," +
                "'Однотарифный'," +
                "PY.start_indication," +
                "'', '', '', ''," +
                "PY.dat_set, " +
                "PY.ldat_testing, " +
                "'', " +
                "case when PY.y = '1' then concat(PY.y, ' год') " +
                "when PY.y in ('2','3','4') then concat(PY.y, ' года') " +
                "else concat(PY.y, ' лет') end let, " +
                "'Нет'," +
                "''," +
                "'Нет'," +
                "''," +
                "'', " +
                "PY.z " +
                "FROM PY, id_ls " +
                "where PY.id_ls = id_ls.id " +
                "and PY.inv not in (select id_py_main.nomer from id_py_main) " +
                "and trim(PY.inv) not in ('*','-') " +
                "order by PY.inv,PY.id_ls ");

            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();
            ;
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
                    py.FileSave("c:\\gis\\PY" + y + "k.xlsx");
                    py.Rows.Clear();

                    doppy.FileSave("c:\\gis\\doppy" + y + "k.xlsx");
                    doppy.Rows.Clear();

                    y++;
                }
                temp123 = MyDataReader.GetString(1);
            }
            py.FileSave("c:\\gis\\PY-Final.xlsx");
            doppy.FileSave("c:\\gis\\DOPPY-Final.xlsx");

            py.Rows.Clear();
            doppy.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
        public void PyFIX()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT distinct PY.id_ls, " +
                "PY.inv, " +
                "PY.type, " +
                "PY.type_name," +
                "PY.type_name2," +
                "PY.ulica, " +
                "CASE " +
                "WHEN PY.type = 'Индивидуальный' and SUBSTRING(id_ls.id_dom, 1, 1) <> 9  THEN object_adress.id_dom " +
                "WHEN PY.`type` = 'Коллективный (общедомовой)' THEN object_adress.id_dom " +
                "ELSE '' END AS adr1, " +
                "CASE " +
                "WHEN PY.`type` = 'Индивидуальный' and SUBSTRING(id_ls.id_dom, 1, 1) = 9 THEN id_ls.id_dom " +
                "WHEN PY.`type` = 'Общий (квартирный)' THEN id_ls.id_dom " +
                "ELSE '' END AS adr2, " +
                "''," +
                "id_ls.ls_jky," +
                "'Нет'," +
                "''," +
                "'нет'," +
                "'', " +
                "''," +
                "PY.voda," +
                "'Однотарифный'," +
                "PY.start_indication," +
                "'', '', '', ''," +
                "PY.dat_set, " +
                "PY.ldat_testing, " +
                "'', " +
                "case when PY.y = '1' then concat(PY.y, ' год') " +
                "when PY.y in ('2','3','4') then concat(PY.y, ' года') " +
                "else concat(PY.y, ' лет') end let, " +
                "'Нет'," +
                "''," +
                "'Нет'," +
                "''," +
                "id_py_main.id_gis, " +
                "PY.z " +
                "FROM PY, id_ls, object_adress,id_py_main " +
                "where PY.id_ls = id_ls.id " +
                "and PY.inv = id_py_main.nomer " +
                "and object_adress.id_kvt = id_ls.id_dom " +
                "order by PY.inv,PY.id_ls ");

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
                    py.FileSave("c:\\gis\\PY" + y + "k.xlsx");
                    py.Rows.Clear();

                    doppy.FileSave("c:\\gis\\doppy" + y + "k.xlsx");
                    doppy.Rows.Clear();

                    y++;
                }
                temp123 = MyDataReader.GetString(1);
            }
            py.FileSave("c:\\gis\\PY-Final.xlsx");
            doppy.FileSave("c:\\gis\\DOPPY-Final.xlsx");

            py.Rows.Clear();
            doppy.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
