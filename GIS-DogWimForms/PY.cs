using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class PY
    {
        Excel py = new Excel();
        Excel doppy = new Excel();
        Excel stock = new Excel();

        public void AddPY()
        {
            string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";
            MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT PY.id_ls, " +
                "PY.inv_moner, " +
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
                "id_ls.ls_gis," +
                "'Нет'," +
                "''," +
                "PY.net," +
                "''," +
                "''," +
                "PY.voda," +
                "'Однотарифный'," +
                "PY.last_indication," +
                "'', '', '', ''," +
                "CASE WHEN PY.`type` <> 'Коллективный (общедомовой)' THEN PY.dat_set " +
                "else '' end dat_set, " +
                "CASE WHEN PY.`type` = 'Коллективный (общедомовой)' THEN PY.ldat_testing " +
                "else '' end ldat_testing, " +
                "CASE WHEN PY.`type` = 'Коллективный (общедомовой)' THEN PY.dat_plomba " +
                "else '' end dat_plomba, " +
                "CASE WHEN PY.`type` = 'Коллективный (общедомовой)' THEN PY.y " +
                "else '' end y, " +
                "'Нет'," +
                "''," +
                "'Нет'," +
                "''," +
                "PY.z " +
                "FROM PY, id_ls " +
                "where PY.id_ls = id_ls.id " +
                "order by PY.id_ls ");
            myCommand.Prepare();//подготавливает строку

            MySqlDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            int i = 0;
            int y = 1;
            int z = 1;
            int tempcout = 0;
            string temp123 = null;

            while (MyDataReader.Read())
            {
                temp123 = MyDataReader.GetString(0);
                break;
            }

            while (MyDataReader.Read())
            {
                if (temp123 == MyDataReader.GetString(0) & tempcout == 0)
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
                           MyDataReader.GetString(29));
                    if (MyDataReader.GetString(30) == "Сточные бытовые воды")
                    {
                        stock.AddRow(MyDataReader.GetString(5),
                        MyDataReader.GetString(1),
                        MyDataReader.GetString(2),
                        MyDataReader.GetString(3),
                        MyDataReader.GetString(30));
                    }
                    if (MyDataReader.GetString(12) == "Да")
                    {
                        doppy.AddRow(MyDataReader.GetString(5),
                        MyDataReader.GetString(1),
                        MyDataReader.GetString(2),
                        MyDataReader.GetString(3));
                    }
                    tempcout++;
                }
                else if (temp123 != MyDataReader.GetString(0))
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
                           MyDataReader.GetString(29));
                    if (MyDataReader.GetString(30) == "Сточные бытовые воды")
                    {
                        stock.AddRow(MyDataReader.GetString(5),
                        MyDataReader.GetString(1),
                        MyDataReader.GetString(2),
                        MyDataReader.GetString(3),
                        MyDataReader.GetString(30));
                    }
                    if (MyDataReader.GetString(12) == "Да")
                    {
                        doppy.AddRow(MyDataReader.GetString(5),
                        MyDataReader.GetString(1),
                        MyDataReader.GetString(2),
                        MyDataReader.GetString(3));
                    }
                }
                else
                {
                    doppy.AddRow(MyDataReader.GetString(5),
                    MyDataReader.GetString(1),
                    MyDataReader.GetString(2),
                    MyDataReader.GetString(3));
                }

                i += 30;
                z++;
                if (z % 5000 == 0)
                {

                    py.FileSave("c:\\gis\\PY" + y + "k.xlsx");
                    py.Rows.Clear();

                    doppy.FileSave("c:\\gis\\doppy" + y + "k.xlsx");
                    doppy.Rows.Clear();

                    stock.FileSave("c:\\gis\\stock" + y + "k.xlsx");
                    stock.Rows.Clear();

                    tempcout = 0;
                    temp123 = MyDataReader.GetString(0);
                    y++;
                }
            }
            py.FileSave("c:\\gis\\PY-Final.xlsx");
            doppy.FileSave("c:\\gis\\DOPPY-Final.xlsx");
            stock.FileSave("c:\\gis\\STOCK-Final.xlsx");

            py.Rows.Clear();
            doppy.Rows.Clear();
            stock.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
