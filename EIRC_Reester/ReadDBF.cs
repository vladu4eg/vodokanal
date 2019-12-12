using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EIRC_Reester
{
    class ReadDBF
    {
        private OleDbConnection _connection = null;
        List<string> Rows = new List<string>();
        StringBuilder sCommand = new StringBuilder("INSERT INTO EIRC_reester VALUES ");

        OleDbDataReader OleDataReader;

        public ReadDBF(string path)
        {
            this._connection = new OleDbConnection();
            _connection.ConnectionString = "Provider=VFPOLEDB.1;Data Source="+ path +";Exclusive=No;Collating Sequence=Machine;CODEPAGE = 1251";
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
                        Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9:dd.MM.yyyy}','{10}','{11}','{12}','{13}','{14}')",
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
                                OleDataReader.GetValue(14)));
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

    }

}

