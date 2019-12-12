using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LGO
{
    public partial class Form1 : Form
    {
        List<string> Rows = new List<string>();
        MySqlDataReader MyDataReader;
        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;SslMode=none;Password=" + Protect.PasswordMysql);

        public Form1()
        {
            InitializeComponent();
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
                string directoryPath = Path.GetDirectoryName(openFileDialog1.FileName);
                ReadDBF WDBF = new ReadDBF(directoryPath);
                ImportReester(WDBF.GetAll(openFileDialog1.SafeFileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ImportReester(string sql_command)
        {
            try
            {
                if (sql_command != null)
                {
                    MySqlConnection myConnection = new MySqlConnection(Connect);
                    MySqlCommand myCommand = new MySqlCommand();
                    myConnection.Open();
                    myCommand.Connection = myConnection;

                    myCommand.CommandText = string.Format("TRUNCATE TABLE LGO_form2;");
                    myCommand.Prepare();//подготавливает строку
                    myCommand.ExecuteNonQuery();//выполняет запрос

                    using (MySqlCommand myCmd = new MySqlCommand(sql_command, myConnection))
                    {
                        myCmd.CommandType = CommandType.Text;
                        myCmd.ExecuteNonQuery();
                    }
                    myConnection.Close();
                    Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
