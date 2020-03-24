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
            string C = textBox1.Text;
            string K = textBox3.Text;
            int tmp = 0;
            char[,] arrayK = new char[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayK[i, j] = K[tmp];
                    tmp++;
                }
            }
            string D = GiaiMa(C, arrayK);
            textBox2.Text = D;
        }
        static string GiaiMa(string BanMa, char[,] arrayK)
        {
            // xoá dấu cách
            string bieuThucChinhQuy = @"[\s]+";
            Regex reg = new Regex(bieuThucChinhQuy);
            string P = reg.Replace(BanMa, "");
            string C = "";
            int charP1x = 0, charP1y = 0, charP2x = 0, charP2y = 0, tmp = 0;
            for (int i = 0; i < P.Length - 1; i++)
            {
                tmp = i + 1;
                // xem 2 ký tự cần giải mã ở đâu trên khoá
                for (int j = 0; j < 5; j++)
                    for (int h = 0; h < 5; h++)
                    {
                        if (arrayK[j, h] == P[i] || (arrayK[j, h] == 'I' && P[i] == 'J')) { charP1x = j; charP1y = h; }
                        if (arrayK[j, h] == P[tmp] || (arrayK[j, h] == 'I' && P[i] == 'J')) { charP2x = j; charP2y = h; }
                    }
                if (charP1y == charP2y)
                { // nếu nằm trên hàng dọc
                    if (charP1x == 0)
                    {
                        C += arrayK[4, charP1y];
                        C += arrayK[charP2x - 1, charP2y];
                        i++;
                    }
                    else if (charP2x == 0)
                    {
                        C += arrayK[4, charP2y];
                        C += arrayK[charP1x - 1, charP1y];
                        i++;
                    }
                    else
                    {
                        C += arrayK[charP1x - 1, charP1y];
                        C += arrayK[charP2x - 1, charP2y];
                        i++;
                    }
                }
                else if (charP1x == charP2x)
                { // nếu nằm trên hàng ngang
                    if (charP1y == 0)
                    {
                        C += arrayK[charP1x, 4];
                        C += arrayK[charP2x, charP2y - 1];
                        i++;
                    }
                    else if (charP2y == 0)
                    {
                        C += arrayK[charP1x, charP1y - 1];
                        C += arrayK[charP2x, 4];
                        i++;
                    }
                    else
                    {
                        C += arrayK[charP1x, charP1y - 1];
                        C += arrayK[charP2x, charP2y - 1];
                        i++;
                    }
                }
                else
                { // nếu nằm chéo nhau
                    C += arrayK[charP1x, charP2y];
                    C += arrayK[charP2x, charP1y];
                    i++;
                }
            }
            return C;
        }
    }
}
