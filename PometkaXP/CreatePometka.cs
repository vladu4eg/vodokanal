using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PometkaXP
{
    public partial class CreatePometka : Form
    {
        string Connect = string.Format("Database=CopyPast;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;SslMode=none;default command timeout = 999;Password=" + Protect.PasswordMysql);
        public CreatePometka(string ls)
        {
            InitializeComponent();
            textBox2.Text = ls;
            ToolTip t = new ToolTip();
            t.SetToolTip(labelSecKey, "Необходимо придумать секретное слово,\nчтобы вашу пометку могли удалить только вы.\nСекретное слово должно быть одно для всех пометок\nРекомендую фамилию :)");
            t.SetToolTip(labCount, "Максимальное количество символов 3000");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.ToString() != "" || textBox1.Text.ToString() != "" || textBox3.Text.ToString() != "")
                {
                    MySqlConnection myConnection = new MySqlConnection(Connect);
                    MySqlCommand myCommand = new MySqlCommand();
                    myConnection.Open();
                    myCommand.Connection = myConnection;

                    myCommand.CommandText = string.Format("INSERT INTO Pometka VALUES ('{0}',trim('{1}'),'{2}',null,1,'{3}') ", textBox2.Text.ToString(), DateTime.Now.ToString("dd.MM.yyyy"), textBox1.Text.ToString(), textBox3.Text.ToUpper());
                    myCommand.Prepare();//подготавливает строку
                    myCommand.ExecuteNonQuery();

                    textBox1.Clear();
                    labCount.Text = "0";
                    MessageBox.Show("Готово!\nОбновите пометки на лицевом :)");
                    myConnection.Close();
                }
                else
                    MessageBox.Show("Заполните ЛС и/или текс пометки и/или секретное слово!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            labCount.Text = textBox1.Text.Length.ToString(CultureInfo.InvariantCulture);
        }

        private void labCount_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSecKey_Click(object sender, EventArgs e)
        {

        }
    }
}
