using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avast2017
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            encrpytion1.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            encrpytion1.BringToFront();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            decrpytion1.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            information1.BringToFront();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            
        }
    }
}
