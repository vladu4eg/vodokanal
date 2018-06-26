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
    public partial class Квитанции : Form
    {
        public string ls;
        public string summ;
        MySqlDataReader MyDataReader;
        string Connect = string.Format("Database=CopyPast;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;SslMode=none;default command timeout = 999;Password=" + Protect.PasswordMysql);


        public Квитанции(string in_ls, string in_summ)
        {
            InitializeComponent();
            ls = "";
            summ = "";
            ls = in_ls;

            if(in_summ != "")
            summ = string.Format("and kvit.SUM_TOTAL = '" + in_summ + "' ");

            try
            {
                listView1.Clear();
                listView1.Clear();

                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("select kvit.LIC_SCHT_ID,kvit.ID,kvit.SUM_TOTAL,kvit.DAT_BIDACH,kvit.DAT_FIKSAC,kvit.T_UNIT,kvit.T_KVIT,kvit.T_STATE," +
                    "V_PACH_BANK_INP.ID, V_PACH_BANK_INP.ORGAN_N, V_PACH_BANK_INP.BANK_N, V_PACH_BANK_INP.DAT_PLAT, V_PACH_BANK_INP.DAT_POLD, V_PACH_BANK_INP.PRIN_SUM," +
                    "V_PACH_BANK_INP.BKOL_KVIT, V_PACH_BANK_INP.CNT_PPP, V_PACH_BANK_INP.CNT_PPP_KVI," +
                    "V_PACH_BANK_INP.SUM_PPP_KVI, V_PACH_BANK_INP.CNT_OUT_KVI, V_PACH_BANK_INP.SUM_OUT_KVI," +
                    "V_PACH_BANK_INP.DPOL_BUH, V_PACH_BANK_INP.T_STATE_N, V_PACH_BANK_INP.USER_NAME," +

                    "V_PACH_PP_INP.ID, V_PACH_PP_INP.HARD_CODE, V_PACH_PP_INP.ORGAN_N," +
                    "V_PACH_PP_INP.NOMER, V_PACH_PP_INP.BKOL_KVIT, V_PACH_PP_INP.BANK_SUM, " +
                    "V_PACH_PP_INP.T_STATE_N, V_PACH_PP_INP.USER_NAME " +

                    "from kvit, V_PACH_PP_INP, V_PACH_BANK_INP " +
                    "where kvit.LIC_SCHT_ID = '" + ls +"' " +
                    "and kvit.PPP_ID = V_PACH_PP_INP.ID " +
                    "and V_PACH_PP_INP.PACH_ID = V_PACH_BANK_INP.ID " +
                    summ +
                    "order by STR_TO_DATE(DAT_BIDACH,'%d.%m.%Y');");
                myCommand.Prepare();//подготавливает строку

                MyDataReader = myCommand.ExecuteReader();

                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;

                listView1.Columns.Add("ЛС", 100);
                listView1.Columns.Add("ID", 80);
                listView1.Columns.Add("СуммКвит", 80);
                listView1.Columns.Add("Дата", 80);
                listView1.Columns.Add("ДатаФиксации", 80);
                listView1.Columns.Add("Валюта", 80);
                listView1.Columns.Add("Статус", 80);
                listView1.Columns.Add("Стайт", 80);

                listView1.Columns.Add("Номер пачки", 80);
                listView1.Columns.Add("Орг", 80);
                listView1.Columns.Add("Банк", 100);
                listView1.Columns.Add("ДатаПлат", 100);
                listView1.Columns.Add("ДатаПолд", 100);
                listView1.Columns.Add("Сумма", 100);
                listView1.Columns.Add("КолКвит", 80);
                listView1.Columns.Add("КолПодпачек", 80);
                listView1.Columns.Add("КолПодКвит", 80);
                listView1.Columns.Add("СуммаПодКвит", 80);
                listView1.Columns.Add("ЧужКвит", 80);
                listView1.Columns.Add("ЧужСумм", 80);
                listView1.Columns.Add("ДПолБух", 80);
                listView1.Columns.Add("Статус", 80);
                listView1.Columns.Add("Кто пачку :)", 80);

                listView1.Columns.Add("Номер подпачки", 80);
                listView1.Columns.Add("?????", 80);
                listView1.Columns.Add("Орган", 80);
                listView1.Columns.Add("Номер", 80);
                listView1.Columns.Add("БанкКол", 80);
                listView1.Columns.Add("БанкСумм", 80);
                listView1.Columns.Add("Статус", 80);
                listView1.Columns.Add("Кто подпачку?", 80);

                string[] arr = new string[31];
                while (MyDataReader.Read())
                {
                    for(int i = 0; i < 31; i++)
                        arr[i] = MyDataReader.GetString(i);

                    ListViewItem list = new ListViewItem(arr);
                    listView1.Items.Add(list);
                }

                MyDataReader.Close();
                myConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void Kvit_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
