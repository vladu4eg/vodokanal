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
using System.Threading;
using System.Globalization;
using BotAgent.DataExporter;
using MySql.Data.MySqlClient;

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
            Dogovor createDogovor = new Dogovor();
            createDogovor.CreateDogovor();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Dogovor createDogovor = new Dogovor();
            createDogovor.ProjectDogovor();
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
    }
}
