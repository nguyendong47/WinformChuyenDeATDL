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
            string P = textBox1.Text;
            string bieuThucChinhQuy = @"[\s]+";
            Regex reg = new Regex(bieuThucChinhQuy);
            P = reg.Replace(P, "");

            string K = textBox3.Text;
            string[] stringK = K.Split(',');
            int[] arrayK = Array.ConvertAll<string, int>(stringK, int.Parse);
            string C = MaHoa(P, arrayK);
            textBox2.Text = C;
        }
        static string MaHoa(string P, int[] arrayK)
        {
            string C = "";
            int m = arrayK.Length;
            while (P.Length % m != 0)
                P += 'Z';
            int i = 0, j = 0, k = 0;
            while (i < P.Length)
            {
                C += P[arrayK[j] - 1 + k];
                if (j == arrayK.Length - 1) { j = 0; k += m; } else j++;
                i++;
            }
            return C;
        }
    }
}
