using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EIRC_Reester
{
    public partial class Form1 : Form
    {

        Excel importFile = new Excel();
        List<string> Rows = new List<string>();
        MySqlDataReader MyDataReader;
        StringBuilder sCommand = new StringBuilder();
        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;SslMode=none;Password=" + Protect.PasswordMysql);
        string nameFile;

        public Form1()
        {
            InitializeComponent();
            ToolTip t = new ToolTip();
            t.SetToolTip(button2, "Импорт новых ЕЛС.\nЕсли в БД есть такой ЕЛС,\nто программа обновит данные.\nДубликатов не будет.");
            t.SetToolTip(button1, "Импорт DBF от РНКБ.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "DBF files (*.dbf)|*.dbf";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                using (var fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                {
                    fs.Position = 29; //меняем 29 байт, чтобы установиь кодировку открытого DBF.
                    fs.WriteByte(101); // http://www.autopark.ru/ASBProgrammerGuide/DBFSTRUC.HTM#Table_9
                }

                DateTime dt = DateTime.ParseExact(openFileDialog1.SafeFileName.Substring(5, openFileDialog1.SafeFileName.Length - 9), "yyMMdd", CultureInfo.InvariantCulture);
                nameFile = dt.ToString("dd.MM.yyyy");
                string directoryPath = Path.GetDirectoryName(openFileDialog1.FileName);
                ReadDBF WDBF = new ReadDBF(directoryPath);
                ImportReester(WDBF.GetAll(openFileDialog1.SafeFileName));
                FromDBtoExcel();
                ErrorCheck();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                    return;
                ImportLS(openFileDialog2.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        public void ImportLS(string path)
        {
            try
            {
                importFile.FileOpen(path);

                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                StringBuilder sCommand = new StringBuilder("REPLACE INTO EIRC_LS VALUES ");
                if (!IsDigitsOnly(importFile.Rows[0][0].ToString()) || !IsDigitsOnly(importFile.Rows[0][1].ToString()))
                        importFile.Rows.RemoveRange(0, 1);

                for (int i = 0; i < importFile.Rows.Count(); i++)
                {
                    if (importFile.Rows[i][1].ToString().Length <= 6)
                    {
                        Rows.Add(string.Format("('{0}','{1}')",
                            MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                            MySqlHelper.EscapeString(importFile.Rows[i][1].ToString())));
                    }
                    else
                    {
                        Rows.Add(string.Format("('{1}','{0}')",
                            MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                            MySqlHelper.EscapeString(importFile.Rows[i][1].ToString())));
                    }
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

        public void ImportReester(string path)
        {
            try
            {
                if (path != null)
                {
                    MySqlConnection myConnection = new MySqlConnection(Connect);
                    MySqlCommand myCommand = new MySqlCommand();
                    myConnection.Open();
                    myCommand.Connection = myConnection;

                    myCommand.CommandText = string.Format("TRUNCATE TABLE EIRC_reester;");
                    myCommand.Prepare();//подготавливает строку
                    myCommand.ExecuteNonQuery();//выполняет запрос

                    using (MySqlCommand myCmd = new MySqlCommand(path, myConnection))
                    {
                        myCmd.CommandType = CommandType.Text;
                        myCmd.ExecuteNonQuery();
                    }
                    myConnection.Close();
                    sCommand.Clear();
                    Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void FromDBtoExcel()
        {
            try
            {
                double sum = 0;
                int count = 0;
                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("select distinct EIRC_reester.PAY_DATE,  EIRC_reester.LS," +
                    "EIRC_LS.id_ls, concat(EIRC_reester.CITY,', ' ,EIRC_reester.STREET,', д. ', EIRC_reester.HOUSE, ' ', EIRC_reester.BUILDING, ', кв. ', EIRC_reester.FLAT, ' ', EIRC_reester.LITER)," +
                    "EIRC_reester.PAY_PERIOD, EIRC_reester.SERV_SUMMA " +
                    "from EIRC_reester, EIRC_LS " +
                    "where EIRC_reester.ls = EIRC_LS.id_eirc; ");

                myCommand.Prepare();//подготавливает строку
                MyDataReader = myCommand.ExecuteReader();
                importFile.AddRow("Дата оплаты", "ЕИРЦ ЛС", "ЛС", "Адрес", "Период", "Сумма");

                while (MyDataReader.Read())
                {
                    importFile.AddRow(MyDataReader.GetString(0),
                               MyDataReader.GetString(1),
                               MyDataReader.GetString(2),
                               MyDataReader.GetString(3),
                               MyDataReader.GetString(4),
                               MyDataReader.GetString(5));
                    sum += Convert.ToDouble(MyDataReader.GetString(5));
                    count++;
                }
                MyDataReader.Close();

                importFile.AddRow("Количество:", count.ToString(), "", "", "Сумма:", sum.ToString("#.##"));
                importFile.FileSave("\\\\192.168.27.79\\public\\bank\\eirc\\РЕЕСТРЫ\\" + nameFile + ".xlsx");

                importFile.Rows.Clear();
                Rows.Clear();

                if (File.Exists("\\\\192.168.27.79\\public\\bank\\eirc\\" + openFileDialog1.SafeFileName))
                    File.Delete("\\\\192.168.27.79\\public\\bank\\eirc\\" + openFileDialog1.SafeFileName);

                File.Move(openFileDialog1.FileName, "\\\\192.168.27.79\\public\\bank\\eirc\\" + openFileDialog1.SafeFileName);
                myConnection.Close();
                MessageBox.Show("Готово! На диске \\\\192.168.27.79\\public\\bank\\eirc\\РЕЕСТРЫ\\ " + nameFile + ".xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ErrorCheck()
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("select distinct EIRC_reester.PAY_DATE,  EIRC_reester.LS, " +
                        "concat(EIRC_reester.CITY, ', ', EIRC_reester.STREET, ', д. ', EIRC_reester.HOUSE, ' ', EIRC_reester.BUILDING, ', кв. ', EIRC_reester.FLAT, ' ', EIRC_reester.LITER)," +
                        "EIRC_reester.PAY_PERIOD, EIRC_reester.SERV_SUMMA " +
                        "from EIRC_reester " +
                        "where EIRC_reester.ls not in (select EIRC_LS.id_eirc from EIRC_LS);");

                myCommand.Prepare();//подготавливает строку
                MyDataReader = myCommand.ExecuteReader();
                importFile.AddRow("Дата оплаты", "ЕИРЦ ЛС", "Адрес", "Период", "Сумма");

                while (MyDataReader.Read())
                {
                    importFile.AddRow(MyDataReader.GetString(0),
                               MyDataReader.GetString(1),
                               MyDataReader.GetString(2),
                               MyDataReader.GetString(3),
                               MyDataReader.GetString(4));
                }
                if (MyDataReader.HasRows)
                {
                    importFile.FileSave("\\\\192.168.27.79\\public\\bank\\eirc\\РЕЕСТРЫ\\ERROR_" + nameFile + ".xlsx");
                    MessageBox.Show("ОШИБКА!!! На диске \\\\192.168.27.79\\public\\bank\\eirc\\РЕЕСТРЫ\\ERROR_" + nameFile + ".xlsx");
                }
                importFile.Rows.Clear();
                Rows.Clear();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
