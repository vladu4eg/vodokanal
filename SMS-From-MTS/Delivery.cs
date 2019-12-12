using M2MSOAPSample.M2MSoapService;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace M2MSOAPSample
{
    class Delivery
    {
        StringBuilder sCommand = new StringBuilder();
        static string Connect = string.Format("Database=ignas;Data Source=192.168.27.79;User Id=iguser;charset=cp1251;default command timeout = 99999999;Connect Timeout = 99999999;SslMode=none;Password=  " + Protect.PasswordMysql);
        MySqlConnection myConnection = new MySqlConnection(Connect);
        MySqlCommand myCommand = new MySqlCommand("set net_write_timeout=99999999; set net_read_timeout=99999999");
        MySqlDataReader MyDataReader;
        List<string> list = new List<string>();

        public string GetList(string txtLogin, string txtPassword)
        {
            sCommand.Clear();

            int countStatus0 = 0;
            int countStatus1 = 0;
            int countStatus2 = 0;
            int status = 0;
            list.Clear();

            try
            {
                mainForm main = new mainForm();
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = string.Format(@"select plan.sms_id from plan 
                    where delivery = 0 
                    and sms_id <> 0 
                    and length(phone) = 11 
                    and (date_format(sendDate, '%Y-%m') = date_format(now(), '%Y-%m') 
				    or date_format(sendDate, '%Y-%m') = date_format(now() - INTERVAL 1 MONTH, '%Y-%m')); ");
                myCommand.Prepare();//подготавливает строку
                MyDataReader = myCommand.ExecuteReader();

                //Прокси для вызова методов сервиса
                MTSCommunicatorM2MXMLAPI client = main.GetSoapService();
                while (MyDataReader.Read())
                {
                    list.Add(MyDataReader.GetString(0));
                }
                MyDataReader.Close();

                for (int i = 0; i < list.Count; i++)
                {
                    //Получить статус доставки для сообщения
                    DeliveryInfo[] info = client.GetMessageStatus(Convert.ToInt64(list[i]), txtLogin, txtPassword);

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

                    sCommand.Append(string.Format("update plan set delivery='{0}', delivery_type='{1}', reciveDate='{2}' where sms_id={3}; ",
                        status, info[0].DeliveryStatus, info[0].DeliveryDate.ToString("yyyy-MM-dd HH:mm:ss"), list[i]));

                    if ((countStatus0 + countStatus1 + countStatus2) % 1000 == 0)
                    {
                        myCommand.CommandText = sCommand.ToString();
                        myCommand.Prepare();
                        myCommand.ExecuteNonQuery();
                        sCommand.Clear();
                    }
                }

                //Подготавливаем и выполняем
                myCommand.CommandText = sCommand.ToString();
                myCommand.Prepare();
                myCommand.ExecuteNonQuery();

                myConnection.Close();
                sCommand.Clear();

                return string.Format("Доставлено:\n" +
                        "В ожид.: {0}\n" +
                        "Получ.: {1}\n" +
                        "Ошибка: {2}\n" +
                        "Всего: {3}\n", countStatus0, countStatus1, countStatus2, (countStatus0 + countStatus1 + countStatus2));

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message));
                myConnection.Close();
                return string.Format("Доставлено:\n" +
                        "В ожид.: {0}\n" +
                        "Получ.: {1}\n" +
                        "Ошибка: {2}\n" +
                        "Всего: {3}\n", countStatus0, countStatus1, countStatus2, (countStatus0 + countStatus1 + countStatus2));
            }
        }
    }
}
