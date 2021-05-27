using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using OpenCvSharp;






namespace dwqeqw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e) //cap
        {

        }

        private void button1_Click(object sender, EventArgs e)//Transelate
        {
            Bitmap img = new Bitmap(pictureBox1.Image);
            var ocr = new TesseractEngine("./tessdata", "kor", EngineMode.Default);
            var texts = ocr.Process(img);

            MessageBox.Show(texts.GetText());


        }

        private void button3_Click(object sender, EventArgs e)//Imagesave
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)//번역전 원문 텍스트가 나오는 박스
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)//번역된 텍스트가 나오는 박스
        {

        }

        private void button1_Click_1(object sender, EventArgs e) //이미지 가져오기
        {

        }
    }
}
