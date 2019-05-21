using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using M2MSOAPSample.M2MSoapService;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace M2MSOAPSample
{
    public partial class mainForm : Form
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        StringBuilder sCommand = new StringBuilder();
        static string Connect = string.Format("Database=ignas;Data Source=192.168.27.79;User Id=iguser;charset=cp1251;default command timeout = 99999999;Connect Timeout = 99999999;SslMode=none;Password=  " + Protect.PasswordMysql);
        MySqlConnection myConnection = new MySqlConnection(Connect);
        MySqlCommand myCommand = new MySqlCommand("set net_write_timeout=99999999; set net_read_timeout=99999999");
        MySqlDataReader MyDataReader;
        StringBuilder errorString = new StringBuilder();
        List<string> list = new List<string>();

        public mainForm()
        {
            InitializeComponent();
            GetBalance(txtLogin.Text, GetMd5Hash(txtPassword.Text));
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            labTime.Text = "Время отправки СМС:";
            labSend.Text = "Отправлено:";
            myConnection.Open();
            myCommand.Connection = myConnection;

            int count_sms = 0;
            string idSMS;
            try
            {
                myCommand.CommandText = string.Format("select distinct plan.licscht,plan.phone,plan.sms,plan.id from plan " +
                    "where delivery = 0 " +
                    "and sms_id = 0 " +
                    "and length(phone) = 11 " +
                    "and date_format(sendDate, '%Y-%m') = date_format(now(), '%Y-%m') " +
                    "and plan.licscht not in (select ls from tmp_ignore) " +
                    "order by plan.msg_type, licscht; ");
                myCommand.Prepare();//подготавливает строку
                MyDataReader = myCommand.ExecuteReader();

                while (MyDataReader.Read())
                {
                    list.Add(MyDataReader.GetString(0));
                    list.Add(MyDataReader.GetString(1));
                    list.Add(MyDataReader.GetString(2));
                    list.Add(MyDataReader.GetString(3));
                }
                MyDataReader.Close();

                //Прокси для вызова методов сервиса
                MTSCommunicatorM2MXMLAPI client = GetSoapService();
                for (int i = 0; i <= list.Count - 4; i += 4)
                {
                    idSMS = client.SendMessage(list[i + 1], list[i + 2], "Vodokanal", txtLogin.Text, GetMd5Hash(txtPassword.Text));
                    if (IsDigitsOnly(idSMS))
                    {
                        //Сформировать запрос 
                        sCommand.Append(string.Format("update plan set sms_id=" + idSMS + " where licscht='{0}' and phone='{1}' and id='{2}' and date_format(sendDate,'%Y-%m')=date_format(now(),'%Y-%m') and sms_id=0; ",
                                                   list[i + 0], list[i + 1], list[i + 3]));   //сравниваю по тексту... вдруг на один номер несколько смс и я могу присвоить айди не той СМСки.
                                                                                              //это была глупая идея... лучше сравнивать по внутр айди смс
                        count_sms++;
                    }
                    else
                    {
                        //errorString.Append(string.Format(idSMS + "\n"));
                    }

                }

                //Подготавливаем и выполняем
                myCommand.CommandText = sCommand.ToString();
                myCommand.Prepare();
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                labSend.Text = Convert.ToString(string.Format("Отправлено: {0}", count_sms));
                MessageBox.Show(string.Format(ex.Message));
                if (sCommand.ToString() != "")
                {
                    //Подготавливаем и выполняем
                    myCommand.CommandText = sCommand.ToString();
                    myCommand.Prepare();
                    myCommand.ExecuteNonQuery();
                }
            }

            stopwatch.Stop();
            myConnection.Close();
            sCommand.Clear();

            labTime.Text = string.Format("Время отправки СМС: " + stopwatch.Elapsed);
            labSend.Text = Convert.ToString(string.Format("Отправлено: {0}", count_sms));
            stopwatch.Reset();

            // if (!String.IsNullOrEmpty(errorString.ToString()))
            // {
            //     Error error = new Error(errorString.ToString());
            //     error.Show();
            // }
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

        private void btnGet_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            labCheckDostavka.Text = "Доставлено:";
            sCommand.Clear();

            int countStatus0 = 0;
            int countStatus1 = 0;
            int countStatus2 = 0;
            int status = 0;

            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = string.Format("select plan.sms_id from plan " +
                    "where delivery = 0 " +
                    "and sms_id <> 0 " +
                    "and length(phone) = 11 " +
                    "and date_format(sendDate, '%Y-%m') = date_format(now(), '%Y-%m'); ");
                myCommand.Prepare();//подготавливает строку
                MyDataReader = myCommand.ExecuteReader();

                //Прокси для вызова методов сервиса
                MTSCommunicatorM2MXMLAPI client = GetSoapService();

                while (MyDataReader.Read())
                {
                    //Получить статус доставки для сообщения
                    DeliveryInfo[] info = client.GetMessageStatus(MyDataReader.GetInt64(0), txtLogin.Text, GetMd5Hash(txtPassword.Text));

                    switch (info[0].DeliveryStatus.ToString())
                    {
                        case "Pending":
                        case "Sending":
                        case "Sent":
                        case "NotSent":
                            status = 0;
                            countStatus0++;
                            break;

                        case "Delivered":
                            status = 1;
                            countStatus1++;
                            break;
                        case "NotDelivered":
                        case "TimedOut":
                        case "Error":
                            status = 2;
                            countStatus2++;
                            break;

                        default:
                            break;

                    }
                    sCommand.Append(string.Format("update plan set delivery='{0}', delivery_type='{1}', reciveDate='{2}' where sms_id='{3}'; ",
                        status, info[0].DeliveryStatus, info[0].DeliveryDate.ToString("yyyy-MM-dd HH:mm:ss"), MyDataReader.GetInt64(0)));
                }

                labCheckDostavka.Text = string.Format("Доставлено:\n" +
                                        "В ожид.: {0}\n" +
                                        "Получ.: {1}\n" +
                                        "Ошибка: {2}\n" +
                                        "Всего: {3}\n", countStatus0, countStatus1, countStatus2, (countStatus0 + countStatus1 + countStatus2));

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message));
            }
            MyDataReader.Close();
            //Подготавливаем и выполняем
            myCommand.CommandText = sCommand.ToString();
            myCommand.Prepare();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            sCommand.Clear();
            stopwatch.Stop();
            labTime.Text = string.Format("Время проверки доставки: " + stopwatch.Elapsed);
            stopwatch.Reset();
        }

        private void btnGener_Click(object sender, EventArgs e)
        {
            labImport.Text = "Сформировано:";
            labTime.Text = "Время обработки:";
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            stopwatch.Start();
            Import import = new Import();
            labImport.Text = import.ImportBD(openFileDialog1.FileName, openFileDialog1.SafeFileName, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, chkSred.Checked, chkNormtative.Checked, chkOplata.Checked);

            stopwatch.Stop();
            labTime.Text = string.Format("Время обработки: " + stopwatch.Elapsed);
            stopwatch.Reset();
        }

        private MTSCommunicatorM2MXMLAPI GetSoapService()
        {
            int port = -1;
            MTSCommunicatorM2MXMLAPI client = null;
            client = new MTSCommunicatorM2MXMLAPI();
            if (chbUseProxy.Checked && int.TryParse(txtProxyPort.Text, out port))
                client.Proxy = new WebProxy(txtProxyServer.Text, port);
            return client;
        }

        public static string GetMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void chbUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            txtProxyServer.Enabled = chbUseProxy.Checked;
            txtProxyPort.Enabled = chbUseProxy.Checked;
        }

        public void GetBalance(string login, string password)
        {
            try
            {
                label3.Text = "Баланс: ";
                //Прокси для вызова методов сервиса
                MTSCommunicatorM2MXMLAPI client = GetSoapService();
                //Получить статус доставки для сообщения
                label3.Text = string.Format("Баланс: " + client.GetBalance(login, password) + " на " + DateTime.Now.ToString("HH:mm:ss dd.MM.yy"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message));
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetBalance(txtLogin.Text, GetMd5Hash(txtPassword.Text));
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            GetBalance(txtLogin.Text, GetMd5Hash(txtPassword.Text));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chkOplata_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
