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
    public partial class decrpytion : UserControl
    {
        public decrpytion()
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
                if (mK==2)
                {
                    textBox2.Text = GiaiMa2x2z26(arrayP, mP, nP, arrayK, mK);
                }
                else
                {
                    textBox2.Text = GiaiMa26(arrayP, mP, nP, arrayK, mK);
                }
            }
            if (radioButton2.Checked)
            {
                if (mK == 2)
                {
                    textBox2.Text = GiaiMa2x2z256(arrayP, mP, nP, arrayK, mK);
                }
                else
                {
                    textBox2.Text = GiaiMa256(arrayP, mP, nP, arrayK, mK);
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
        static string GiaiMa2x2z26(int[,] arrayC, int mC, int nC, int[,] arrayK, int mK)
        {
            string P = "";
            int[,] arrayKdao = arrayK;
            int tmp = arrayKdao[0, 0];
            arrayKdao[0, 0] = arrayKdao[1, 1];
            arrayKdao[1, 1] = tmp;
            arrayKdao[0, 1] *= -1;
            arrayKdao[1, 0] *= -1;
            for (int i = 0; i < mK; i++)
            {
                for (int j = 0; j < mK; j++)
                {
                    if (arrayKdao[i, j] % 26 < 0) arrayKdao[i, j] = (arrayKdao[i, j] % 26) + 26;
                    else arrayKdao[i, j] %= 26;
                }
            }
            //Console.WriteLine("\nMa trận đảo K với Z = 26: ");
            for (int i = 0; i < mK; i++)
            {
                for (int j = 0; j < mK; j++)
                {
                    //Console.Write(arrayKdao[i, j] + " ");
                }
                //Console.WriteLine();
            }
            int[,] arrayP = new int[mC, nC];
            int sum;
            for (int i = 0; i < mC; i++)
                for (int j = 0; j < nC; j++)
                {
                    sum = 0;
                    for (int k = 0; k < nC; k++)
                        sum += arrayC[i, k] * arrayKdao[k, j];
                    arrayP[i, j] = sum % 26;
                }
            for (int i = 0; i < mC; i++)
                for (int j = 0; j < nC; j++)
                    P += (char)(arrayP[i, j] + 65);
            //Console.WriteLine("\nBản rõ ban đầu Z = 26: " + P);
            return P;
        }
        static string GiaiMa2x2z256(int[,] arrayC, int mC, int nC, int[,] arrayK, int mK)
        {
            string P = "";
            int[,] arrayKdao = arrayK;
            int tmp = arrayKdao[0, 0];
            arrayKdao[0, 0] = arrayKdao[1, 1];
            arrayKdao[1, 1] = tmp;
            arrayKdao[0, 1] *= -1;
            arrayKdao[1, 0] *= -1;
            for (int i = 0; i < mK; i++)
            {
                for (int j = 0; j < mK; j++)
                {
                    if (arrayKdao[i, j] % 256 < 0) arrayKdao[i, j] = (arrayKdao[i, j] % 256) + 256;
                    else arrayKdao[i, j] %= 256;
                }
            }
            //Console.WriteLine("\nMa trận K đảo với Z = 256: ");
            for (int i = 0; i < mK; i++)
            {
                for (int j = 0; j < mK; j++)
                {
                    //Write(arrayKdao[i, j] + " ");
                }
                //Console.WriteLine();
            }
            int[,] arrayP = new int[mC, nC];
            int sum;
            for (int i = 0; i < mC; i++)
                for (int j = 0; j < nC; j++)
                {
                    sum = 0;
                    for (int k = 0; k < nC; k++)
                        sum += arrayC[i, k] * arrayKdao[k, j];
                    arrayP[i, j] = sum % 256;
                }
            for (int i = 0; i < mC; i++)
                for (int j = 0; j < nC; j++)
                    P += (char)arrayP[i, j];
            //Console.WriteLine("\nBản rõ ban đầu Z = 256: " + P);
            return P;
        }
        static string GiaiMa26(int[,] arrayC, int mC, int nC, int[,] arrayK, int mK)
        {
            int[,] arrayKdao = new int[mK, mK];
            int d = determinant(arrayK, mK);
            //Console.WriteLine("\nĐịnh thức = " + d);
            string banRo = "";
            if (d == 0)
                MessageBox.Show("\nKhông có ma trận đảo!");
            else
            {
                arrayKdao = cofactor(arrayK, mK);
                for (int i = 0; i < mK; i++)
                {
                    for (int j = 0; j < mK; j++)
                    {
                        if (arrayKdao[i, j] < 0) arrayKdao[i, j] += 26;
                        else arrayKdao[i, j] %= 26;
                    }
                }
                //Console.WriteLine("\nMa trận K đảo Z = 26: ");
                for (int i = 0; i < mK; i++)
                {
                    for (int j = 0; j < mK; j++)
                    {
                        Console.Write(arrayKdao[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                int[,] arrayP = new int[mC, nC];
                int sum;
                for (int i = 0; i < mC; i++)
                    for (int j = 0; j < nC; j++)
                    {
                        sum = 0;
                        for (int k = 0; k < nC; k++)
                            sum += arrayC[i, k] * arrayKdao[k, j];
                        arrayP[i, j] = sum % 26;
                    }
                for (int i = 0; i < mC; i++)
                    for (int j = 0; j < nC; j++)
                        banRo += (char)(arrayP[i, j] + 65);
            }
            //Console.WriteLine("\nBản rõ ban đầu Z = 26: " + banRo);
            return banRo;
        }
        static string GiaiMa256(int[,] arrayC, int mC, int nC, int[,] arrayK, int mK)
        {
            string banRo = "";
            int[,] arrayKdao = new int[mK, mK];
            int[,] arrayP = new int[mC, nC];
            int d = determinant(arrayK, mK);
            //Console.WriteLine("\nĐịnh thức = " + d);
            if (d == 0)
                MessageBox.Show("\nKhông có ma trận đảo!");
            else
            {
                arrayKdao = cofactor(arrayK, mK);
                for (int i = 0; i < mK; i++)
                {
                    for (int j = 0; j < mK; j++)
                    {
                        if (arrayKdao[i, j] < 0) arrayKdao[i, j] += 256;
                        else arrayKdao[i, j] %= 256;
                        int tmp = arrayKdao[i, j];
                        char tmp1 = (char)tmp;
                    }
                }
                //Console.WriteLine("\nMa trận K đảo Z = 256: ");
                for (int i = 0; i < mK; i++)
                {
                    for (int j = 0; j < mK; j++)
                    {
                        Console.Write(arrayKdao[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                int sum;
                for (int i = 0; i < mC; i++)
                    for (int j = 0; j < nC; j++)
                    {
                        sum = 0;
                        for (int k = 0; k < nC; k++)
                            sum += arrayC[i, k] * arrayKdao[k, j];
                        arrayP[i, j] = ((int)sum) % 256;
                    }
                //Console.WriteLine("\nMa trận C sau khi giải mã: ");
                
                for (int i = 0; i < mC; i++)
                    for (int j = 0; j < nC; j++)
                        banRo = banRo + (char) arrayC[i, j];                
            }
            return banRo;
        }
        static int determinant(int[,] matrix, int size)
        {
            int s = 1, det = 0;
            int[,] m_minor = new int[25, 25];
            int i, j, m, n, c;
            if (size == 1)
            {
                return (matrix[0, 0]);
            }
            else
            {
                det = 0;
                for (c = 0; c < size; c++)
                {
                    m = 0;
                    n = 0;
                    for (i = 0; i < size; i++)
                    {
                        for (j = 0; j < size; j++)
                        {
                            m_minor[i, j] = 0;
                            if (i != 0 && j != c)
                            {
                                m_minor[m, n] = matrix[i, j];
                                if (n < (size - 2))
                                    n++;
                                else
                                {
                                    n = 0;
                                    m++;
                                }
                            }
                        }
                    }
                    det = det + s * (matrix[0, c] * determinant(m_minor, size - 1));
                    s = -1 * s;
                }
            }
            return (det);
        }
        static int[,] cofactor(int[,] matrix, int size)
        {
            int[,] m_cofactor = new int[25, 25];
            int[,] matrix_cofactor = new int[25, 25];
            int p, q, m, n, i, j;
            for (q = 0; q < size; q++)
            {
                for (p = 0; p < size; p++)
                {
                    m = 0;
                    n = 0;
                    for (i = 0; i < size; i++)
                    {
                        for (j = 0; j < size; j++)
                        {
                            if (i != q && j != p)
                            {
                                m_cofactor[m, n] = matrix[i, j];
                                if (n < (size - 2))
                                    n++;
                                else
                                {
                                    n = 0;
                                    m++;
                                }
                            }
                        }
                    }
                    matrix_cofactor[q, p] = ((int)Math.Pow(-1, q + p)) * determinant(m_cofactor, size - 1);
                }
            }
            return transpose(matrix, matrix_cofactor, size);
        }
        static int[,] transpose(int[,] matrix, int[,] matrix_cofactor, int size)
        {
            int i, j;
            int[,] m_transpose = new int[25, 25], m_inverse = new int[25, 25];
            int d;
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    m_transpose[i, j] = matrix_cofactor[j, i];
                }
            }
            d = determinant(matrix, size);
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    m_inverse[i, j] = m_transpose[i, j] / d;
                }
            }
            return m_inverse;
        }
    }
}
