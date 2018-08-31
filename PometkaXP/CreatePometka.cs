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
    public partial class CreatePometka : Form
    {
        int count = 0;
        string Connect = string.Format("Database=CopyPast;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;SslMode=none;default command timeout = 999;Password=" + Protect.PasswordMysql);
        public CreatePometka(string ls)
        {
            InitializeComponent();
            textBox2.Text = ls;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 form = new Form1();
                MySqlConnection myConnection = new MySqlConnection(Connect);
                MySqlCommand myCommand = new MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("INSERT INTO Pometka VALUES ('{0}',trim('{1}'),'{2}',null,1) ", textBox2.Text.ToString(), DateTime.Now.ToString("dd.MM.yyyy"), textBox1.Text);
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();

                textBox1.Clear();
                labCount.Text = Convert.ToString(count = 0);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labCount_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((count < 3000 && count >= 0 ) && e.KeyChar != (char)Keys.Back)
            {
                count++;
                labCount.Text = Convert.ToString(count);
            }
            else if ((count < 3000 && count > 0 ) && e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                count--;
                labCount.Text = Convert.ToString(count);
            }
            else
                e.Handled = true;
        }
    }
}
