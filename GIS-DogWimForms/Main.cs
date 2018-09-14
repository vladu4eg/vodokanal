using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    public partial class Main : Form
    {
        Update update = new Update();
        // класс protect содержит только две переменные PasswordOracle и PasswordMysql.
        public Main()
        {

            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dogovor dogovor = new Dogovor();
            dogovor.ProjectDogovor();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Dogovor dogovor = new Dogovor();
            dogovor.CreateDogovor();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LS ls = new LS();
            ls.CreateLS(chkBoxOnlyMKD.Checked);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.CreateHome();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PY py = new PY();
            py.AddIPY();
        }

        private void btnPokaz_Click(object sender, EventArgs e)
        {
            Pokaz pokaz = new Pokaz();
            Update update = new Update();

            update.UpdateClearPY();
            update.UpdatePY();

            pokaz.AddPokazIPY();
            pokaz.AddPokazODPY();
        }

        private void btnKvit_Click(object sender, EventArgs e)
        {
            Kvit kvit = new Kvit();
            kvit.CreatKvit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PY py = new PY();
            py.PyFIX();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Дал бог зайку, даст и доступ к бд. P.S. Данный метод используется только для импорта данных из БД
            // update.UpdateAll(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdAdressOnly_Click(object sender, EventArgs e)
        {
            update.UpdateClearAdress();

            // Дал бог зайку, даст и доступ к бд. P.S. Данный метод используется только для импорта данных из БД
            //update.UpdateAdress();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update.UpdateClearPD();

            // Дал бог зайку, даст и доступ к бд. P.S. Данный метод используется только для импорта данных из БД
            //update.UpdatePD();
        }

        private void ChkBoxOnlyMKD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClearGis_Click(object sender, EventArgs e)
        {
            update.UpdateClearAllGis();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void btnImportLS_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ImportGis importGis = new ImportGis();
            importGis.ImportLS(openFileDialog1.FileName);

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ImportGis importGis = new ImportGis();
            importGis.ImpotGis(openFileDialog1.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ImportGis importGis = new ImportGis();
            importGis.ImportObject(openFileDialog1.FileName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ImportGis importGis = new ImportGis();
            importGis.ImportPY(openFileDialog1.FileName);
        }

        private void buttonImportLS_Click(object sender, EventArgs e)
        {

        }

        private void buttonImportWith_Click(object sender, EventArgs e)
        {

        }

        private void buttonImportPY_Click(object sender, EventArgs e)
        {

        }

        private void buttonImportPD_Click(object sender, EventArgs e)
        {

        }
    }
}
