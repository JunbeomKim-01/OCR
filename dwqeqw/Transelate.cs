using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;




namespace dwqeqw
{
    public class Transelate : ILanguageSetter
    {
        private string sours_language;
        private string target_language;
        const string url = "http://openapi.naver.com/v1/papago/n2mt";
        private string client;
        private string secret;

        void ILanguageSetter.SetLanguage(int sours, int target)
        {
            sours_language = sours == 0 ? "ko" : "en";
            target_language = target == 0 ? "ko" : "en";
        }
        public void Init(string cl,string sec)
        {
            client = cl;
            secret = sec;
        }

        void Query(string query)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id",client);
            request.Headers.Add("X-Naver-Client-Secret", secret);
            request.Method = "POST";

            string parse = "source" + sours_language + "&target" + target_language + "&text=" + query;

            byte[] byteDataParams = Encoding.UTF8.GetBytes(parse);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteDataParams.Length;

            Stream st = request.GetRequestStream();
            st.Write(byteDataParams, 0, byteDataParams.Length);
            st.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);


        }
    }
}
