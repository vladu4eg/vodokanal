using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EIRC_Reester
{
    public partial class Form1 : Form
    {

        Excel importFile = new Excel();
        List<string> Rows = new List<string>();
        MySqlDataReader MyDataReader;

        StringBuilder sCommand = new StringBuilder("INSERT INTO id_ls VALUES ");

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;SslMode=none;Password=" + Protect.PasswordMysql);


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            DBFtoExcel(openFileDialog1.FileName, openFileDialog1.SafeFileName);
            //ExcelgoBDReester(openFileDialog1.FileName);
            DBtoExcel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            ExcelgoBD(openFileDialog2.FileName);
        }

        public void DBFtoExcel(string path, string fileName)
        {
            try
            {
                OdbcConnection obdcconn = new OdbcConnection();
                obdcconn.ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=Z:\\bank\\eirc\\;Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";


             //   OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=dBASE 5.0;Data Source=Z:\\bank\\eirc\\");

                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                obdcconn.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("TRUNCATE TABLE EIRC_LS;");
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос
                                            //StringBuilder sCommand = new StringBuilder("INSERT INTO EIRC_LS VALUES ");

                OdbcCommand oCmd = obdcconn.CreateCommand();
                oCmd.CommandText = "SELECT * FROM " + path;

                //OleDbCommand dbf = new OleDbCommand(string.Format("select * from " + fileName), conn);

                DataTable dt1 = new DataTable();
                dt1.Load(oCmd.ExecuteReader());
                obdcconn.Close();

               // DataSet ds = new DataSet();
               // OleDbDataAdapter da = new OleDbDataAdapter(string.Format("select * from " + fileName), conn);
              //  da.Fill(ds, "Item");
                foreach (DataRow row in dt1.Rows)
                {
                    myCommand.CommandText = string.Format("INSERT INTO EIRC_reester VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')",
                        MySqlHelper.EscapeString(row[0].ToString()),
                        MySqlHelper.EscapeString(row[1].ToString()),
                        MySqlHelper.EscapeString(row[2].ToString()),
                        MySqlHelper.EscapeString(row[3].ToString()),
                        MySqlHelper.EscapeString(row[4].ToString()),
                        MySqlHelper.EscapeString(row[5].ToString()),
                        MySqlHelper.EscapeString(row[6].ToString()),
                        MySqlHelper.EscapeString(row[7].ToString()),
                        MySqlHelper.EscapeString(row[8].ToString()),
                        MySqlHelper.EscapeString(row[9].ToString()),
                        MySqlHelper.EscapeString(row[10].ToString()),
                        MySqlHelper.EscapeString(row[11].ToString()),
                        MySqlHelper.EscapeString(row[12].ToString()),
                        MySqlHelper.EscapeString(row[13].ToString()),
                        MySqlHelper.EscapeString(row[14].ToString()));
                    myCommand.Prepare();
                    myCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ExcelgoBD(string path)
        {
            try
            {
                importFile.FileOpen(path);

                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("TRUNCATE TABLE EIRC_LS;");
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                StringBuilder sCommand = new StringBuilder("INSERT INTO EIRC_LS VALUES ");

                importFile.Rows.RemoveRange(0, 1);

                for (int i = 0; i < importFile.Rows.Count(); i++)
                {
                    Rows.Add(string.Format("('{0}','{1}')",
                        MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][1].ToString())));
                }

                sCommand.Append(string.Join(",", Rows));
                sCommand.Append(";");

                using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
                {
                    myCmd.CommandType = CommandType.Text;
                    myCmd.ExecuteNonQuery();
                }
                importFile.Rows.Clear();
                myConnection.Close();
                sCommand.Clear();
                Rows.Clear();
                MessageBox.Show("Вы загрузили ЛС от ЕИРЦ. \nМожете формировать реестры.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ExcelgoBDReester(string path)
        {
            try
            {
                importFile.FileOpen(path);

                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("TRUNCATE TABLE EIRC_LS;");
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                sCommand = new StringBuilder("INSERT INTO EIRC_reester VALUES ");

                importFile.Rows.RemoveRange(0, 1);

                for (int i = 0; i < importFile.Rows.Count(); i++)
                {
                    Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')",
                        MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][1].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][2].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][3].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][4].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][5].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][6].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][7].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][8].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][9].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][10].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][11].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][12].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][13].ToString()),
                        MySqlHelper.EscapeString(importFile.Rows[i][14].ToString())));
                }

                sCommand.Append(string.Join(",", Rows));
                sCommand.Append(";");

                using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
                {
                    myCmd.CommandType = CommandType.Text;
                    myCmd.ExecuteNonQuery();
                }
                importFile.Rows.Clear();
                myConnection.Close();
                sCommand.Clear();
                Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DBtoExcel()
        {
            try
            {

                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("select @n:=@n+1 as `num`, EIRC_reester.PAY_DATE, " +
                    "EIRC_LS.id_ls, concat(EIRC_reester.CITY, ', ', EIRC_reester.HOUSE, ' ', EIRC_reester.BUILDING, ', ', EIRC_reester.FLAT, ' ', EIRC_reester.LITER)," +
                    "EIRC_reester.PAY_PERIOD, EIRC_reester.PLAT_SUMMA " +
                    "from EIRC_reester, EIRC_LS " +
                    "where EIRC_reester.ls = EIRC_LS.id_eirc; ");

                myCommand.Prepare();//подготавливает строку
                MyDataReader = myCommand.ExecuteReader();
                while (MyDataReader.Read())
                {
                    importFile.AddRow(MyDataReader.GetString(0),
                               MyDataReader.GetString(1),
                               MyDataReader.GetString(2),
                               MyDataReader.GetString(3),
                               MyDataReader.GetString(4),
                               MyDataReader.GetString(5));
                }

                importFile.FileSave("c:\\" + openFileDialog1.FileNames + ".xlsx");

                importFile.Rows.Clear();
                myConnection.Close();
                Rows.Clear();

                MessageBox.Show("Готово! На диске С лежит файл: " + openFileDialog1.FileNames);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
