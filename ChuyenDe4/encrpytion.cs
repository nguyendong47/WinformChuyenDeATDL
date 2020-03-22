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
            if (radioButton1.Checked)
            {
                string P26 = P.ToUpper();
                string Pi26 = SinhPi(26);
                string hoanVi26 = SinhHoanVi(26);
                string C26 = MaHoa(P26, Pi26, hoanVi26);
                textBox2.Text = C26;
                textBox3.Text = Pi26;
                textBox4.Text = hoanVi26.ToUpper();
            }
            if (radioButton2.Checked)
            {
                string Pi256 = SinhPi(256);
                textBox3.Text = Pi256;
                string hoanVi256 = SinhHoanVi(256);
                textBox4.Text = hoanVi256;
                string C256 = MaHoa(P, Pi256, hoanVi256);
                textBox2.Text = C256;
            }
        }

        static string MaHoa(string P, string Pi, string hoanVi)
        {
            string ketQua = "";
            for (int i = 0; i < P.Length; i++)
                for (int j = 0; j < Pi.Length; j++)
                    if (P[i] == Pi[j])
                        ketQua += hoanVi[j];
            return ketQua;
        }
        static string SinhHoanVi(int n)
        {
            Random r = new Random();
            string hoanVi = "";
            if (n == 256)
            {
                hoanVi += (char)r.Next(32, 126);
                bool tmpBool;
                char tmp;
                int tmp1;
                for (int i = 0; i < 192; i++)
                {
                    do
                        tmp1 = r.Next(32, 255);
                    while (tmp1 > 126 && tmp1 < 161);
                    tmp = (char)tmp1;
                    tmpBool = true;
                    for (int j = 0; j < hoanVi.Length; j++)
                        if (tmp == hoanVi[j]) { tmpBool = false; break; }
                    if (tmpBool == true) hoanVi += tmp;
                }
            }
            else if (n == 26)
            {
                hoanVi = "xnyahpogzqwbtsflrcvmuekjdi";
            }
            return hoanVi;
        }
        static string SinhPi(int n)
        {
            string Pi = "";
            if (n == 256)
                for (int i = 32; i <= 255; i++)
                    if (i < 127 || i > 160) Pi += (char)i;
            if (n == 26)
            {
                for (int i = 65; i <= 90; i++) Pi += (char)i;
                for (int i = 0; i < Pi.Length; i++) Console.Write(Pi[i] + " ");
            }
            return Pi;
        }
    }
}
