using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class Pokaz
    {
        Excel ipy = new Excel();
        Excel odpy = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";

        public void AddPokaz()
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
                "PY.type " +
                "FROM PY, id_py_main " +
                "where PY.inv = id_py_main.nomer " +
                "and PY.last_indication <> id_py_main.pokaz " +
                "and trim(PY.inv) not in ('-', '*') " +
                "order by PY.inv, PY.id_ls ");

            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();

            int y1 = 1;
            int y2 = 1;
            int z1 = 1;
            int z2 = 1;

            while (MyDataReader.Read())
            {
                if (MyDataReader.GetString(7) == "Индивидуальный")
                {
                    ipy.AddRow(MyDataReader.GetString(0),
                               MyDataReader.GetString(1),
                               MyDataReader.GetString(2),
                               MyDataReader.GetString(3),
                               MyDataReader.GetString(4),
                               MyDataReader.GetString(5),
                               MyDataReader.GetString(6));
                    z1++;
                }
                else
                {
                    odpy.AddRow(MyDataReader.GetString(0),
                    MyDataReader.GetString(1),
                    MyDataReader.GetString(2),
                    MyDataReader.GetString(3),
                    MyDataReader.GetString(4),
                    MyDataReader.GetString(5),
                    MyDataReader.GetString(6),
                    MyDataReader.GetString(7));
                    z2++;
                }
                if (z1 % 20000 == 0)
                {
                    ipy.FileSave("c:\\gis\\ipy" + y1 + "k.xlsx");
                    ipy.Rows.Clear();
                    y1++;
                }
                if (z2 % 20000 == 0)
                {
                    odpy.FileSave("c:\\gis\\odpy" + y2 + "k.xlsx");
                    odpy.Rows.Clear();
                    y2++;
                }
            }
            ipy.FileSave("c:\\gis\\ipy-Final.xlsx");
            ipy.Rows.Clear();

            odpy.FileSave("c:\\gis\\opdy-Final.xlsx");
            odpy.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
