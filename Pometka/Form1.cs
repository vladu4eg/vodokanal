using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Pometka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlDataReader MyDataReader;
        Excel pometki = new Excel();

        string Connect = string.Format("Database=CopyPast;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;SslMode=none;default command timeout = 999;Password=" + Protect.PasswordMysql);

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Clear();
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
                    listView1.Items.Add( list );
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
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
