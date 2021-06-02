using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Tesseract;
using static System.Net.Mime.MediaTypeNames;

namespace dwqeqw
{
    class OCR: Opserver,ILanguageSetter
    {
        private Bitmap bitmap;
        Subject _subject;
        private string path;
        private string sourse;
        
        public OCR(Subject subject)
        {
            _subject = subject;
            subject.registerObserver(this);
            
        }
        public void Init(Bitmap bitmap, string path)
        {
            this.bitmap = bitmap;
            this.path = path;
        }
       public void ToBinary()
        {
            for (int i = 0; i < bitmap.Width; ++i)
            {
                for (int k = 0; k < bitmap.Height; ++k)
                {
                    Color color = bitmap.GetPixel(i, k);
                    int binary = (color.R + color.G + color.B) / 3;
                    if (binary > 200)
                        bitmap.SetPixel(i, k, Color.Black);
                    else
                        bitmap.SetPixel(i, k, Color.White);
                }
            }
        }
       public string Process(string imgsrc)
        {
            ToBinary();
            var ocr = new TesseractEngine(path, sourse, EngineMode.Default);
            Pix pix = Pix.LoadFromFile(imgsrc);
            Page texts = ocr.Process(pix);
            return texts.GetText();
        }
        public void update(int[] index)=>SetLanguage(index);
        public void SetLanguage(int[] index) =>sourse = index[0] == 0 ? "kor" : "eng";
         
        
    }
}
