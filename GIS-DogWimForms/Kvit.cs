using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class Kvit
    {
        Excel razdel1_2 = new Excel();
        Excel razdel3_6 = new Excel();
        Excel dpd = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);
        public void CreatKvit(string path)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            string text_sql = @"D:\Vladislav\GIS JKH\sql\mysql_pd_mb.sql";
            StreamReader sr = new StreamReader(text_sql, Encoding.GetEncoding(1251));
            string temp = sr.ReadToEnd();

            myCommand.CommandText = string.Format(temp.ToString());
            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();

            int y = 1;
            int z = 1;

            while (MyDataReader.Read())
            {
                razdel1_2.AddRow(MyDataReader.GetString(0),
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
                           "",
                           MyDataReader.GetString(14),
                           MyDataReader.GetString(15),
                           MyDataReader.GetString(16));

                razdel3_6.AddRow(MyDataReader.GetString(17), //A
                MyDataReader.GetString(18), //B
                "", //C
                MyDataReader.GetString(24), //D
                MyDataReader.GetString(25), //E
                MyDataReader.GetString(33), //F
                MyDataReader.GetString(34), //G
                MyDataReader.GetString(19), //H
                MyDataReader.GetString(22), //I
                MyDataReader.GetString(35), //J
                MyDataReader.GetString(36), //K
                MyDataReader.GetString(31), //L
                MyDataReader.GetString(32), //M
                "", //N
                MyDataReader.GetString(27), //O
                "", "", "", "", "", "", "", "", "", "", "","","","", 
                MyDataReader.GetString(29),
                MyDataReader.GetString(37),
                MyDataReader.GetString(35)
                );

                if (MyDataReader.GetString(20) != "")
                {
                    razdel3_6.AddRow(MyDataReader.GetString(17), //A
                    MyDataReader.GetString(20),//B
                    "",//C
                    MyDataReader.GetString(24),//D
                    MyDataReader.GetString(26), //E
                    "", "", //F-G
                    MyDataReader.GetString(21),//H
                    MyDataReader.GetString(23), //I
                    "", //J
                    "",//K
                    "", //L
                    "","", //M-N
                    MyDataReader.GetString(28), //O
                    "", "", "", "", "", "", "", "", "", "", "", "","","",
                    MyDataReader.GetString(30));
                }
                
                z++;
                if (z % 5000 == 0)
                {
                    razdel1_2.FileSave(path,"c:\\gis\\PD" + y + "k.xlsx",1,3);
                    razdel1_2.Rows.Clear();

                    razdel3_6.FileSave("c:\\gis\\PD" + y + "k.xlsx", "c:\\gis\\PD" + y + "k.xlsx",2,4);
                    razdel3_6.Rows.Clear();

                    y++;
                }
            }
            razdel1_2.FileSave(path,"c:\\gis\\PD-Final.xlsx",1,3);
            razdel3_6.FileSave("c:\\gis\\PD-Final.xlsx", "c:\\gis\\PD-Final.xlsx",2,4);

            razdel1_2.Rows.Clear();
            razdel3_6.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }

}
