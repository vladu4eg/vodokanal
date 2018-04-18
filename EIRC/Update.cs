using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EIRC
{
    class Update
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        OracleConnection ConnectionToOracle;
        OracleDataReader OraDataReader;
        OracleCommand cmd = new OracleCommand();
        List<string> Rows = new List<string>();
        string temp;
        string path;

        StringBuilder sCommand = new StringBuilder("INSERT INTO import_vkh VALUES ");

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password="+ Protect.PasswordMysql);
        string connectionString = string.Format("DATA SOURCE=SERVER;PASSWORD=" + Protect.PasswordOracleAndUser);
        
        public void UpdateAll()
        {
            stopwatch.Start();

            UpdateClearAll();
            UpdateImport_vkh();
            UpdatePD();
            UpdatePY();
            UpdateAdress();

            stopwatch.Stop();
            MessageBox.Show("Готово! " + stopwatch.Elapsed);
        }
        public void UpdateImport_vkh()
        {
            path = @"D:\Vladislav\GIS JKH\sql\import_vkh.sql";
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251));
            temp = sr.ReadToEnd();
            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();
            cmd.Connection = ConnectionToOracle;

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            cmd.CommandText = string.Format(temp.ToString());
            cmd.Prepare();//подготавливает строку
            OraDataReader = cmd.ExecuteReader();
            while (OraDataReader.Read())
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                    MySqlHelper.EscapeString(OraDataReader.GetValue(0).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(1).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(2).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(3).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(4).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(5).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(6).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(7).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(8).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(9).ToString())));
            }
            sCommand.Append(string.Join(",", Rows));
            sCommand.Append(";");

            using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.ExecuteNonQuery();
            }
            OraDataReader.Close();
            Rows.Clear();
            sCommand.Clear();
            myConnection.Close();
        }
        public void UpdatePY()
        {
            path = @"D:\Vladislav\ierc\sql\py.sql";
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251));
            temp = sr.ReadToEnd();

            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();
            cmd.Connection = ConnectionToOracle;

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;
            sCommand = new StringBuilder("INSERT INTO EIRC_PY VALUES ");
            cmd.CommandText = string.Format(temp.ToString());
            cmd.Prepare();//подготавливает строку
            OraDataReader = cmd.ExecuteReader();
            while (OraDataReader.Read())
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                    MySqlHelper.EscapeString(OraDataReader.GetValue(0).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(1).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(2).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(3).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(4).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(5).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(6).ToString())));
            }
            sCommand.Append(string.Join(",", Rows));
            sCommand.Append(";");

            using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.ExecuteNonQuery();
            }
            OraDataReader.Close();
            Rows.Clear();
            sCommand.Clear();
            myConnection.Close();
        }
        public void UpdateAdress()
        {
            path = @"D:\Vladislav\GIS JKH\sql\adress.sql";
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251));
            temp = sr.ReadToEnd();

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(temp.ToString());
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();

            myConnection.Close();
        }
        public void UpdatePD()
        {
            path = @"D:\Vladislav\ierc\sql\main.sql";
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251));
            temp = sr.ReadToEnd();

            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();
            cmd.Connection = ConnectionToOracle;

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            cmd.CommandText = string.Format(temp.ToString());

            cmd.Prepare();//подготавливает строку
            OraDataReader = cmd.ExecuteReader();
            sCommand = new StringBuilder("INSERT INTO EIRC_main VALUES ");
            while (OraDataReader.Read())
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}'," +
                                       "'{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}','{66}','{67}','{68}','{69}','{70}','{71}')",
                    MySqlHelper.EscapeString(OraDataReader.GetValue(0).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(1).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(2).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(3).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(4).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(5).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(6).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(7).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(8).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(9).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(10).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(11).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(12).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(13).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(14).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(15).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(16).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(17).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(18).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(19).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(20).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(21).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(22).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(23).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(24).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(25).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(26).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(27).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(28).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(29).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(30).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(31).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(32).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(33).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(34).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(35).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(36).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(37).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(38).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(39).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(40).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(41).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(42).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(43).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(44).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(45).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(46).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(47).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(48).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(49).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(50).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(51).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(52).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(53).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(54).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(55).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(56).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(57).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(58).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(59).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(60).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(61).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(62).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(63).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(64).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(65).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(66).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(67).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(68).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(69).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(70).ToString()),
                    MySqlHelper.EscapeString(OraDataReader.GetValue(71).ToString())));
            }
            sCommand.Append(string.Join(",", Rows));
            sCommand.Append(";");

            using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.ExecuteNonQuery();
            }
            OraDataReader.Close();
            Rows.Clear();
            sCommand.Clear();
            myConnection.Close();
        }

        //clear
        public void UpdateClearAll()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE import_vkh;TRUNCATE TABLE ipadr_new;TRUNCATE TABLE EIRC_main;TRUNCATE TABLE EIRC_PY;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }

    }
}
