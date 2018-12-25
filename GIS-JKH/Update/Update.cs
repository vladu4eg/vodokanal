using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;

namespace GIS_JKH
{
    // Данный класс пока что не актуален, 
    // НО если мегабиллинг даст доступ к БД, 
    // то можно будет с легкостью переписать для их базы.
    // Кстати, они точно не используют Oracle

    class Update
    {

        Stopwatch stopwatch = Stopwatch.StartNew();

        OracleConnection ConnectionToOracle;
        OracleDataReader OraDataReader;
        OracleCommand cmd = new OracleCommand();
        List<string> Rows = new List<string>();
        string temp;
        string path;

        StringBuilder sCommand = new StringBuilder("INSERT INTO import_lischt VALUES ");

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password="+ Protect.PasswordMysql);
        string connectionString = string.Format("DATA SOURCE=SERVER;PASSWORD=" + Protect.PasswordOracleAndUser);
        
        public void UpdateAll()
        {
            stopwatch.Start();

            UpdateClearAll();
            UpdateImport_LS();
            UpdateImport_with();
            UpdateImport_vkh();
            UpdateLS();
            UpdatePY();
            UpdateAdress();

            stopwatch.Stop();
            MessageBox.Show("Готово! " + stopwatch.Elapsed);
        }
        public void UpdateImport_LS()
        {
            path = @"D:\Vladislav\GIS JKH\sql\import_ls.sql";
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
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}')",
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
                    MySqlHelper.EscapeString(OraDataReader.GetValue(24).ToString())));
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
        public void UpdateImport_with()
        {
            path = @"D:\Vladislav\GIS JKH\sql\import_with.sql";
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
            sCommand = new StringBuilder("INSERT INTO import_with VALUES ");
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
            sCommand = new StringBuilder("INSERT INTO import_vkh VALUES ");
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
        public void UpdateLS()
        {
            path = @"D:\Vladislav\GIS JKH\sql\ls.sql";
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
            sCommand = new StringBuilder("INSERT INTO LS VALUES ");

            while (OraDataReader.Read())
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')",
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
                    MySqlHelper.EscapeString(OraDataReader.GetValue(17).ToString())));
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
            path = @"D:\Vladislav\GIS JKH\sql\PY.sql";
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251));
            temp = sr.ReadToEnd();

            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();
            cmd.Connection = ConnectionToOracle;

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;
            sCommand = new StringBuilder("INSERT INTO PY VALUES ");
            cmd.CommandText = string.Format(temp.ToString());
            cmd.Prepare();//подготавливает строку
            OraDataReader = cmd.ExecuteReader();
            while (OraDataReader.Read())
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')",
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
                    MySqlHelper.EscapeString(OraDataReader.GetValue(18).ToString())));
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
            path = @"D:\Vladislav\GIS JKH\sql\PD.sql";
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
            sCommand = new StringBuilder("INSERT INTO PD VALUES ");
            while (OraDataReader.Read())
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')",
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
                    MySqlHelper.EscapeString(OraDataReader.GetValue(22).ToString())));
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

            myCommand.CommandText = string.Format("TRUNCATE TABLE import_lischt;TRUNCATE TABLE import_vkh;TRUNCATE TABLE import_with;TRUNCATE TABLE ipadr_new;TRUNCATE TABLE PY;TRUNCATE TABLE LS;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
        public void UpdateClearAdress()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE ipadr_new;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
        public void UpdateClearPD()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE EIRC_main;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
        public void UpdateClearPY()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE PY;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }

        public void UpdateClearAllGis()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE id_ls;TRUNCATE TABLE id_gis;TRUNCATE TABLE id_py_main;TRUNCATE TABLE object_adress;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
    }
}
