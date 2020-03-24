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
        static int nghichDaoModulo(int x, int n)
        {
            for (int i = 1; i < n; i++)
                if (((long)x * i) % n == 1) return i;
            return -1;
        }
        static string GiaiMaTrenModulo256(string C, int a, int b)
        {
            string KetQua = "";
            int nghichDao = nghichDaoModulo(a, 256);
            for (int i = 0; i < C.Length; i++)
            {
                int chuyenSangSo = ((int)C[i]);
                if (chuyenSangSo < b)
                    KetQua += (char)((nghichDao * ((int)C[i] - b) % 256) + 256);
                else KetQua += (char)(nghichDao * ((int)C[i] - b) % 256);
            }
            return KetQua;
        }
        static string GiaiMaTrenModulo26(string C, int a, int b)
        {
            string KetQua = "";
            C = C.ToUpper();
            int nghichDao = nghichDaoModulo(a, 26);
            for (int i = 0; i < C.Length; i++)
            {
                int chuyenSangSo = ((int)C[i]) - 65;
                if (chuyenSangSo < b)
                    KetQua += (char)((nghichDao * (chuyenSangSo - b) % 26) + 65 + 26);
                else
                    KetQua += (char)((nghichDao * (chuyenSangSo - b) % 26) + 65);
            }
            return KetQua;
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
                C = GiaiMaTrenModulo26(P, a, b);
                textBox2.Text = C;
            }
            if (radioButton2.Checked)
            {
                C = GiaiMaTrenModulo256(P, a, b);
                textBox2.Text = C;
            }
        }
    }
}
