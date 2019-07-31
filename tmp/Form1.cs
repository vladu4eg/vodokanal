using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tmp
{
    public partial class Form1 : Form
    {
        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999999;Password=vlad19957");
        MySqlDataReader MyDataReader;
        string tmp;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ImportGis importGis = new ImportGis();
            importGis.ImportLS(openFileDialog1.FileName);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            this.Text = listBox1.SelectedItem.ToString();
            while (dataGridView1.Rows.Count > 1)
            {
                dataGridView1.Rows.RemoveAt(0);
            }

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(@"select tmp_TY_pokaz.data, tmp_TY_pokaz.pokaz from tmp_TY_pokaz where adress = '{0}' order by data", listBox1.SelectedItem);
            myCommand.Prepare();
            MyDataReader = myCommand.ExecuteReader();

            int i = 0;
            while (MyDataReader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = MyDataReader.GetString(0);
                dataGridView1[1, i].Value = MyDataReader.GetString(1);
                i++;
            }
            tmp = listBox1.SelectedItem.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(@"select distinct adress from tmp_TY where adress like '%{0}%'", textBox1.Text.ToString());
            myCommand.Prepare();
            MyDataReader = myCommand.ExecuteReader();

            while (MyDataReader.Read())
            {
                listBox1.Items.Add(MyDataReader.GetString(0));
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;
            for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                myCommand.CommandText = string.Format(@"update tmp_TY_pokaz set tmp_TY_pokaz.pokaz = {0}, volume = {3} where tmp_TY_pokaz.adress = '{1}' and tmp_TY_pokaz.`data` = '{2}'; ", dataGridView1[1, i].Value.ToString(), tmp, dataGridView1[0, i].Value.ToString(), Convert.ToInt32(dataGridView1[1, i+1].Value) - Convert.ToInt32(dataGridView1[1, i].Value));
                myCommand.Prepare();
                myCommand.ExecuteNonQuery();
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
