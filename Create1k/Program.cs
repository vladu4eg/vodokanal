using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Data;

namespace Create1k
{
    class Program
    {

        static void Main(string[] args)
        {
            MySqlConnection myConnection = new MySqlConnection("Database = vlad_m; Data Source = 192.168.27.79; User Id = vlad_m; charset=cp1251;default command timeout = 999; Password=vlad19957");
            MySqlCommand myCommand = new MySqlCommand();

            MySqlDataReader MyDataReader;

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=dBASE 5.0;Data Source=D:\\Alex\\RNCB\\exp_db_gis");
            myCommand.Connection = myConnection;

            myConnection.Open();
            conn.Open();

            string s = DateTime.Now.ToString("yyyyMMdd_9103006160.DBF");

            OleDbCommand dbf = new OleDbCommand(string.Format("CREATE TABLE ["+s+ "] (ELS VARCHAR(20),PAYERIDENT VARCHAR(11), FIO VARCHAR(50), LS VARCHAR(11), STREET VARCHAR(25), BUILDING VARCHAR(10), FLAT VARCHAR(10), SUM1 NUMERIC(10,2), SERVICECOD VARCHAR(2))"), conn);

            dbf.Prepare();
            dbf.ExecuteNonQuery();

            myCommand.CommandText = string.Format("UPDATE rncb,id_ls set rncb.jky = id_ls.ls_jky where rncb.ls = id_ls.id");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос

            myCommand.CommandText = string.Format("select JKY,PAYERIDENT,FIO,LS,STREET,BUILDING,FLAT,SUM1,SERVICECOD from rncb");
            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();

            while (MyDataReader.Read())
            {
                dbf.CommandText = string.Format("INSERT INTO [" + s + "]  (ELS,PAYERIDENT,FIO,LS,STREET,BUILDING,FLAT,SUM1,SERVICECOD) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                    MySqlHelper.EscapeString(MyDataReader.GetString(0)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(1)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(2)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(3)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(4)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(5)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(6)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(7)),
                    MySqlHelper.EscapeString(MyDataReader.GetString(8)));
                dbf.Prepare();
                dbf.ExecuteNonQuery();
            }
            MyDataReader.Close();
            
            MyDataReader.Close();
            conn.Close();
        }
    }
}
