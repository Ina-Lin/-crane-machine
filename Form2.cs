using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _410275017
{
    public partial class Form2 : Form
    {
        public Form1 FM1 = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FM1.op = 1;
            this.Hide();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            FM1.op = 0;
            this.Hide();
        }
    }
}
