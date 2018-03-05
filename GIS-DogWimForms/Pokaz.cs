using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class Pokaz
    {
        Excel ipy = new Excel();
        Excel odpy = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);

        public void AddPokazIPY()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT distinct id_py_main.full_adress," +
                "id_py_main.id_gis," +
                "'Холодная вода'," +
                "PY.last_indication," +
                "'', ''," +
                "PY.ldate_indication," +
                "id_py_main.type " +
                "FROM PY, id_py_main " +
                "where PY.inv = id_py_main.nomer " +
                "and PY.last_indication <> id_py_main.pokaz " +
                "and PY.type = 'Индивидуальный' " +
                "and trim(PY.inv) not in ('-', '*') " +
                "and id_py_main.LS = PY.id_ls " +
                "order by PY.inv, PY.id_ls ");

            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();
            
            int y1 = 1;
            int z1 = 1;

            while (MyDataReader.Read())
            {
                    ipy.AddRow(MyDataReader.GetString(0),
                               MyDataReader.GetString(1),
                               MyDataReader.GetString(2),
                               MyDataReader.GetString(3),
                               MyDataReader.GetString(4),
                               MyDataReader.GetString(5),
                               MyDataReader.GetString(6));
                    z1++;

                if (z1 % 20000 == 0)
                {
                    ipy.FileSave("c:\\gis\\ipy" + y1 + "k.xlsx");
                    ipy.Rows.Clear();
                    y1++;
                }
            }
            ipy.FileSave("c:\\gis\\ipy-Final.xlsx");
            ipy.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
        public void AddPokazODPY()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT distinct id_py_main.full_adress," +
                "id_py_main.id_gis, " +
                "'Холодная вода', " +
                "PY.last_indication, " +
                "'', '', " +
                "PY.ldate_indication, " +
                "id_py_main.type " +
                "FROM PY, id_py_main " +
                "where PY.inv = id_py_main.nomer " +
                "and PY.last_indication <> id_py_main.pokaz " +
                "and trim(PY.inv) not in ('-', '*') " +
                "and id_py_main.`type` = PY.`type` " +
                "and PY.type = 'Коллективный (общедомовой)' " +
                "order by PY.inv, PY.id_ls");
            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();
            int y1 = 1;
            int z1 = 1;

            while (MyDataReader.Read())
            {
                odpy.AddRow(MyDataReader.GetString(0),
                           MyDataReader.GetString(1),
                           MyDataReader.GetString(2),
                           MyDataReader.GetString(3),
                           MyDataReader.GetString(4),
                           MyDataReader.GetString(5),
                           MyDataReader.GetString(6));
                z1++;

                if (z1 % 20000 == 0)
                {
                    odpy.FileSave("c:\\gis\\odpy" + y1 + "k.xlsx");
                    odpy.Rows.Clear();
                    y1++;
                }
            }

            odpy.FileSave("c:\\gis\\odpy-Final.xlsx");
            odpy.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
