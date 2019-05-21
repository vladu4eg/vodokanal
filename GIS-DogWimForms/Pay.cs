using MySql.Data.MySqlClient;

namespace GIS_DogWimForms
{
    class Pay
    {
        Excel list = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);

        public void Kassa(string path)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(@"select mb_pay.ls,sum,date_format(STR_TO_DATE(data,   '%d/%m/%Y'),'%d.%m.%Y') , period,'',gis_ls.ls_jky from mb_pay,gis_ls 
                                                    where mb_pay.ls = gis_ls.id order by ls;");

            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();

            int y1 = 1;
            int z1 = 1;

            while (MyDataReader.Read())
            {
                list.AddRow(z1.ToString(),
                           MyDataReader.GetString(1),
                           MyDataReader.GetString(2),
                           MyDataReader.GetString(3),
                           MyDataReader.GetString(4),
                           MyDataReader.GetString(5));
                z1++;

                if (z1 % 40000 == 0)
                {
                    list.FileSave(path, "c:\\gis\\pay" + y1 + "k.xlsx", 1, 1);
                    list.Rows.Clear();
                    y1++;
                }
            }
            list.FileSave(path, "c:\\gis\\pay-Final.xlsx", 1, 1);
            list.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            System.Windows.Forms.MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
