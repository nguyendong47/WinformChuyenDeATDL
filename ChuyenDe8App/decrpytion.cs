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
            string[] stringK = K.Split(',');
            int[] arrayK = Array.ConvertAll<string, int>(stringK, int.Parse);
            string P = GiaiMa(C, arrayK);
            textBox2.Text = P;
        }
        static string GiaiMa(string C, int[] arrayK)
        {
            int m = arrayK.Length;
            #region Sinh hoán vị K
            int count1 = 0, count2 = 0;
            int[] arrayK2 = new int[C.Length];
            for (int h = 0; h < arrayK2.Length; h++)
            {
                if (h < m) arrayK2[h] = arrayK[h];
                else arrayK2[h] = arrayK2[h - count1] + m;
                if (count2 == m - 1) count1 += m;
                count2++;
            }
            #endregion
            // giải mã
            char[] D = new char[C.Length];
            for (int h = 0; h < D.Length; h++)
                D[arrayK2[h] - 1] = C[h];
            for (int h = D.Length - 1; h > 0; h--)
            {
                if (D[h] == 'Z') D[h] = ' ';
                else break;
            }
            string P = "";
            for (int h = 0; h < D.Length; h++)
                P += D[h];
            return P;
        }
    }
}
