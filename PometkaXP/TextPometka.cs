using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PometkaXP
{
    public partial class TextPometka : Form
    {
        public TextPometka(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
            textBox1.SelectionStart = 0;
        }

        private void TextPoemtka_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
