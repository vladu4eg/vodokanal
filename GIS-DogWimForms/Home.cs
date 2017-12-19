using BotAgent.DataExporter;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class Home
    {
        public void CreateHome()
        {
            Csv mkd = new Csv();
            Csv jill = new Csv();

            string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";
            MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
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
                "AND ipadr_new.pomesh <> '' " +
                "AND ipadr_new.pomesh REGEXP '^[1-999999]+$' " +
                "AND ipadr_new.id NOT IN " +
                "(" +
                "SELECT id_ls.id " +
                "FROM id_ls " +
                ")" +
                "ORDER BY ipadr_new.adr,ipadr_new.pomesh;");
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
                temp123 = MyDataReader.GetString(1);
                break;
            }

            while (MyDataReader.Read())
            {
                if (temp123 == MyDataReader.GetString(1) & tempcout == 0)
                {
                    mkd.AddRow(MyDataReader.GetString(0),
                         MyDataReader.GetString(1),
                         MyDataReader.GetString(2),
                         MyDataReader.GetString(3));

                    jill.AddRow(MyDataReader.GetString(4),
                                MyDataReader.GetString(5));
                    tempcout++;
                }
                else if (temp123 != MyDataReader.GetString(1))
                {
                    temp123 = MyDataReader.GetString(0);
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

                i += 6;
                z++;
                if (z % 1000 == 0)
                {

                    mkd.FileSave("c:\\gis\\mkd" + y + "k.csv");
                    mkd.Rows.Clear();

                    jill.FileSave("c:\\gis\\jill" + y + "k.csv");
                    jill.Rows.Clear();
                    tempcout = 0;
                    temp123 = MyDataReader.GetString(1);
                    y++;
                }
            }
            mkd.FileSave("c:\\gis\\MKD-Final.csv");
            jill.FileSave("c:\\gis\\JILL-Final.csv");


            mkd.Rows.Clear();
            jill.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
