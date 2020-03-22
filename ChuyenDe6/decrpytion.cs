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
            string K = textBox3.Text;
            if (radioButton1.Checked)
            {
                textBox2.Text = GiaiMa(C, K);
            }
            if (radioButton2.Checked)
            {
                textBox2.Text = GiaiMa256(C, K);
            }
        }
        static string GiaiMa(string C, string K)
        {
            C = C.ToUpper();
            K = K.ToUpper();
            string P = "";
            int count = 0, tinhC;
            for (int i = 0; i < C.Length; i++)
            {
                // biến đổi các phần tử theo modulo 26 (A, B, a, b)
                int chuyenC = (int)C[i] - 65;
                int chuyenK = (int)K[count] - 65;
                if (chuyenC - chuyenK < 0)
                    tinhC = ((chuyenC - chuyenK) % 26) + 26;
                else
                    tinhC = (chuyenC - chuyenK) % 26;
                P += (char)(tinhC + 97);
                count++;
                if (count > K.Length - 1) count = 0; // reset chỉ số khoá K
            }
            return P;
        }
        static string GiaiMa256(string C, string K)
        {
            string P = "";
            int count = 0, tinhC;
            for (int i = 0; i < C.Length; i++)
            {
                // biến đổi các phần tử theo modulo 26 (A, B, a, b)
                int chuyenC = (int)C[i];
                int chuyenK = (int)K[count];
                if (chuyenC - chuyenK < 0)
                    tinhC = ((chuyenC - chuyenK) % 256) + 256;
                else
                    tinhC = (chuyenC - chuyenK) % 256;
                P += (char)(tinhC);
                count++;
                if (count > K.Length - 1) count = 0;
            }
            return P;
        }
    }
}
