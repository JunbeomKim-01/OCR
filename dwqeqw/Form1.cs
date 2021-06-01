
using System;
using System.Collections;
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
    public partial class Form1 : Form,Subject
    {
        private const string Datapath = @"C:\Users\user\source\repos\OCR\dwqeqw\bin\Debug\netcoreapp3.1\tessdata";
        SetLanguage setLanguage = new SetLanguage();
        Concretesubject concretesubject = new Concretesubject();
        IList _observers = new ArrayList();
        Bitmap bitmap = null;
        string imgsrc = null;
        string texts = null;
        public Form1()
        {

            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e) //cap
        {
            OCR ocrs = new OCR(bitmap,Datapath);
            ocrs.Process(imgsrc);
            texts=ocrs.Process(imgsrc);
            textBox1.Text = texts;
        }

        private void button1_Click(object sender, EventArgs e)//Transelate
        {
            Transelate transelate = new Transelate();
            transelate.Init("4nkoRVSFAPHZ76887wv1", "S52kXi52p2",concretesubject);
            textBox2.Text=transelate.Query(texts);
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
            notifyObservers();
            setLanguage.SetTargetLanuage(cd);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    

        private void button1_Click_1(object sender, EventArgs e) //이미지 가져오기
        {
            BringImage bringimage = new BringImage();
            imgsrc = bringimage.Set();
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Table table = new Table();
            table.Add(textBox1.Text,textBox2.Text);
            dataGridView1.DataSource = table.GetTable();
        }

        public void registerObserver(Opserver opserver)
        {
            throw new NotImplementedException();
        }

        public void removeObserver(Opserver opserver)
        {
            throw new NotImplementedException();
        }

        public void notifyObservers()
        {
            foreach(Opserver opserver in _observers)
                opserver.update(texts);
        }
    }
}
