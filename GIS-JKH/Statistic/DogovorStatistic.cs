using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace GIS_JKH
{
    class DogovorStatistic
    {
        MySqlDataReader MyDataReader;
        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);
        string list = "";

        public string CheckCount()
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format(@"select concat(status,': ',count(*)) from gis_id where status in ('Проект','Размещен') group by status ;");
                myCommand.Prepare();//подготавливает строку
                MyDataReader = myCommand.ExecuteReader();

                while (MyDataReader.Read())
                {
                    list = list.Insert(list.Length, MyDataReader.GetString(0));
                    list = list.Insert(list.Length, "\n");
                }
                MyDataReader.Close();
                return list;
            }
            catch (Exception ex)
            {
                MyDataReader.Close();
                MessageBox.Show(ex.ToString());
                return "Ошибка!";
            }
        }
    }
}
