using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avast2017
{
    public partial class decrpytion : UserControl
    {
        public decrpytion()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string C = textBox1.Text;
            string Pi = textBox3.Text;
            string hoanViPi = textBox4.Text;
            if (radioButton2.Checked)
            {
                textBox2.Text = GiaiMa(C, Pi, hoanViPi);
            }
            else
                textBox2.Text = GiaiMa(C.ToUpper(), Pi, hoanViPi);
        }
        static string GiaiMa(string P, string Pi, string hoanVi)
        {
            string ketQua = "";
            for (int i = 0; i < P.Length; i++)
                for (int j = 0; j < hoanVi.Length; j++)
                    if (P[i] == hoanVi[j])
                        ketQua += Pi[j];
            return ketQua;
        }
    }
}
