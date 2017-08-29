using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    public partial class TableWork : Form
    {
        public TableWork()
        {
            InitializeComponent();
        }
        public Excel ShablonExcel = new Excel();

        private void button1_Click(object sender, EventArgs e)
        {
            ShablonExcel.Rows.Clear();
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
                //ShablonExcel.FileOpen(ofd.FileName, 1, textBox2.Text);
                MessageBox.Show("Готово! Шаблон");
                for (int x = 0; x < ShablonExcel.Rows[1].Count; x++)
                {
                    DataGridViewTextBoxColumn Column = new DataGridViewTextBoxColumn();
                    Column.Name = ShablonExcel.Rows[0][x] + ShablonExcel.Rows[1][x];
                    dataGridView1.Columns.Add(Column);
                }
                for (int i = 0; i < ShablonExcel.Rows.Count - 2; i++)
                    dataGridView1.Rows.Add(1);

                for (int i = 2; i < ShablonExcel.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1[j, i - 2].Value = ShablonExcel.Rows[i][j];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int x = 0; x < Form1.BDExport.Rows[1].Count; x++)
                {
                    DataGridViewTextBoxColumn Column = new DataGridViewTextBoxColumn();
                    Column.Name = Form1.BDExport.Rows[0][x];
                    dataGridView2.Columns.Add(Column);
                }
                for (int i = 0; i < Form1.BDExport.Rows.Count - 1; i++)
                    dataGridView2.Rows.Add(1);

                for (int i = 1; i < Form1.BDExport.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        dataGridView2[j, i - 1].Value = Form1.BDExport.Rows[i][j];
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
