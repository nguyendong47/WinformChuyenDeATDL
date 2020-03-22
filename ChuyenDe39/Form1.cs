using System;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace ChuyenDe5
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speechsynth = new SpeechSynthesizer();
        SpeechRecognitionEngine receng = new SpeechRecognitionEngine();
        SpeechRecognitionEngine receng2 = new SpeechRecognitionEngine();
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var addressWeb1 = @"https://www.facebook.com/groups/291336038311180";
            Process.Start(addressWeb1);
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string member1 = "Thành viên:\r\nNguyễn Văn Đông\r\nNguyễn Thế Hiếu";
            MessageBox.Show(member1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToLower().Equals("dong") && textBox2.Text.ToLower().Equals("cntt2k19") || textBox4.Text.Equals("CNTT2") && textBox3.Text.Equals("Hai Phong University"))
            {
                MessageBox.Show("Logged in successfully!");
            }
            else
            {
                MessageBox.Show("Username/Password error!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Choices choice = new Choices();
            choice.Add(new string[] { "Dong", "123", "Information Technology", "CNTT2" });
            Grammar gr = new Grammar(new GrammarBuilder(choice));
            try
            {
                receng.RequestRecognizerUpdate();
                receng.LoadGrammar(gr);
                receng.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(receng_SpeechRecognized1);
                receng.SetInputToDefaultAudioDevice();
                receng.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        void receng_SpeechRecognized1(object sender, SpeechRecognizedEventArgs e)
        {
            pictureBox9.Enabled = true;
            pictureBox5.Enabled = false;
            textBox4.Text = e.Result.Text.ToString();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox9.Enabled = false;
            pictureBox5.Enabled = true;
            receng.RecognizeAsyncStop();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Choices choice1 = new Choices();
            choice1.Add(new string[] { "Hai Phong University", "Information Technology", "123" });
            Grammar gr = new Grammar(new GrammarBuilder(choice1));
            try
            {
                receng2.RequestRecognizerUpdate();
                receng2.LoadGrammar(gr);
                receng2.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(receng_SpeechRecognized2);
                receng2.SetInputToDefaultAudioDevice();
                receng2.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        void receng_SpeechRecognized2(object sender, SpeechRecognizedEventArgs e)
        {
            pictureBox10.Enabled = true;
            pictureBox6.Enabled = false;
            textBox3.Text = e.Result.Text.ToString();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox10.Enabled = false;
            pictureBox6.Enabled = true;
            receng.RecognizeAsyncStop();
        }
    }
}
