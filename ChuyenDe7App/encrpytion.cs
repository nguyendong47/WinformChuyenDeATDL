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
            textBox2.Text = "";
            string P = textBox1.Text;
            int mP = (int)numericUpDown1.Value;
            int nP = (int)numericUpDown2.Value;
            if (mP * nP < P.Length)
            {
                MessageBox.Show("Vui lòng nhập lại số hàng và số cột của ma trận P!");
                return;
            }
            string K = textBox4.Text;
            int mK = (int)numericUpDown3.Value;
            if ((mK * mK < K.Length) || (nP != mK))
            {
                MessageBox.Show("Vui lòng nhập lại số hàng và số cột của ma trận K!");
                return;
            }
            int[,] arrayP = chuyenChuSangSo(P, mP, nP);
            int[,] arrayK = chuyenChuSangSo(K, mK, mK);
            if (radioButton1.Checked)
            {
                int[,] arrayC = MaHoa26(arrayP, mP, nP, arrayK, mK);
                for (int i = 0; i < mP; i++)
                {
                    for (int j = 0; j < nP; j++)
                    {
                        textBox2.Text += (char)(arrayC[i, j] + 65);
                    }
                }
            }
            if (radioButton2.Checked)
            {
                int[,] arrayC256 = MaHoa256(arrayP, mP, nP, arrayK, mK);
                for (int i = 0; i < mP; i++)
                {
                    for (int j = 0; j < nP; j++)
                    {
                        textBox2.Text += (char)(arrayC256[i, j]);
                    }
                }
            }
        }
        static int[,] chuyenChuSangSo(string A, int m, int n)
        {
            string bieuThucChinhQuy = @"[\s]+";
            Regex reg = new Regex(bieuThucChinhQuy);
            A = reg.Replace(A, ""); // xoá dấu cách
            while (A.Length != (m * n)) // nếu độ dài bản rõ thiếu ký tự thì thêm Z vào cuối
                A += 'Z';
            A = A.ToUpper();
            int[,] arrayA = new int[m, n];
            int tmp = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arrayA[i, j] = (int)A[tmp] - 65;
                    tmp++;
                    //Console.Write(arrayA[i, j] + " ");
                }
                //Console.WriteLine();
            }
            return arrayA;
        }
        static int[,] MaHoa26(int[,] arrayP, int mP, int nP, int[,] arrayK, int mK)
        {
            int[,] arrayC = new int[mP, nP];
            int sum;
            for (int i = 0; i < mP; i++)
                for (int j = 0; j < nP; j++)
                {
                    sum = 0;
                    for (int k = 0; k < nP; k++)
                        sum += arrayP[i, k] * arrayK[k, j];
                    arrayC[i, j] = sum % 26;
                }
            //for (int i = 0; i < mP; i++)
            //{
            //    for (int j = 0; j < nP; j++)
            //        //Console.Write(arrayC[i, j] + " ");
            //    //Console.WriteLine();
            //}
            string banMa = "";
            for (int i = 0; i < mP; i++)
                for (int j = 0; j < nP; j++)
                    banMa += (char)(arrayC[i, j] + 65);
            //Console.WriteLine("\nBản mã với Z = 26: " + banMa);
            return arrayC;
        }
        static int[,] MaHoa256(int[,] arrayP, int mP, int nP, int[,] arrayK, int mK)
        {
            int[,] arrayC = new int[mP, nP];
            int sum;
            for (int i = 0; i < mP; i++)
                for (int j = 0; j < nP; j++)
                {
                    sum = 0;
                    for (int k = 0; k < nP; k++)
                        sum += arrayP[i, k] * arrayK[k, j];
                    arrayC[i, j] = sum % 256;
                }
            //for (int i = 0; i < mP; i++)
            //{
            //    for (int j = 0; j < nP; j++)
            //        //Console.Write(arrayC[i, j] + " ");
            //    //Console.WriteLine();
            //}
            string banMa = "";
            for (int i = 0; i < mP; i++)
                for (int j = 0; j < nP; j++)
                    banMa += (char)arrayC[i, j];
            //Console.WriteLine("\nBản mã với Z = 256: " + banMa);
            return arrayC;
        }
    }
}
