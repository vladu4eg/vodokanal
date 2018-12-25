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

        StringBuilder sCommand = new StringBuilder("INSERT INTO plan (sendDate,licscht,phone,sms,msg_type,dolg) VALUES ");
        static string Connect = string.Format("Database=ignas;Data Source=192.168.27.79;User Id=iguser;charset=cp1251;default command timeout = 999;SslMode=none;Password=  " + Protect.PasswordMysql);
        MySqlConnection myConnection = new MySqlConnection(Connect);
        MySqlCommand myCommand = new MySqlCommand();
        MySqlDataReader MyDataReader;

        public string ImportBD(string path, string fileName, bool checkDolg = false, bool checkGP = false, bool checkPokaz = false, bool checkOplata = false)
        {
            try
            {
                importFile.FileOpen(path);
                importFile.Rows.RemoveAt(0);

                if(checkOplata & checkDolg || checkOplata & checkGP || checkOplata & checkPokaz)
                {
                    MessageBox.Show("Нельзя одним файлом проверить все. \nДобро пожаловать в мир с ограничениями :P ");
                }
                else if (checkDolg || checkGP || checkPokaz)
                {
                    ImportSMS(checkDolg, checkGP, checkPokaz);
                }
                else if (checkOplata)
                {
                    ImportOplat();
                }
                else
                    MessageBox.Show("Выберите параметр формирования СМС");

                importFile.Rows.Clear();
                Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return string.Format("Сформировано:\n" +
                                 "СМС с долгом: {0} \n" +
                                 "СМС с ГП: {1} \n" +
                                 "СМС с показ..: {2} \n" +
                                 "Всего: {3}", countDolg, countGP, countPokaz, (countDolg + countGP + countPokaz));
        }

        public void ImportOplat()
        {
            try
            {
                List<string> list = new List<string>();
                sCommand.Clear();

                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = string.Format("select plan.licscht from plan where date_format(sendDate, '%y.%m') = '{0}'; ", DateTime.Today.AddMonths(-1).ToString("yy.MM"));
                myCommand.Prepare();

                MyDataReader = myCommand.ExecuteReader();
                while (MyDataReader.Read())
                {
                    list.Add(MyDataReader.GetString(0));
                }
                MyDataReader.Close();

                for (int i = 0; i < importFile.Rows.Count(); i++)
                {
                    foreach (string y in list)
                        if (y == importFile.Rows[i][1].ToString())
                        {
                            sCommand.Append(string.Format("update plan set opl = '{0}' where date_format(sendDate, '%y.%m') = '{1}' and licscht = '{2}' and msg_type = 2; ",
                                                           importFile.Rows[i][2].ToString(), DateTime.Today.AddMonths(-1).ToString("yy.MM"), importFile.Rows[i][1].ToString()));
                        }
                }
                list.Clear();

                myCommand.CommandText = sCommand.ToString();
                myCommand.Prepare();
                myCommand.ExecuteNonQuery();

                Rows.Clear();
                sCommand.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ImportSMS(bool checkDolg = false, bool checkGP = false, bool checkPokaz = false)
        {
            try
            {
                myConnection.Open();

                for (int i = 0; i < importFile.Rows.Count(); i++)
                {

                    if (importFile.Rows[i][6].ToString() == "2" && checkDolg)
                    {
                        Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}')",
                            MySqlHelper.EscapeString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                            MySqlHelper.EscapeString(importFile.Rows[i][3].ToString()),
                            MySqlHelper.EscapeString(string.Format("На {0} по Л/С {1} долг {2} руб. Тариф - 61,49 руб.",
                                        DateTime.Now.ToString("dd.MM.yy"), importFile.Rows[i][0].ToString(), importFile.Rows[i][2].ToString())),
                            MySqlHelper.EscapeString(importFile.Rows[i][6].ToString()),
                            MySqlHelper.EscapeString(importFile.Rows[i][2].ToString())));
                        countDolg++;
                    }
                    else if (importFile.Rows[i][6].ToString() == "1" && checkGP)
                    {
                        Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}')",
                            MySqlHelper.EscapeString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                            MySqlHelper.EscapeString(importFile.Rows[i][3].ToString()),
                            MySqlHelper.EscapeString(string.Format("Поверка водомера до {0}\n79789470440\nЯлта,ул.Кривошты,27", importFile.Rows[i][5].ToString())),
                            MySqlHelper.EscapeString(importFile.Rows[i][6].ToString()),
                            MySqlHelper.EscapeString("NULL")));
                        countGP++;
                    }
                    else if (importFile.Rows[i][6].ToString() == "5" && checkPokaz)
                    {
                        Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}')",
                            MySqlHelper.EscapeString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                            MySqlHelper.EscapeString(importFile.Rows[i][3].ToString()),
                            MySqlHelper.EscapeString("Вам необходимо предоставить показания водомера по +79180761858"),
                            MySqlHelper.EscapeString(importFile.Rows[i][6].ToString()),
                            MySqlHelper.EscapeString("NULL")));
                        countPokaz++;
                    }
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
