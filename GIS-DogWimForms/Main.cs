using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    public partial class Main : Form
    {
        UpdateOracle update = new UpdateOracle();
        Clear clear = new Clear();
        ImportGis importGis = new ImportGis();
        // класс protect содержит только две переменные PasswordOracle и PasswordMysql.
        public Main()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Дал бог зайку, даст и доступ к бд. P.S. Данный метод используется только для импорта данных из БД
            // update.UpdateAll(); 
        }

        private void btnUpdAdressOnly_Click(object sender, EventArgs e)
        {
            //clear.Adress();

            // Дал бог зайку, даст и доступ к бд. P.S. Данный метод используется только для импорта данных из БД
            //update.UpdateAdress();
        }

        private void btnUpdatePD_Click(object sender, EventArgs e)
        {
            //clear.PD();
            // Дал бог зайку, даст и доступ к бд. P.S. Данный метод используется только для импорта данных из БД
            //update.UpdatePD();
        }


        private void btnClearGis_Click(object sender, EventArgs e)
        {
            clear.AllGis();
        }

        private void btnImportLS_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            clear.GisLS("gis_ls");
            importGis.ImportLS(openFileDialog1.FileName, "gis_ls");

        }

        private void btnImportDogovor_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            clear.GisDogovor();
            importGis.ImpotGis(openFileDialog1.FileName);
        }

        private void btnImportAdress_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            clear.GisAdress();
            importGis.ImportObject(openFileDialog1.FileName);
        }

        private void btnImportPY_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            UpdateOracle update = new UpdateOracle();
            clear.GisPY();
            importGis.ImportPY(openFileDialog1.FileName);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (Object item in chdListBoxCreate.CheckedItems)
            {
                if (chdListBoxCreate.Items.IndexOf(item) == 0)
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog1.FileName = "DogovorProject";
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    Dogovor dogovor = new Dogovor();
                    dogovor.ProjectDogovor(openFileDialog1.FileName);
                }
                else if (chdListBoxCreate.Items.IndexOf(item) == 1)
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog1.FileName = "DogovorCreate";
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    Dogovor dogovor = new Dogovor();
                    dogovor.CreateDogovor(openFileDialog1.FileName);
                }
                else if (chdListBoxCreate.Items.IndexOf(item) == 2)
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog1.FileName = "Home";
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    Home home = new Home();
                    home.CreateHome(openFileDialog1.FileName);
                }
                else if (chdListBoxCreate.Items.IndexOf(item) == 3)
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog1.FileName = "LS";
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    LS ls = new LS();
                    ls.CreateLS(false, openFileDialog1.FileName, "gis_ls");
                }
                else if (chdListBoxCreate.Items.IndexOf(item) == 4)
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog1.FileName = "IPY";
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    PY py = new PY();
                    py.AddIPY(openFileDialog1.FileName);
                }
                else if (chdListBoxCreate.Items.IndexOf(item) == 5)
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog1.FileName = "DeleteIPY";
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    PY py = new PY();
                    py.DeleteIPY(openFileDialog1.FileName);
                }
                else if (chdListBoxCreate.Items.IndexOf(item) == 6)
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog1.FileName = "PokazPY";
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;

                    Pokaz pokaz = new Pokaz();
                    pokaz.AddPokazIPY(openFileDialog1.FileName);
                    //pokaz.AddPokazODPY(openFileDialog1.FileName);
                }
                else if (chdListBoxCreate.Items.IndexOf(item) == 7)
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog1.FileName = "ODPY";
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    PY py = new PY();
                    py.AddODPY(openFileDialog1.FileName);
                }
                else if (chdListBoxCreate.Items.IndexOf(item) == 8)
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog1.FileName = "Kvit";
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    Kvit kvit = new Kvit();
                    kvit.CreatKvit(openFileDialog1.FileName);
                }
                else if (chdListBoxCreate.Items.IndexOf(item) == 9)
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog1.FileName = "Pay";
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    Pay pay = new Pay();
                    pay.Kassa(openFileDialog1.FileName);
                }
                else if (chdListBoxCreate.Items.IndexOf(item) == 10)
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    openFileDialog1.FileName = "LS";
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    LS ls = new LS();
                    ls.CreateLS(false, openFileDialog1.FileName, "");
                }
            }
        }

        private void btnImportMB_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                string data = DateTime.Now.ToString("yyyyMMdd");
                DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                UpdateMegaBilling update = new UpdateMegaBilling();
                foreach (var item in dir.GetFiles())
                {
                    if (item.Name == "jalta_wat_dogovor_" + data + ".txt")
                    {
                        update.SendToBD(item.FullName, "mb_dogovor");
                    }
                    else if (item.Name == "jalta_wat_ipu_" + data + ".txt")
                    {
                        update.SendToBD(item.FullName, "mb_ipy");
                    }
                    else if (item.Name == "jalta_wat_bill_99_" + data + ".txt")
                    {
                        update.SendToBD(item.FullName, "mb_buh");
                    }
                    else if (item.Name == "jalta_wat_ls_" + data + ".txt")
                    {
                        update.SendToBD(item.FullName, "mb_ls");
                    }
                    else if (item.Name == "jalta_wat_houses_" + data + ".txt")
                    {
                        update.SendToBD(item.FullName, "mb_house");
                    }
                    else if (item.Name == "jalta_wat_odpy_" + data + ".txt")
                    {
                        update.SendToBD(item.FullName, "mb_odpy");
                    }
                    else if (item.Name == "jalta_wat_link_" + data + ".txt")
                    {
                        update.SendToBD(item.FullName, "mb_ls_odpy");
                    }
                    else if (item.Name == "jalta_wat_plat_" + data + ".txt")
                    {
                        update.SendToBD(item.FullName, "mb_pay");
                    }
                    else if (item.Name == "jalta_wat_uslugi_" + data + ".txt")
                    {
                        update.SendToBD(item.FullName, "mb_uslugi");
                    }
                    else if (item.Name.Length >= 20)
                    {
                        if (item.Name.Substring(0, 16) == "jalta_wat_pokazo" && item.Name.Substring(20) == data + ".txt")
                        {
                            update.SendToBD(item.FullName, "mb_pokaz_odpy");
                        }
                        else if (item.Name.Substring(0, 14) == "jalta_wat_dolg" && item.Name.Substring(18) == data + ".txt")
                        {
                            update.SendToBD(item.FullName, "mb_dolg");
                        }
                        else if (item.Name.Substring(0, 16) == "jalta_wat_pokazi" && item.Name.Substring(20) == data + ".txt")
                        {
                            update.SendToBD(item.FullName, "mb_pokaz_ipy");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFIAS_Click(object sender, EventArgs e)
        {
            //имеет жесткую зависимость! Будь осторожен! 
            UpdateOracle update_adress = new UpdateOracle();
            update_adress.UpdateAdress();
        }

        private void btnImportPD_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            clear.GisPD();
            importGis.ImportPD(openFileDialog1.FileName);
        }

        private void btnLSCancel_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            clear.GisLS("gis_ls_cancel");
            importGis.ImportLS(openFileDialog1.FileName, "gis_ls_cancel");
        }

        private void chdListBoxCreate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

