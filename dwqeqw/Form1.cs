
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
    public partial class Form1 : Form, Subject
    {
        private const string Datapath = @"C:\Users\user\source\repos\OCR\dwqeqw\bin\Debug\netcoreapp3.1\tessdata";
        private const string junpath = @"C:\windowForm_Project\OCR1\dwqeqw\bin\Debug\netcoreapp3.1\tessdata";

        
        IList _observers = new ArrayList();
        DataTable dataTable = new DataTable();
        int[] _index = { 0, 0 };//0번 인덱스는 원본언어, 1번 인덱스는 번역언어
        Bitmap bitmap = null;
        string imgsrc = null;
        OCR ocrs=null;
        Transelate transelate;
        Table table;
        public Form1()
        {
            table = new Table(dataTable, this);
            ocrs = new OCR(this);
            transelate = new Transelate(this);
            table.AddColumns("날짜");
            table.AddColumns("원문내용");
            table.AddColumns("번역내용");
            table.AddColumns("원문언어");
            table.AddColumns("번역언어");

            InitializeComponent();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e) //cap
        {
            try
            {
                ocrs.Init(bitmap, junpath);
                if (bitmap == null)
                    throw new Exception("사진또는 내용이 존재하지 않습니다.");
                textBox1.Text = ocrs.Process(imgsrc);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)//Transelate
        {
            try
            {
                transelate.Init("4nkoRVSFAPHZ76887wv1", "S52kXi52p2");
                if (textBox1.Text == "")
                    throw new Exception("텍스트박스에 내용이 없습니다.");
                textBox2.Text = transelate.Query(textBox1.Text);
                Table table = new Table(dataTable, this);
                table.AddRows(textBox1.Text, textBox2.Text);
                dataGridView1.DataSource = table.GetTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)//Imagesave
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            ComboBox cd = (ComboBox)sender;
            _index[0] = cd.SelectedIndex;
            
            notifyObservers();
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ComboBox cd = (ComboBox)sender;
            _index[1] = cd.SelectedIndex;
            notifyObservers();
           
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
          
            table.AddRows(textBox1.Text,textBox2.Text);
            dataGridView1.DataSource = table.GetTable();
        }

        public void registerObserver(Opserver opserver)
        {
            _observers.Add(opserver);
        }

        public void removeObserver(Opserver opserver)
        {
            _observers.Remove(opserver);

        }

        public void notifyObservers()
        {
            foreach(Opserver opserver in _observers)
                opserver.update(_index);

        }
    }
}
