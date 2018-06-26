using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M2MSOAPSample
{
    class Import
    {
        Csv importFile = new Csv();
        List<string> Rows = new List<string>();
        int countDolg = 0;
        int countGP = 0;
        int countPokaz = 0;

        StringBuilder sCommand = new StringBuilder("INSERT INTO plan_test (sendDate,licscht,phone,sms,msg_type) VALUES ");
        static string Connect = string.Format("Database=ignas;Data Source=192.168.27.79;User Id=iguser;charset=cp1251;default command timeout = 999;SslMode=none;Password=  " + Protect.PasswordMysql);
        MySqlConnection myConnection = new MySqlConnection(Connect);
        MySqlCommand myCommand = new MySqlCommand();

        public string ImportBD(string path, string fileName, bool checkDolg = false, bool checkGP = false, bool checkPokaz = false)
        {
            try
            {

                importFile.FileOpen(path);

                myConnection.Open();
                myCommand.Connection = myConnection;
                importFile.Rows.RemoveAt(0);
                if(checkDolg || checkGP || checkPokaz)
                {
                    ImportGP(checkGP);
                    ImportPokaz(checkPokaz);
                    ImportDolg(checkDolg);
                }
                else
                MessageBox.Show("Выберите параметр формирования СМС");

                myConnection.Close();
                importFile.Rows.Clear();
                Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return string.Format("СМС с долгом: {0} \n" +
                        "СМС с ГП: {1} \n" +
                        "СМС с показаниями: {2} \n", countDolg, countGP, countPokaz);
        }
        private void ImportGP(bool check)
        {
            if(check)
            {
                try
                {
                    for (int i = 0; i < importFile.Rows.Count(); i++)
                    {
                        Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}')",
                            MySqlHelper.EscapeString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                            MySqlHelper.EscapeString(importFile.Rows[i][5].ToString()),
                            MySqlHelper.EscapeString(string.Format("До {0} сдать водомер на поверку Ялта,ул.Кривошты,27 т.346907", importFile.Rows[i][3].ToString())),
                            MySqlHelper.EscapeString("1")));
                        countGP++;
                    }

                    sCommand.Append(string.Join(",", Rows));
                    sCommand.Append(";");

                    using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
                    {
                        myCmd.CommandType = CommandType.Text;
                        myCmd.ExecuteNonQuery();
                    }
                    Rows.Clear();
                    sCommand.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }
        private void ImportPokaz(bool check)
        {
            if(check)
            {
                try
                {
                    sCommand = new StringBuilder("INSERT INTO plan_test (sendDate,licscht,phone,sms,msg_type) VALUES ");
                    for (int i = 0; i < importFile.Rows.Count(); i++)
                    {
                        Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}')",
                            MySqlHelper.EscapeString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                            MySqlHelper.EscapeString(importFile.Rows[i][5].ToString()),
                            MySqlHelper.EscapeString(string.Format("Вам необходимо предоставить показания водомера по +79180761858",
                                                                        DateTime.Now.ToString("dd.MM.yy"),
                                                                        importFile.Rows[i][3].ToString(),
                                                                  importFile.Rows[i][2].ToString())),
                            MySqlHelper.EscapeString("5")));
                        countPokaz++;
                    }

                    sCommand.Append(string.Join(",", Rows));
                    sCommand.Append(";");

                    using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
                    {
                        myCmd.CommandType = CommandType.Text;
                        myCmd.ExecuteNonQuery();
                    }
                    Rows.Clear();
                    sCommand.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        private void ImportDolg(bool check)
        {
            if(check)
            {
                try
                {
                    sCommand = new StringBuilder("INSERT INTO plan_test (sendDate,licscht,phone,sms,msg_type,dolg) VALUES ");
                    for (int i = 0; i < importFile.Rows.Count(); i++)
                    {
                        Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}')",
                            MySqlHelper.EscapeString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                            MySqlHelper.EscapeString(importFile.Rows[i][5].ToString()),
                            MySqlHelper.EscapeString(string.Format("На {0} по Л/С {1} долг {2} руб. Тариф - 57,67 руб.",
                                                                        DateTime.Now.ToString("dd.MM.yy"),
                                                                        importFile.Rows[i][3].ToString(),
                                                                  importFile.Rows[i][2].ToString())),
                            MySqlHelper.EscapeString("2"),
                            MySqlHelper.EscapeString(importFile.Rows[i][2].ToString())));
                        countDolg++;
                    }

                    sCommand.Append(string.Join(",", Rows));
                    sCommand.Append(";");

                    using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
                    {
                        myCmd.CommandType = CommandType.Text;
                        myCmd.ExecuteNonQuery();
                    }
                    Rows.Clear();
                    sCommand.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
