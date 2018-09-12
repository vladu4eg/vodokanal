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

        public void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Clear();
                listView2.Clear();
                txtBoxFIO.Clear();
                txtBoxSaldo.Clear();
                txtBoxBlago.Clear();
                txtBoxKolJil.Clear();
                txtBoxKolLGO.Clear();
                txtBoxProcLGO.Clear();
                txtBoxObsl.Clear();
                txtBoxStatus.Clear();
                txtBoxVvod2.Clear();
                txtBoxVvod.Clear();
                txtBoxAdress.Clear();

                if (txtBoxLS.Text.ToString() != "")
                {
                    MySqlConnection myConnection = new MySqlConnection(Connect);
                    MySqlCommand myCommand = new MySqlCommand();
                    myConnection.Open();
                    myCommand.Connection = myConnection;

                    myCommand.CommandText = string.Format("select * from Pometka where Pometka.LS = " + txtBoxLS.Text.ToString() + " order by STR_TO_DATE(Pometka.DATA,'%d.%m.%Y')");
                    myCommand.Prepare();//подготавливает строку
                    MyDataReader = myCommand.ExecuteReader();

                    listView1.View = View.Details;
                    listView1.GridLines = true;
                    listView1.FullRowSelect = true;

                    listView1.Columns.Add("id", 2);
                    listView1.Columns.Add("Дата", 100);
                    listView1.Columns.Add("Текст", 1000);

                    string[] arr = new string[3];
                    while (MyDataReader.Read())
                    {
                        arr[0] = MyDataReader.GetString(3);
                        arr[1] = MyDataReader.GetString(1);
                        arr[2] = MyDataReader.GetString(2);

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
                        "V_EXT_LICSCHT.STLSCHT_NAME_R, " +
                        "V_EXT_LICSCHT.VVOD_ID, " +
                        "V_EXT_LICSCHT.FULL_ADDR " +
                        "FROM V_EXT_LICSCHT " +
                        "WHERE V_EXT_LICSCHT.L_SCHET = " + txtBoxLS.Text.ToString() + " ;");
                    myCommand.Prepare();//подготавливает строку
                    MyDataReader = myCommand.ExecuteReader();

                    while (MyDataReader.Read())
                    {
                        txtBoxFIO.Text = MyDataReader.GetString(0);
                        txtBoxSaldo.Text = MyDataReader.GetString(1);
                        txtBoxBlago.Text = MyDataReader.GetString(2);
                        txtBoxKolJil.Text = MyDataReader.GetString(3);
                        txtBoxKolLGO.Text = MyDataReader.GetString(4);
                        txtBoxProcLGO.Text = MyDataReader.GetString(5);
                        txtBoxObsl.Text = MyDataReader.GetString(6);
                        txtBoxStatus.Text = MyDataReader.GetString(7);
                        txtBoxVvod.Text = MyDataReader.GetString(8);
                        txtBoxVvod2.Text = MyDataReader.GetString(8);
                        txtBoxAdress.Text = MyDataReader.GetString(9);
                    }
                    MyDataReader.Close();
                    myCommand.CommandText = string.Format("select * from saldo where LS = " + txtBoxLS.Text.ToString() + " order by STR_TO_DATE(saldo.DATA,'%d.%m.%Y')");
                    myCommand.Prepare();//подготавливает строку
                    MyDataReader = myCommand.ExecuteReader();

                    listView2.View = View.Details;
                    listView2.GridLines = true;
                    listView2.FullRowSelect = true;

                    listView2.Columns.Add("Дата", 100);
                    listView2.Columns.Add("Сальдо", 100);

                    string[] arr1 = new string[2];
                    while (MyDataReader.Read())
                    {
                        arr1[0] = MyDataReader.GetString(1);
                        arr1[1] = MyDataReader.GetString(2);
                        ListViewItem list = new ListViewItem(arr1);
                        listView2.Items.Add(list);
                    }
                    MyDataReader.Close();
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string query = "Вы действительно хотите удалить пометку безвозвратно за " + listView1.SelectedItems[0].SubItems[1].Text + "?";
                if (MessageBox.Show(query, "Удалить пометку!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        MySqlConnection myConnection = new MySqlConnection(Connect);
                        MySqlCommand myCommand = new MySqlCommand();
                        myConnection.Open();
                        myCommand.Connection = myConnection;

                        myCommand.CommandText = string.Format("delete from Pometka where id = " + listView1.SelectedItems[0].SubItems[0].Text + " and flag = 1;");
                        myCommand.Prepare();//подготавливает строку
                        myCommand.ExecuteNonQuery();
                        buttonSearch_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void txtBoxNomerVDM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number == (char)Keys.Enter)
                button3_Click(sender, e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number == (char)Keys.Enter)
                buttonSearch_Click(sender, e);
            else if (number == (char)Keys.Back)
                e.Handled = false;
            else if (!Char.IsDigit(number))
                e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number == (char)Keys.Enter)
                button2_Click_1(sender, e);
            else if (number == (char)Keys.Back)
                e.Handled = false;
            else if (!Char.IsDigit(number))
                e.Handled = true;
        }

        private void btnNewPometka_Click(object sender, EventArgs e)
        {
            CreatePometka pometka = new CreatePometka(txtBoxLS.Text.ToString());
            pometka.Show();
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            TextPoemtka pometka = new TextPoemtka(listView1.SelectedItems[0].SubItems[2].Text);
            pometka.Show();
            //MessageBox.Show(listView1.SelectedItems[0].SubItems[2].Text);
        }

        private void txtBoxVvod_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number == (char)Keys.Enter)
                button4_Click(sender, e);
            else if (number == (char)Keys.Back)
                e.Handled = false;
            else if (!Char.IsDigit(number))
                e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pokaz pokaz = new Pokaz(txtBoxNomerVDM.Text.ToString());
            pokaz.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Квитанции kvit = new Квитанции(txtBoxLSKvit.Text.ToString(), txtBoxSumKvit.Text.ToString());
            kvit.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pokaz pokaz = new Pokaz(null, txtBoxVvod.Text.ToString());
            pokaz.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtBoxVvod_TextChanged(object sender, EventArgs e)
        {

        }


        private void listView1_Click(object sender, EventArgs e)
        {

        }



        private void txtBoxAdress_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
