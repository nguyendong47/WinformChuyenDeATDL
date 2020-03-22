using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuyenDe5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            maHoa1.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            giaiMa1.BringToFront();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var addressWeb1 = @"https://www.facebook.com/groups/291336038311180";
            Process.Start(addressWeb1);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string member1 = "Thành viên:\r\nNguyễn Văn Đông\r\nĐỗ Thị Minh Phương\r\nNguyễn Anh Quân";
            MessageBox.Show(member1);
        }
    }
}
