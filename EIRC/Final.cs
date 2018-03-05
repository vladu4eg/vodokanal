using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EIRC
{
    class Final
    {
        Excel kvit = new Excel();
        List<string> lstPY = new List<string>();
        DataSet datSet = new DataSet();
        MySqlDataReader MyDataReader;
        List<string> owner = new List<string>();
        StringBuilder sCommand = new StringBuilder();
        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);

        public void CreateUpdate()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("select EIRC_PY.* from EIRC_PY,EIRC_main where EIRC_main.id = EIRC_PY.id order by EIRC_PY.id");
            MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand.CommandText, myConnection);
            adapter.Fill(datSet, "Item");
            foreach (DataRow row in datSet.Tables["Item"].Rows)
            {
                lstPY.Add(row[0].ToString());
                lstPY.Add(row[1].ToString());
                lstPY.Add(row[2].ToString());
                lstPY.Add(row[3].ToString());
                lstPY.Add(row[4].ToString());
                lstPY.Add(row[5].ToString());
                lstPY.Add(row[6].ToString());
            }
            datSet.Clear();

            int y = 1;
            string temp = "";
            for (int z = 0; z < lstPY.Count; z += 7)
            {
                if (temp == lstPY[z + 0] && y < 7 && lstPY[z + 6] == "ИПУ")
                {
                    sCommand.Append(string.Format("UPDATE EIRC_main SET EIRC_main.inv_n" + y + "='{0}', " +
                        "EIRC_main.ipu_name" + y + "='{1}'," +
                        "EIRC_main.start_indication" + y + "='{2}', " +
                        "EIRC_main.last_indication" + y + "='{3}', " +
                        "EIRC_main.volume" + y + "='{4}' " +
                        "where EIRC_main.id ='{5}'; ", lstPY[z + 1], lstPY[z + 2], lstPY[z + 3],
                         lstPY[z + 4], lstPY[z + 5], lstPY[z + 0]));
                }
                else if (temp != lstPY[z + 0] && lstPY[z + 6] == "ИПУ")
                {
                    y = 1;
                    sCommand.Append(string.Format("UPDATE EIRC_main SET EIRC_main.inv_n" + y + "='{0}', " +
                        "EIRC_main.ipu_name" + y + "='{1}'," +
                        "EIRC_main.start_indication" + y + "='{2}', " +
                        "EIRC_main.last_indication" + y + "='{3}', " +
                        "EIRC_main.volume" + y + "='{4}' " +
                        "where EIRC_main.id ='{5}'; ", lstPY[z + 1], lstPY[z + 2], lstPY[z + 3],
                        lstPY[z + 4], lstPY[z + 5], lstPY[z + 0]));
                    temp = lstPY[z + 0];
                }
                else if (temp == lstPY[z + 0] && y < 5 && lstPY[z + 6] == "ОДПУ")
                {
                    sCommand.Append(string.Format("UPDATE EIRC_main SET EIRC_main.odpy_inv_n" + y + "='{0}', " +
                        "EIRC_main.odpy_name" + y + "='{1}'," +
                        "EIRC_main.odpy_start_indication" + y + "='{2}', " +
                        "EIRC_main.odpy_end_indication" + y + "='{3}', " +
                        "EIRC_main.odpy_volume" + y + "='{4}' " +
                        "where EIRC_main.id ='{5}'; ", lstPY[z + 1], lstPY[z + 2], lstPY[z + 3],
                        lstPY[z + 4], lstPY[z + 5], lstPY[z + 0]));
                }
                else if (temp != lstPY[z + 0] && lstPY[z + 6] == "ОДПУ")
                {
                    y = 1;
                    sCommand.Append(string.Format("UPDATE EIRC_main SET EIRC_main.odpy_inv_n" + y + "='{0}', " +
                    "EIRC_main.odpy_name" + y + "='{1}'," +
                    "EIRC_main.odpy_start_indication" + y + "='{2}', " +
                    "EIRC_main.odpy_end_indication" + y + "='{3}', " +
                    "EIRC_main.odpy_volume" + y + "='{4}' " +
                    "where EIRC_main.id ='{5}'; ", lstPY[z + 1], lstPY[z + 2], lstPY[z + 3],
                    lstPY[z + 4], lstPY[z + 5], lstPY[z + 0]));
                    temp = lstPY[z + 0];
                }
                y++;
            }
            myCommand.CommandText = sCommand.ToString();
            myCommand.Prepare();
            myCommand.ExecuteNonQuery();

            kvit.Rows.Clear();
            myConnection.Close();

            MessageBox.Show("Готово!");
        }

        public void CreateExcel()
        {
            string path = @"D:\Vladislav\ierc\sql\mysql_final.sql";
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251));
            string temp = sr.ReadToEnd();

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();

            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(temp.ToString());
            myCommand.Prepare();

            MyDataReader = myCommand.ExecuteReader();
            int z = 0;
            
            sCommand = new StringBuilder("INSERT INTO EIRC_Print VALUES ");

            while (MyDataReader.Read() && z != 22222)
            {
                owner.Add(string.Format("('{0}','{1}','{2}','{3}')",
                    MySqlHelper.EscapeString(MyDataReader.GetValue(0).ToString()),
                    MySqlHelper.EscapeString(MyDataReader.GetValue(1).ToString()),
                    MySqlHelper.EscapeString(MyDataReader.GetValue(4).ToString()),
                    MySqlHelper.EscapeString(MyDataReader.GetValue(31).ToString())));

                kvit.AddRow(MyDataReader.GetString(1),
                           MyDataReader.GetString(2),
                           MyDataReader.GetString(3),
                           MyDataReader.GetString(4),
                           MyDataReader.GetString(5),
                           MyDataReader.GetString(6),
                           "Городской Округ Ялта",
                           MyDataReader.GetString(8),
                           MyDataReader.GetString(9),
                           MyDataReader.GetString(10),
                           MyDataReader.GetString(11),
                           MyDataReader.GetString(12),
                           MyDataReader.GetString(13),
                           MyDataReader.GetString(14),
                           MyDataReader.GetString(15),
                           "МКД",
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
                           MyDataReader.GetString(35),
                           MyDataReader.GetString(36),
                           MyDataReader.GetString(37),
                           MyDataReader.GetString(38),
                           MyDataReader.GetString(39),
                           MyDataReader.GetString(40),
                           MyDataReader.GetString(41),
                           MyDataReader.GetString(42),
                           MyDataReader.GetString(43),
                MyDataReader.GetString(44),
                MyDataReader.GetString(45),
                MyDataReader.GetString(46),
                MyDataReader.GetString(47),
                MyDataReader.GetString(48),
                MyDataReader.GetString(49),
                MyDataReader.GetString(50),
                MyDataReader.GetString(51),
                MyDataReader.GetString(52),
                MyDataReader.GetString(53),
                MyDataReader.GetString(54),
                MyDataReader.GetString(55),
                MyDataReader.GetString(56),
MyDataReader.GetString(57),
MyDataReader.GetString(58),
MyDataReader.GetString(59),
MyDataReader.GetString(60),
MyDataReader.GetString(61),
MyDataReader.GetString(62),
MyDataReader.GetString(63),
MyDataReader.GetString(64),
MyDataReader.GetString(65),
MyDataReader.GetString(66),
MyDataReader.GetString(67),
MyDataReader.GetString(68),
MyDataReader.GetString(69),
MyDataReader.GetString(70),
MyDataReader.GetString(71),
MyDataReader.GetString(72),
MyDataReader.GetString(73),
MyDataReader.GetString(74),
MyDataReader.GetString(75),
MyDataReader.GetString(76),
MyDataReader.GetString(77),
MyDataReader.GetString(78),
MyDataReader.GetString(79),
MyDataReader.GetString(80),
MyDataReader.GetString(81),
MyDataReader.GetString(82),
MyDataReader.GetString(83),
MyDataReader.GetString(84),
MyDataReader.GetString(85),
MyDataReader.GetString(86),
MyDataReader.GetString(87),
MyDataReader.GetString(88),
MyDataReader.GetString(89),
MyDataReader.GetString(90),
MyDataReader.GetString(91),
MyDataReader.GetString(92),
MyDataReader.GetString(93));
                z++;
            }
            kvit.FileSave(string.Format("c:\\eirc\\eirc" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx"));
            kvit.Rows.Clear();

            MyDataReader.Close();

            sCommand.Append(string.Join(",", owner));
            sCommand.Append(";");

            using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.ExecuteNonQuery();
            }
            owner.Clear();
            sCommand.Clear();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\eirc\\");
        }
    }
}
