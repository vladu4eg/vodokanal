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

        private void btnProjectDogovor_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Dogovor dogovor = new Dogovor();
            dogovor.ProjectDogovor(openFileDialog1.FileName);
        }

        private void btnNewDogovor_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Dogovor dogovor = new Dogovor();
            dogovor.CreateDogovor(openFileDialog1.FileName);
        }

        private void btnNewLS_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            LS ls = new LS();
            ls.CreateLS(chkBoxOnlyMKD.Checked, openFileDialog1.FileName);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
       //     Home home = new Home();
       //     home.CreateHome();
        }

        private void btnIPY_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            PY py = new PY();
            py.AddIPY(openFileDialog1.FileName);
            //py.DeleteIPY();
        }

        private void btnODPY_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            PY py = new PY();
            py.AddODPY(openFileDialog1.FileName);
        }

        private void btnDelIPY_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            PY py = new PY();
            py.DeleteIPY(openFileDialog1.FileName);
        }

        private void btnPokaz_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            Pokaz pokaz = new Pokaz();
            pokaz.AddPokazIPY(openFileDialog1.FileName);
            //pokaz.AddPokazODPY(openFileDialog1.FileName);
        }

        private void btnKvit_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Kvit kvit = new Kvit();
            kvit.CreatKvit(openFileDialog1.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            PY py = new PY();
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

        private void btnUpdatePD_Click(object sender, EventArgs e)
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
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ImportGis importGis = new ImportGis();
            importGis.ImportLS(openFileDialog1.FileName);

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnImportDogovor_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ImportGis importGis = new ImportGis();
            importGis.ImpotGis(openFileDialog1.FileName);
        }

        private void btnImportAdress_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ImportGis importGis = new ImportGis();
            importGis.ImportObject(openFileDialog1.FileName);
        }

        private void btnImportPY_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
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
