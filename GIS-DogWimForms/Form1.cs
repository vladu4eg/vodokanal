using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace GIS_DogWimForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Excel GisExport = new Excel();
        public Excel BDExport = new Excel();

        private void button1_Click(object sender, EventArgs e)
        {
            GisExport.Rows.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "Выберите документ для загрузки данных";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Загрузка данных...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                GisExport.FileOpen(ofd.FileName);
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BDExport.Rows.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "Выберите документ для загрузки данных";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Загрузка данных...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BDExport.FileOpen(ofd.FileName);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            List<string> ListGis = new List<string>();
            List<string> ListBD = new List<string>();
            List<string> temp = new List<string>();
            if (String.IsNullOrEmpty(textBox1.Text))
                MessageBox.Show("Введите номер столбца в ГИС!");
            else if (String.IsNullOrEmpty(textBox2.Text))
                MessageBox.Show("Введите номер столбца в BD!");
            else if (BDExport.Rows.Count <= 0)
                MessageBox.Show("Загрузите экспорт БД");
            else if (GisExport.Rows.Count <= 0)
                MessageBox.Show("Загрузите экспорт ГИС");
            else if (GisExport.Rows.Count < Convert.ToInt32(textBox1.Text))
                MessageBox.Show("Нет такого столбца");
            else
            {
                for (int i = 0; i < GisExport.Rows.Count; i++)
                    ListGis.Add(GisExport.Rows[i][Convert.ToInt32(textBox1.Text)]);
                for (int i = 0; i < BDExport.Rows.Count; i++)
                    ListBD.Add(BDExport.Rows[i][Convert.ToInt32(textBox1.Text)]);
               temp = ListGis.Except(ListBD);

            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> ListDouble = new List<string>();
            listBox1.Items.Clear();
            if (String.IsNullOrEmpty(textBox1.Text))
                MessageBox.Show("Введите номер столбца в ГИС!");
            else if (GisExport.Rows.Count <= 0)
                MessageBox.Show("Загрузите экспорт ГИС");
            else if (GisExport.Rows.Count < Convert.ToInt32(textBox1.Text)) ///ОШИБКА!!!!!
                MessageBox.Show("Нет такого столбца");
            else
            {
                for (int i = 0; i < GisExport.Rows.Count; i++)
                    ListDouble.Add(GisExport.Rows[i][Convert.ToInt32(textBox1.Text)]);
                listBox1.Items.Add(string.Join(" ", ListDouble.Where(x => ListDouble.Count(y => x == y) > 1).Distinct()));
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
