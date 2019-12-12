using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class Home
    {
        
        Excel mkd = new Excel();
        Excel jill = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);

       public void CreateHome(string path)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(@"SELECT DISTINCT tmp_ipadr_new.adr,  
                tmp_ipadr_new.ipadr, 
                '35729000001', 
                'Симферополь', 
                tmp_ipadr_new.adr, 
                tmp_ipadr_new.pomesh 
                FROM tmp_ipadr_new, gis_object_adress 
                WHERE tmp_ipadr_new.ipadr = gis_object_adress.HOUSEGUID_fias 
                and tmp_ipadr_new.pomesh <> gis_object_adress.kv 
                AND tmp_ipadr_new.pomesh <> '0' 
                AND tmp_ipadr_new.pomesh REGEXP '^[[:digit:]]+$'  
                and gis_object_adress.type_dom = 'Многоквартирный' 
                -- and gis_object_adress.name_obsl = '' 
                AND tmp_ipadr_new.id NOT IN 
                ( 
                SELECT gis_ls.id 
                FROM gis_ls 
                ) 
                ORDER BY tmp_ipadr_new.adr,tmp_ipadr_new.pomesh;");

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

                    mkd.FileSave(path, "c:\\gis\\mkd" + y + "k.xlsx", 1, 3);
                    mkd.Rows.Clear();

                    jill.FileSave("c:\\gis\\mkd" + y + "k.xlsx", "c:\\gis\\mkd" + y + "k.xlsx", 3, 2);
                    jill.Rows.Clear();

                    y++;
                }
                temp123 = MyDataReader.GetString(1);
            }
            mkd.FileSave(path, "c:\\gis\\mkd-Final.xlsx", 1, 2);
            jill.FileSave("c:\\gis\\mkd-Final.xlsx", "c:\\gis\\mkd-Final.xlsx", 3, 2);

            mkd.Rows.Clear();
            jill.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
        
    }

}
