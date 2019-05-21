using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace M2MSOAPSample
{
    public partial class Error : Form
    {
        public Error(string textError)
        {
            InitializeComponent();
            textBox1.Text = textError;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
