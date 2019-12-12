using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LGO_form2
{
    class ReadDBF
    {
        private OleDbConnection _connection = null;
        List<string> Rows = new List<string>();
        StringBuilder sCommand = new StringBuilder("INSERT INTO LGO_form2 VALUES ");
        MySqlDataReader MyDataReader;
        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;SslMode=none;Password=" + Protect.PasswordMysql);

        OleDbDataReader OleDataReader;

        public ReadDBF(string path)
        {
            this._connection = new OleDbConnection();
            _connection.ConnectionString = "Provider = VFPOLEDB.1;Data Source = " + path + ";Exclusive = No;Collating Sequence = Machine;CODEPAGE = 1251";
        }

        public string Execute(string command)
        {
            if (_connection != null)
            {
                try
                {
                    _connection.Open();
                    OleDbCommand oCmd = _connection.CreateCommand();
                    oCmd.CommandText = command;
                    oCmd.Prepare();
                    OleDataReader = oCmd.ExecuteReader();
                    while (OleDataReader.Read())
                    {
                        Rows.Add(string.Format("('{0}','{1}','{2}','{3}',{4},{5},{6},'{7}','{8:yyyy-MM-dd}','{9:yyyy-MM-dd}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')",
                                OleDataReader.GetValue(0),
                                OleDataReader.GetValue(1),
                                OleDataReader.GetValue(2),
                                OleDataReader.GetValue(3),
                                OleDataReader.GetValue(4),
                                OleDataReader.GetValue(5),
                                OleDataReader.GetValue(6),
                                OleDataReader.GetValue(7),
                                OleDataReader.GetValue(8),
                                OleDataReader.GetValue(9),
                                OleDataReader.GetValue(10),
                                OleDataReader.GetValue(11),
                                OleDataReader.GetValue(12),
                                OleDataReader.GetValue(13),
                                OleDataReader.GetValue(14),
                                OleDataReader.GetValue(15),
                                OleDataReader.GetValue(16)));
                    }
                    _connection.Close();

                    sCommand.Append(string.Join(",", Rows));
                    sCommand.Append(";");
                    Rows.Clear();
                    return sCommand.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            else return null;
        }

        public string GetAll(string dbpath)
        {
            return Execute("SELECT * FROM " + dbpath);
        }

        public void ClearAll(string dbpath)
        {
            _connection.Open();
            OleDbCommand oCmd = _connection.CreateCommand();
            oCmd.CommandText = "delete from " + dbpath;
            oCmd.Prepare();
            oCmd.ExecuteNonQuery();
            _connection.Close();
        }
        public void InstertData(string dbpath)
        {
            object[] values1;

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;
            _connection.Open();
            OleDbCommand oCmd = _connection.CreateCommand();

            string text_sql = @"D:\Vladislav\Выборки\Мегабиллинг\Льготы\form2toDBF2.sql";
            StreamReader sr = new StreamReader(text_sql, Encoding.GetEncoding(1251));
            string temp = sr.ReadToEnd();

            myCommand.CommandText = string.Format(temp.ToString());
            MyDataReader = myCommand.ExecuteReader();
            string tmp = "INSERT INTO [" + dbpath + "]" + "VALUES ( ";
            while (MyDataReader.Read())
            {

                MyDataReader.GetValues(values);

                for (int i = 0; i < 123; i++)
                {
                    String.Join(",", MySqlHelper.EscapeString(MyDataReader.GetValues(values1)));
                }
                oCmd.CommandText = string.Format("INSERT INTO [" + dbpath + "]  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                    MySqlHelper.EscapeString(MyDataReader.GetValue(0).ToString()),
                    MySqlHelper.EscapeString(MyDataReader.GetValue(1).ToString()),
                    MySqlHelper.EscapeString(MyDataReader.GetValue(2).ToString()),
                    MySqlHelper.EscapeString(MyDataReader.GetValue(3).ToString()),
                    MySqlHelper.EscapeString(MyDataReader.GetValue(4).ToString()),
                    MySqlHelper.EscapeString(MyDataReader.GetValue(5).ToString()),
                    MySqlHelper.EscapeString(MyDataReader.GetValue(6).ToString()),
                    MySqlHelper.EscapeString(MyDataReader.GetValue(7).ToString()),
                    MySqlHelper.EscapeString(MyDataReader.GetValue(8).ToString()));
                oCmd.Prepare();
                oCmd.ExecuteNonQuery();
            }
            MyDataReader.Close();

            MyDataReader.Close();
            _connection.Close();
        }
    }
}
