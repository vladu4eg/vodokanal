using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace RNCB
{
    public partial class Form1 : Form
    {
        OracleConnection ConnectionToOracle;
        string connectionString = "DATA SOURCE=SERVER;PASSWORD=ithba19957;USER ID=User057";

        MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection("Database = vlad_m; Data Source = 192.168.27.79; User Id = vlad_m; charset=cp1251;default command timeout = 999; Password=vlad19957");
        MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();

        public Form1()
        {
            InitializeComponent();
        }

        private void START_Click(object sender, EventArgs e)
        {
            OracleDataReader OraDataReader;
            MySqlDataReader MyDataReader;


            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=dBASE IV;Data Source=D:\\Alex\\РНКБ\\exp_db1");
            OracleCommand cmd = new OracleCommand();

            
            ConnectionToOracle = new OracleConnection(connectionString);
            myCommand.Connection = myConnection;


            ConnectionToOracle.Open();
            myConnection.Open();
            conn.Open();

            string s = DateTime.Now.ToString("yyyyMMdd__9103006160");

            OleDbCommand dbf = new OleDbCommand(string.Format("CREATE TABLE test (PAYERIDENT VARCHAR(11), FIO VARCHAR(50), LS VARCHAR(11), STREET VARCHAR(25), BUILDING VARCHAR(10), FLAT VARCHAR(10), SUM1 VARCHAR(10), SEVICECOD CHAR(2), JKY VARCHAR(10))"), conn);
            dbf.Prepare();
            dbf.ExecuteNonQuery();

            myCommand.CommandText = string.Format("TRUNCATE TABLE rncb");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос

            cmd.Connection = ConnectionToOracle;
            cmd.CommandText = string.Format("select vls.L_SCHET," +
                "       ' '," +
                "       vls.L_SCHET," +
                "       substr(trim(vls.VIDUL_NAME_SR) || ' ' || vls.ULICA_NAME_R, 1, 25)," +
                "       trim(vls.DOM_NAME)," +
                "       vls.KVART FLAT," +
                "       to_char(vls.DOLG, '99999999.99')," +
                "       '01', " +
                "       ' ' " +
                "  from v_ext_licscht vls " +
                " where vls.stlscht_id like eng.consts.lkOpenLS " +
                "and vls.STKVA_ID not like '__N' " +
                "order by vls.L_SCHET ");

            cmd.Prepare();//подготавливает строку
            OraDataReader = cmd.ExecuteReader();

            StringBuilder sCommand = new StringBuilder("INSERT INTO rncb (PAYERIDENT,FIO,LS,STREET,BUILDING,FLAT,SUM1,SERVICECOD,JKY) VALUES ");
            List<string> Rows = new List<string>();
            while (OraDataReader.Read())
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                    MySqlHelper.EscapeString(OraDataReader.GetString(0)),
                    MySqlHelper.EscapeString(OraDataReader.GetString(1)),
                    MySqlHelper.EscapeString(OraDataReader.GetString(2)),
                    MySqlHelper.EscapeString(OraDataReader.GetString(3)),
                    MySqlHelper.EscapeString(OraDataReader.GetString(4)),
                    MySqlHelper.EscapeString(OraDataReader.GetString(5)),
                    MySqlHelper.EscapeString(OraDataReader.GetString(6)),
                    MySqlHelper.EscapeString(OraDataReader.GetString(7)),
                    MySqlHelper.EscapeString(OraDataReader.GetString(8))));
            }
                sCommand.Append(string.Join(",", Rows));
                sCommand.Append(";");

                using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
                {
                    myCmd.CommandType = CommandType.Text;
                    myCmd.ExecuteNonQuery();
                }

            OraDataReader.Dispose();
            Rows.Clear();
            sCommand.Clear();

            myCommand.CommandText = string.Format("UPDATE rncb,id_ls set rncb.jky = id_ls.ls_jky where rncb.ls = id_ls.id");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос

            myCommand.CommandText = string.Format("select PAYERIDENT,FIO,LS,STREET,BUILDING,FLAT,SUM1,SERVICECOD,JKY from rncb");
            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();

            while (MyDataReader.Read())
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                    MySqlHelper.EscapeString(MyDataReader.GetString(0)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(1)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(2)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(3)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(4)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(5)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(6)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(7)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(8))));
                
            }
            StringBuilder sCommand2 = new StringBuilder("INSERT INTO test (PAYERIDENT,FIO,LS,STREET,BUILDING,FLAT,SUM1,SERVICECOD,JKY) VALUES ");

            sCommand2.Append(string.Join(",", Rows));
            sCommand2.Append(";");
            dbf.CommandText = sCommand2.ToString();
            dbf.Prepare();
            dbf.ExecuteNonQuery();

            MyDataReader.Close();
            OraDataReader.Close();
            conn.Close();
            ConnectionToOracle.Close();

        }
    }
}
