using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        static string Connect = string.Format("Database=ignas;Data Source=192.168.27.79;User Id=iguser;charset=cp1251;default command timeout = 999;SslMode=none;Password=  " + Protect.PasswordMysql);
        MySqlConnection myConnection = new MySqlConnection(Connect);
        MySqlCommand myCommand = new MySqlCommand();
        MySqlDataReader MyDataReader;
        long msg;

        public mainForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            label6.Text = " ";
            label9.Text = " ";
            int count_sms = 1;
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = string.Format("select plan_test.licscht,plan_test.phone,plan_test.sms from plan_test " +
                    "where delivery = 0 " +
                    "and sms_id = 0 " +
                    "and length(phone) = 11 " +
                    "and date_format(sendDate, '%Y-%m') = date_format(now(), '%Y-%m'); ");
                myCommand.Prepare();//подготавливает строку
                MyDataReader = myCommand.ExecuteReader();
                //Прокси для вызова методов сервиса
                MTSCommunicatorM2MXMLAPI client = GetSoapService();
                while (MyDataReader.Read())
                {
                    //Послать сообщение
                    msg = client.SendMessage(MyDataReader.GetString(1), MyDataReader.GetString(2), "Vodokanal", txtLogin.Text, GetMd5Hash(txtPassword.Text));
                    //Сформировать запрос 
                    sCommand.Append(string.Format("update plan set sms_id=" + msg + " where licscht='{0}' and phone='{1}' and date_format(sendDate,'%Y-%m')=date_format(now(),'%Y-%m') and sms_id=0; ",
                                                   MyDataReader.GetString(0), MyDataReader.GetString(1)));
                    label9.Text = Convert.ToString(string.Format("Отправлено: {0}",count_sms++));
                }
                MyDataReader.Close();
                //Подготавливаем и выполняем
                myCommand.CommandText = sCommand.ToString();
                myCommand.Prepare();
                myCommand.ExecuteNonQuery();
                
                myConnection.Close();
                sCommand.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message));
            }
            stopwatch.Stop();
            label3.Text = string.Format("Время отправки СМС: " + stopwatch.Elapsed);
            stopwatch.Reset();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            label6.Text = " ";
            try
            {
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = string.Format("select plan_test.licscht,plan_test.phone,plan_test.sms from plan_test " +
                    "where delivery = 0 " +
                    "and sms_id = 0 " +
                    "and length(phone) = 11 " +
                    "and date_format(sendDate, '%Y-%m') = date_format(now(), '%Y-%m'); ");
                myCommand.Prepare();//подготавливает строку
                MyDataReader = myCommand.ExecuteReader();

                long id = -1;
                int status = 0;
                while (MyDataReader.Read())
                {
                    if (long.TryParse(MyDataReader.GetString(1), out id))
                    {
                        //Прокси для вызова методов сервиса
                        MTSCommunicatorM2MXMLAPI client = GetSoapService();
                        //Получить статус доставки для сообщения
                        DeliveryInfo[] info = client.GetMessageStatus(id, txtLogin.Text, GetMd5Hash(txtPassword.Text));
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < info.Length; i++)
                        {
                            switch (info[i].DeliveryStatus.ToString())
                            {
                                case "Pending":
                                case "Sending":
                                case "Sent":
                                case "NotSent":
                                    status = 0;
                                    break;

                                case "Delivered":
                                    status = 1;
                                    break;
                                case "NotDelivered":
                                case "TimedOut":
                                case "Error":
                                    status = 2;
                                    break;

                                default:
                                    break;
                            }
                            sb.AppendFormat("update plan set delivery='{0}', delivery_type='{1}', reciveDate='{2}' where sms_id='{3}'; ", 
                                status,  info[i].DeliveryStatus, info[i].DeliveryDate, info[i].Msid);
                        }

                    }
                    else
                        MessageBox.Show("Can't parse id: '{0}'", MyDataReader.GetString(1));
                }
                MyDataReader.Close();

                myCommand.CommandText = sCommand.ToString();
                myCommand.Prepare();
                myCommand.ExecuteNonQuery();

                myConnection.Close();
                sCommand.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message));
            }

            stopwatch.Stop();
            label3.Text = string.Format("Время проверки доставки: " + stopwatch.Elapsed);
            stopwatch.Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopwatch.Start();

            label6.Text = " ";
            label3.Text = " ";
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Import import = new Import();
            label6.Text = import.ImportBD(openFileDialog1.FileName, openFileDialog1.SafeFileName, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);

            stopwatch.Stop();
            label3.Text = string.Format("Время обработки: " + stopwatch.Elapsed);
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

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
