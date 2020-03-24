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
    public partial class encrpytion : UserControl
    {
        public encrpytion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string P = textBox1.Text;
            P = P.ToUpper();
            int a = (int)numericUpDown1.Value;
            int b = (int)numericUpDown2.Value;
            if (UCLN(a, 26) != 1)
            {
                MessageBox.Show("Vui lòng nhập lại KHOÁ!");
                return;
            }
            string C = "";
            if (radioButton1.Checked)
            {
                C = MaHoaTrenModulo26(P, a, b);
                textBox2.Text = C;
            }
            if (radioButton2.Checked)
            {
                C = MaHoaTrenModulo256(P, a, b);
                textBox2.Text = C;
            }
        }
        static string MaHoaTrenModulo26(string P, int a, int b)
        {
            string KetQua = "";
            P = P.ToUpper();
            for (int i = 0; i < P.Length; i++)
                KetQua += (char)((((a * (((int)P[i]) - 65)) + b) % 26) + 65);
            return KetQua;
        }
        static string MaHoaTrenModulo256(string P, int a, int b)
        {
            string KetQua = "";
            for (int i = 0; i < P.Length; i++)
                KetQua += (char)(((a * ((int)P[i])) + b) % 256);
            return KetQua;
        }
        static int UCLN(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a = a - b;
                else b = b - a;
            }
            return a;
        }
    }
}
