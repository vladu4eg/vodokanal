using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PometkaXP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlDataReader MyDataReader;
        Csv importFile = new Csv();
        List<string> Rows = new List<string>();

        string Connect = string.Format("Database=CopyPast;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;SslMode=none;default command timeout = 999;Password=" + Protect.PasswordMysql);

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();

                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("select * from Pometka where Pometka.LS = " + textBox1.Text.ToString() + " order by STR_TO_DATE(Pometka.DATA,'%d.%m.%Y')");
                myCommand.Prepare();//подготавливает строку


                MyDataReader = myCommand.ExecuteReader();

                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;

                listView1.Columns.Add("Дата", 100);
                listView1.Columns.Add("Текст", 7000);
                string[] arr = new string[2];
                while (MyDataReader.Read())
                {
                    arr[0] = MyDataReader.GetString(1);
                    arr[1] = MyDataReader.GetString(2);
                    ListViewItem list = new ListViewItem(arr);
                    listView1.Items.Add(list);
                }

                MyDataReader.Close();

                myCommand.CommandText = string.Format("SELECT V_EXT_LICSCHT.FULL_FIO," +
                    "V_EXT_LICSCHT.DOLG," +
                    "V_EXT_LICSCHT.STBLAG_NAME_R," +
                    "V_EXT_LICSCHT.KOL_GIL," +
                    "V_EXT_LICSCHT.KOL_LGO," +
                    "V_EXT_LICSCHT.PROC_LGO," +
                    "V_EXT_LICSCHT.OBSL_NAME_R," +
                    "V_EXT_LICSCHT.STLSCHT_NAME_R " +
                    "FROM V_EXT_LICSCHT " +
                    "WHERE V_EXT_LICSCHT.L_SCHET = " + textBox1.Text.ToString() + " ;");
                myCommand.Prepare();//подготавливает строку
                MyDataReader = myCommand.ExecuteReader();

                while (MyDataReader.Read())
                {
                    textBox2.Text = MyDataReader.GetString(0);
                    textBox3.Text = MyDataReader.GetString(1);
                    textBox4.Text = MyDataReader.GetString(2);
                    textBox5.Text = MyDataReader.GetString(3);
                    textBox6.Text = MyDataReader.GetString(4);
                    textBox7.Text = MyDataReader.GetString(5);
                    textBox8.Text = MyDataReader.GetString(6);
                    textBox9.Text = MyDataReader.GetString(7);
                }

                MyDataReader.Close();
                myConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* 
            * char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
            */
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pokaz pokaz = new Pokaz(textBox10.Text.ToString());
            pokaz.Show();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Квитанции kvit = new Квитанции(textBox11.Text.ToString(), textBox13.Text.ToString());
            kvit.Show();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
