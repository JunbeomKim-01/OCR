using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;




namespace dwqeqw
{
    public class Transelate :Opserver
    {
        
        const string url = "https://openapi.naver.com/v1/papago/n2mt";
        private string client;
        private string secret;
        Concretesubject _subject;
        private string sours = "en";
        private string target = "en";


        void LanguageSetter()
        {
            if ( SetLanguage.soursLanuage== "kor")
                sours = "ko";
            if (SetLanguage.targetLanguage == "kor")
                target = "ko";
        }
        public void Init(string cl,string sec,Concretesubject concretesubject)
        {
            _subject = concretesubject;
            concretesubject.registerObserver(this);
            client = cl;
            secret = sec;
        }

       public string Query(string query)
        {
           

           
            LanguageSetter();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "4nkoRVSFAPHZ76887wv1");
            request.Headers.Add("X-Naver-Client-Secret", "S52kXi52p2");
            request.Method = "POST";
        
            string parse = "source=" +sours + "&target=" +target + "&text="+query ;

            byte[] byteDataParams = Encoding.UTF8.GetBytes(parse);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteDataParams.Length;

            Stream st = request.GetRequestStream();
            st.Write(byteDataParams, 0, byteDataParams.Length);
            st.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();
            stream.Close();
            response.Close();
            reader.Close();

            string translated_Text = "";
            int start_index = text.IndexOf("translatedText") + 17;
            int end_index = text.IndexOf("engineType") - 3;

            for (int i = start_index; i < end_index; ++i)
                translated_Text += text[i];

            return translated_Text;

        }

        public void update(string ls)
        {
           
        }

       
    }
}
