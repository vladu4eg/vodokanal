using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SMS
{
    public partial class Form1 : Form
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        public Form1()
        {
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            stopwatch.Start();

            label1.Text = "";
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Import import = new Import();
            label1.Text = import.ImportBD(openFileDialog1.FileName, openFileDialog1.SafeFileName, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);

            stopwatch.Stop();
            label3.Text = string.Format("Время обработки: " + stopwatch.Elapsed);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
