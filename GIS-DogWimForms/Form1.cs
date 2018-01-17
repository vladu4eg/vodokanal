using System;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    public partial class Form1 : Form
    {
        public Form1()
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
            ls.CreateLS();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.CreateHome();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PY py = new PY();
            py.AddPY();
        }

        private void btnPokaz_Click(object sender, EventArgs e)
        {
            Pokaz pokaz = new Pokaz();
            pokaz.AddPokaz();
        }

        private void btnKvit_Click(object sender, EventArgs e)
        {
            Kvit kvit = new Kvit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PY py = new PY();
            py.PyFIX();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update update = new Update();
            update.UpdateAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdAdressOnly_Click(object sender, EventArgs e)
        {
            Update update = new Update();
            update.UpdateClearAdress();
            update.UpdateAdress();
        }
    }
}
