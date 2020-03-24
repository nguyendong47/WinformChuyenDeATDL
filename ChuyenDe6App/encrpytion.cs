using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            string bieuThucChinhQuy = @"[\s]+";
            Regex reg = new Regex(bieuThucChinhQuy);
            string P = textBox1.Text;
            string K = textBox3.Text;
            K = reg.Replace(K, "");
            P = reg.Replace(P, "");
            if (radioButton1.Checked)
            {
                textBox2.Text = MaHoa(P,K);
            }
            if (radioButton2.Checked)
            {
                textBox2.Text = MaHoa256(P, K);
            }
        }
        static string MaHoa(string P, string K)
        {
            P = P.ToLower();
            K = K.ToUpper();
            string C = "";
            int count = 0;
            for (int i = 0; i < P.Length; i++)
            {
                // biến đổi các phần tử theo modulo 26 (A, B, a, b)
                int chuyenP = (int)P[i] - 97;
                int chuyenK = (int)K[count] - 65;
                int tinhC = (chuyenP + chuyenK) % 26;
                C += (char)(tinhC + 65);
                count++;
                if (count > K.Length - 1) count = 0; // reset chỉ số khoá K
            }
            return C;
        }
        static string MaHoa256(string P, string K)
        {
            string C = "";
            int count = 0;
            for (int i = 0; i < P.Length; i++)
            {
                int chuyenP = (int)P[i];
                int chuyenK = (int)K[count];
                int tinhC = (chuyenP + chuyenK) % 256;
                C += (char)tinhC;
                count++;
                if (count > K.Length - 1) count = 0;
            }
            return C;
        }

    }
}
