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
            textBox4.Text = "";
            string K = textBox3.Text.ToUpper();
            string P = textBox1.Text.ToUpper();
            char[,] arrayK = TaoKhoa(K);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++) textBox4.Text += (arrayK[i, j] + " ");
                textBox4.Text += "\r\n";
            }
            textBox4.Text += "Copy để giải mã: ";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++) textBox4.Text += (arrayK[i, j]);
            }
            string E = MaHoa(P, arrayK);
            textBox2.Text = E;
        }
        static string MaHoa(string BanRo, char[,] arrayK)
        {
            #region Chuẩn hoá bản rõ
            // xoá dấu cách
            string bieuThucChinhQuy = @"[\s]+";
            Regex reg = new Regex(bieuThucChinhQuy);
            string P = reg.Replace(BanRo, "");
            int lenP = P.Length, countP = 0, tmpI;
            // thêm X để phân cách các ký tự lặp lại
            for (int i = 0; i < lenP + countP - 1; i++)
            {
                tmpI = i + 1;
                if (P[i] == P[tmpI]) { P = P.Insert(i + 1, "X"); countP++; }
            }
            while (P.Length % 2 != 0) P += 'Z'; // đảm bảo đủ cặp để mã hoá, không đủ thì thêm Z
            #endregion
            string C = "";
            int charP1x = 0, charP1y = 0, charP2x = 0, charP2y = 0, tmp = 0;
            for (int i = 0; i < P.Length - 1; i++)
            {
                tmp = i + 1;
                // xem 2 ký tự cần mã hoá ở đâu trên khoá
                for (int j = 0; j < 5; j++)
                    for (int h = 0; h < 5; h++)
                    {
                        if (arrayK[j, h] == P[i] || (arrayK[j, h] == 'I' && P[i] == 'J')) { charP1x = j; charP1y = h; }
                        if (arrayK[j, h] == P[tmp] || (arrayK[j, h] == 'I' && P[i] == 'J')) { charP2x = j; charP2y = h; }
                    }
                if (charP1y == charP2y)
                { // nếu nằm trên hàng dọc
                    if (charP1x == 4)
                    {
                        C += arrayK[0, charP1y];
                        C += arrayK[charP2x + 1, charP2y];
                        i++;
                    }
                    else if (charP2x == 4)
                    {
                        C += arrayK[0, charP2y];
                        C += arrayK[charP1x + 1, charP1y];
                        i++;
                    }
                    else
                    {
                        C += arrayK[charP1x + 1, charP1y];
                        C += arrayK[charP2x + 1, charP2y];
                        i++;
                    }
                }
                else if (charP1x == charP2x)
                { // nếu nằm trên hàng ngang
                    if (charP1y == 4)
                    {
                        C += arrayK[charP1x, 0];
                        C += arrayK[charP2x, charP2y + 1];
                        i++;
                    }
                    else if (charP2y == 4)
                    {
                        C += arrayK[charP1x, charP1y + 1];
                        C += arrayK[charP2x, 0];
                        i++;
                    }
                    else
                    {
                        C += arrayK[charP1x, charP1y + 1];
                        C += arrayK[charP2x, charP2y + 1];
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
        static char[,] TaoKhoa(string Khoa)
        {
            // xoá dấu cách
            string bieuThucChinhQuy = @"[\s]+";
            Regex reg = new Regex(bieuThucChinhQuy);
            string K = reg.Replace(Khoa, ""); // khoá mới không có dấu cách
            string tmpK = XoaKyTuTrung(K);
            // sinh khoá để đủ ma trận 5x5
            bool kiemTraTrung = false;
            Random r = new Random();
            int tmp = 0;
            while (tmpK.Length < 25)
            {
                kiemTraTrung = false;
                tmp = 0;
                do
                    tmp = r.Next(65, 91);
                while (tmp == 74); // trên ma trận khoá không có J
                char tmpChar = (char)tmp; // lưu ký tự vừa Random được vào biến tmpChar
                // tìm trong Khoá đã có ký tự vừa Random chưa, nếu có thì break
                for (int i = 0; i < tmpK.Length; i++)
                    if (tmpChar == tmpK[i]) { kiemTraTrung = true; break; }
                if (kiemTraTrung == false) tmpK += tmpChar; // nếu chưa xuất hiện thì thêm vào khoá
            }
            char[,] arrayK = new char[5, 5]; // tạo mảng 5x5 để chuyển string khoá thành mảng
            int controTMP = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++) { arrayK[i, j] = tmpK[controTMP]; controTMP++; }
            return arrayK;
        }
        static string XoaKyTuTrung(string K)
        {
            // chuyển string thành mảng để xoá ký tự trùng
            char[] arrayK = new char[K.Length];
            for (int i = 0; i < K.Length; i++) arrayK[i] = K[i];
            bool kyTuTrung = false;
            for (int i = 0; i < arrayK.Length; i++)
            {
                kyTuTrung = false;
                // phát hiện ký tự trùng
                for (int j = i + 1; j < arrayK.Length; j++)
                    if (arrayK[i] == arrayK[j]) { kyTuTrung = true; break; }
                // xoá ký tự trùng, đánh dấu nó = 0
                if (kyTuTrung == true) arrayK[i] = '0';
            }
            // chuyển lại mảng về string
            string tmpK = "";
            for (int i = 0; i < arrayK.Length; i++)
                if (arrayK[i] != '0') tmpK += arrayK[i];
            tmpK = tmpK.Trim(); // xoá khoảng trắng ở hai đầu (đề phòng)
            return tmpK;
        }
    }
}
