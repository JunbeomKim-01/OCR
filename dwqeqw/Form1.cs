
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







namespace dwqeqw
{
    public partial class Form1 : Form
    {
        private const string Datapath = @"C:\Users\user\source\repos\OCR\dwqeqw\bin\Debug\netcoreapp3.1\tessdata";
        SetLanguage setLanguage = new SetLanguage();
        Bitmap bitmap = null;
        string imgsrc = null;
        Page texts = null;
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e) //cap
        {
            
            for (int i = 0; i < bitmap.Width; ++i)
            {
                for (int k = 0; k < bitmap.Height; ++k)
                {
                   Color color= bitmap.GetPixel(i, k);
                    int binary = (color.R + color.G + color.B) / 3;
                    if (binary > 200)
                        bitmap.SetPixel(i, k, Color.Black);
                    else
                        bitmap.SetPixel(i, k, Color.White);
                }
            }


            //Pix pix =PixConverter.ToPix(bitmap);
            
            var ocr = new TesseractEngine(Datapath, setLanguage.soursLanuage);
            Pix pix = Pix.LoadFromFile(imgsrc);
            texts = ocr.Process(pix);
            textBox1.Text = texts.GetText();
        }

        private void button1_Click(object sender, EventArgs e)//Transelate
        {
            Transelate transelate = new Transelate();
            MessageBox.Show(transelate.Query(texts.GetText()));
        }

        private void button3_Click(object sender, EventArgs e)//Imagesave
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cd = (ComboBox)sender;
            setLanguage.SetSoursLanuage(cd);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cd = (ComboBox)sender;
            setLanguage.SetTargetLanuage(cd);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    

        private void button1_Click_1(object sender, EventArgs e) //이미지 가져오기
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                imgsrc = openFileDialog.FileName;
            try
            {
               Bitmap bmp = new Bitmap(imgsrc);
                bitmap = bmp;
                pictureBox1.Image = bitmap;
            }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//원문 텍스트 박스
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//번역된 텍스트 박스
        {

        }
    }
}
