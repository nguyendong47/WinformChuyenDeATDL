using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuyenDe1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            int N = 0;
            int ketQua = 0;
            if (Int32.TryParse(X.Text, out x))
            {
                if (Int32.TryParse(Modulo.Text, out N))
                {
                    ketQua = nghichDaoModulo(x, N);
                    KQ.Text = ketQua.ToString();
                }
            }
            else KQ.Text = "Vui lòng nhập số!";
        }
        static int nghichDaoModulo(int x, int n)
        {
            for (int i = 1; i < n; i++)
                if (((long)x * i) % n == 1) return i;
            return -1;
        }
        static long soMuaLon(int x, int k, int N)
        {
            long ketQua = 1;
            for (int i = 1; i <= k; i++) { ketQua *= x; ketQua %= N; }
            return ketQua;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;
            int k = 0;
            int n = 0;
            long ketQua = 0;
            if (Int32.TryParse(textBox1.Text, out x))
            {
                if (Int32.TryParse(textBox2.Text, out k))
                {
                    if (Int32.TryParse(textBox3.Text, out n))
                    {
                        ketQua = soMuaLon(x, k, n);
                        textBox4.Text = ketQua.ToString();
                    }
                }
            }
            else textBox4.Text = "Vui lòng nhập số!";
        }
    }
}
