using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PometkaXP
{
    public partial class Pokaz : Form
    {
        public string zapros;
        MySqlDataReader MyDataReader;
        string Connect = string.Format("Database=CopyPast;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;SslMode=none;default command timeout = 999;Password=" + Protect.PasswordMysql);

        public Pokaz(string inv = null, string vvod_nomer = null)
        {
            zapros = "";
            InitializeComponent();
            if (inv != null)
                zapros = string.Format("where INV_N = '" + inv.ToString() + "' ");
            else if (vvod_nomer != null)
                zapros = string.Format("where vvod_id = '" + vvod_nomer.ToString() + "' ");

            try
            {
                listView1.Clear();
                listView2.Clear();

                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("select inv_n, vvod_id,dest_name, vodom_id,dat_start,dat_end, Pokaz.DAT_IND," +
                    "Pokaz.START_IND,Pokaz.END_IND, total_volm, cntrl_name, Pokaz.USER_NAME, sourceind " +
                    "from Pokaz " +
                    zapros +
                    "order by Pokaz.vodom_id,STR_TO_DATE(Pokaz.DAT_IND,'%d.%m.%Y') ");
                myCommand.Prepare();//подготавливает строку

                MyDataReader = myCommand.ExecuteReader();

                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;


                listView2.View = View.Details;
                listView2.GridLines = true;
                listView2.FullRowSelect = true;

                listView1.Columns.Add("Инвентарный", 130);
                listView1.Columns.Add("Ввод", 110);
                listView1.Columns.Add("Тип", 110);
                listView1.Columns.Add("Номер водомера", 110);
                listView1.Columns.Add("Старт", 110);
                listView1.Columns.Add("Конец", 110);
                listView1.Columns.Add("Дата показ", 110);
                listView1.Columns.Add("СтартПок", 110);
                listView1.Columns.Add("КонечПок", 110);
                listView1.Columns.Add("Кубы", 80);
                listView1.Columns.Add("Контролер?", 110);
                listView1.Columns.Add("Кто проверл", 110);
                listView1.Columns.Add("Статус", 130);

                listView2.Columns.Add("Инвентарный", 130);
                listView2.Columns.Add("Ввод", 110);
                listView2.Columns.Add("Номер водомера", 110);
                listView2.Columns.Add("Тип", 110);
                listView2.Columns.Add("Дата рег", 110);
                listView2.Columns.Add("Тип2", 110);
                listView2.Columns.Add("Дата установки", 110);
                listView2.Columns.Add("СтартПок", 110);
                listView2.Columns.Add("Статус", 110);
                listView2.Columns.Add("Ласт госповерка", 110);
                listView2.Columns.Add("След гос", 110);
                listView2.Columns.Add("Ласт показ", 90);
                listView2.Columns.Add("ЛастКонтрПоказ", 90);
                listView2.Columns.Add("ЛастДатаКонПоказ", 110);
                listView2.Columns.Add("ЛастКонтр", 110);
                listView2.Columns.Add("Адрес", 500);
                listView2.Columns.Add("Коммент", 500);

                string[] arr = new string[13];
                while (MyDataReader.Read())
                {
                    arr[0] = MyDataReader.GetString(0);
                    arr[1] = MyDataReader.GetString(1);
                    arr[2] = MyDataReader.GetString(2);
                    arr[3] = MyDataReader.GetString(3);
                    arr[4] = MyDataReader.GetString(4);
                    arr[5] = MyDataReader.GetString(5);
                    arr[6] = MyDataReader.GetString(6);
                    arr[7] = MyDataReader.GetString(7);
                    arr[8] = MyDataReader.GetString(8);
                    arr[9] = MyDataReader.GetString(9);
                    arr[10] = MyDataReader.GetString(10);
                    arr[11] = MyDataReader.GetString(11);
                    arr[12] = MyDataReader.GetString(12);

                    ListViewItem list = new ListViewItem(arr);
                    listView1.Items.Add(list);
                }

                MyDataReader.Close();

                myCommand.CommandText = string.Format("select vdm.INV_N,vvod_id, id, type_name_r, dat_bidach, dest_name_r, dat_set, start_indication, t_state_name_r, ldat_testing, ndat_testing, last_indication," +
                    "last_ctrlind, ldat_ctrlind, luser_ctrlind," +
                    "concat(rayon_name_r, ', ', trim(vidul_name_sr), vdm.ULICA_NAME_R, ', ', trim(dom_name), ',корп. ', korp, ', кв.', kvart), vdm.utpol " +
                    "from vdm " +
                    zapros +
                    "order by vdm.ID, STR_TO_DATE(vdm.DAT_SET, '%d.%m.%Y'); ");
                myCommand.Prepare();//подготавливает строку

                MyDataReader = myCommand.ExecuteReader();
                arr = new string[17];
                while (MyDataReader.Read())
                {
                    arr[0] = MyDataReader.GetString(0);
                    arr[1] = MyDataReader.GetString(1);
                    arr[2] = MyDataReader.GetString(2);
                    arr[3] = MyDataReader.GetString(3);
                    arr[4] = MyDataReader.GetString(4);
                    arr[5] = MyDataReader.GetString(5);
                    arr[6] = MyDataReader.GetString(6);
                    arr[7] = MyDataReader.GetString(7);
                    arr[8] = MyDataReader.GetString(8);
                    arr[9] = MyDataReader.GetString(9);
                    arr[10] = MyDataReader.GetString(10);
                    arr[11] = MyDataReader.GetString(11);
                    arr[12] = MyDataReader.GetString(12);
                    arr[13] = MyDataReader.GetString(13);
                    arr[14] = MyDataReader.GetString(14);
                    arr[15] = MyDataReader.GetString(15);
                    arr[16] = MyDataReader.GetString(16);
                    ListViewItem list = new ListViewItem(arr);
                    listView2.Items.Add(list);
                }
                MyDataReader.Close();
                myConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

