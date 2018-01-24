using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        public void CreatKvit()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("");

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
                           MyDataReader.GetString(30),
                           MyDataReader.GetString(31),
                           MyDataReader.GetString(32),
                           MyDataReader.GetString(33),
                           MyDataReader.GetString(34),
                           MyDataReader.GetString(35));

                razdel3_6.AddRow(MyDataReader.GetString(37),
                               MyDataReader.GetString(38),
                               MyDataReader.GetString(39),
                               MyDataReader.GetString(40),
                               MyDataReader.GetString(41));

                dpd.AddRow(MyDataReader.GetString(43),
                MyDataReader.GetString(44),
                MyDataReader.GetString(45),
                MyDataReader.GetString(46),
                MyDataReader.GetString(47));
                

                z++;
                if (z % 1000 == 0)
                {
                    razdel1_2.FileSave("c:\\gis\\razdel1_2" + y + "k.xlsx");
                    razdel1_2.Rows.Clear();

                    razdel3_6.FileSave("c:\\gis\\razdel3_6" + y + "k.xlsx");
                    razdel3_6.Rows.Clear();

                    dpd.FileSave("c:\\gis\\dpd" + y + "k.xlsx");
                    dpd.Rows.Clear();

                    y++;
                }
            }
            razdel1_2.FileSave("c:\\gis\\RAZ1-Final.xlsx");
            razdel3_6.FileSave("c:\\gis\\RAZ3-Final.xlsx");
            dpd.FileSave("c:\\gis\\DPD-Final.xlsx");

            razdel1_2.Rows.Clear();
            razdel3_6.Rows.Clear();
            dpd.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }

}
