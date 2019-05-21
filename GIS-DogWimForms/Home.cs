using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class Home
    {
        /*
        Excel mkd = new Excel();
        Excel jill = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);

       public void CreateHome()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT DISTINCT ipadr_new.adr, " +
                "ipadr_new.ipadr," +
                "'35729000001'," +
                "'Симферополь'," +
                "ipadr_new.adr," +
                "ipadr_new.pomesh " +
                "FROM ipadr_new, object_adress " +
                "WHERE ipadr_new.ipadr = object_adress.HOUSEGUID_fias " +
                "and ipadr_new.pomesh <> object_adress.kv " +
                "AND ipadr_new.pomesh <> '0' " +
                "AND ipadr_new.pomesh REGEXP '^[[:digit:]]+$' " +
                "AND ipadr_new.id NOT IN " +
                "(" +
                "SELECT id_ls.id " +
                "FROM id_ls " +
                ")" +
                "ORDER BY ipadr_new.adr,ipadr_new.pomesh;");

            myCommand.Prepare();//подготавливает строку

            MyDataReader = myCommand.ExecuteReader();

            int y = 1;
            int z = 1;
            string temp123 = null;

            while (MyDataReader.Read())
            {
                if (temp123 != MyDataReader.GetString(1))
                {
                    mkd.AddRow(MyDataReader.GetString(0),
                         MyDataReader.GetString(1),
                         MyDataReader.GetString(2),
                         MyDataReader.GetString(3));

                    jill.AddRow(MyDataReader.GetString(4),
                                MyDataReader.GetString(5));
                }
                else
                {
                    jill.AddRow(MyDataReader.GetString(4),
                                MyDataReader.GetString(5));
                }
                z++;
                if (z % 1000 == 0)
                {

                    mkd.FileSave("c:\\gis\\mkd" + y + "k.xlsx");
                    mkd.Rows.Clear();

                    jill.FileSave("c:\\gis\\jill" + y + "k.xlsx");
                    jill.Rows.Clear();
                    y++;
                }
                temp123 = MyDataReader.GetString(1);
            }
            mkd.FileSave("c:\\gis\\MKD-Final.xlsx");
            jill.FileSave("c:\\gis\\JILL-Final.xlsx");

            mkd.Rows.Clear();
            jill.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
        */
    }

}
