using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace VOA
{
    class ClassHTML
    {     
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string html;

        public string Html
        {
            get { return html; }
            set { html = value; }
        }

        public ClassHTML()
        {
            url = "";
            html = "";
        }

        public Boolean GetHTML()
        {                           
            try
            {
                WebRequest req = WebRequest.Create(url);
                req.Timeout = 10 * 1000;
                WebResponse result = req.GetResponse();
                //得到的流是网页内容   
                Stream ReceiveStream = result.GetResponseStream();
                StreamReader readerOfStream = new StreamReader(ReceiveStream,
                                System.Text.Encoding.GetEncoding("UTF-8"));
                html = readerOfStream.ReadToEnd();
                ReceiveStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ArrayList GetVOAList(int num, string type)
        {
            string matchHtml="";
            ArrayList voaList = new ArrayList();
            Match m = Regex.Match(html, "<span id=\"blist\">.*</span>");
            if (m.Success)
            {
                matchHtml = m.ToString();
            }
            else
            {
                matchHtml = html.Substring(html.IndexOf("<span id=\"blist\">"));
                matchHtml = matchHtml.Substring(0,matchHtml.IndexOf("</span>"));
            }
            string pat = "(<li>.*?href=\"(.*?)\" target=_blank>(.*?)</a>(.*?)</li>)";
            Regex r = new Regex(pat);
            Match m2 = r.Match(matchHtml);
            int i = 0;
            while (m2.Success)
            {
                try
                {
                    i++;
                    LearningEnglish.ClassVOA voa = new LearningEnglish.ClassVOA();
                    //根据type组合URL
                    if (type.Equals("Go English") || type == "Wordmaster" || type == "Bilingual News" || type == "Popular American" || 
                        type == "Business Etiquette" || type == "Sports English" || type == "Words And Idioms" ||
                        type == "Intermediate American Enlish" || type == "American Cafe")
                    {
                        voa.HtmlUrl = "http://www.51voa.com/" + m2.Groups[2].ToString();
                    }
                    else
                    {
                        voa.HtmlUrl = "http://www.51voa.com" + m2.Groups[2].ToString();
                    }                    
                    voa.Mp3Url = "";
                    voa.Name = m2.Groups[3].ToString();
                    voa.Type = type;
                    try
                    {
                        voa.Date = Convert.ToDateTime("20" + m2.Groups[4].ToString().Substring(m2.Groups[4].ToString().IndexOf('(') + 1, m2.Groups[4].ToString().IndexOf(')') - 2));
                    }
                    catch (Exception ex)
                    { 
                        //没有匹配到日期
                        voa.Date = Convert.ToDateTime("1900/1/1");
                    }
                    if (i <= num)
                    {
                        voaList.Add(voa);
                    }
                }
                catch (Exception ex)
                { 
                    
                }
                m2 = m2.NextMatch();
            }
            return voaList;
        }

        public string GetVOAUrl()
        {
            Match m = Regex.Match(html, "<a href=\"(.*?).mp3\">", RegexOptions.IgnoreCase);
            if (m.Success)
            {
                return  m.Groups[1].ToString() + ".mp3";
            }
            else
            {
                return null;
            }               
        }

        public string GetLRCUrl()
        {
            Match m = Regex.Match(html, "</a><a href=(.*?).lrc>", RegexOptions.IgnoreCase);
            if (m.Success)
            {
                return "http://www.51voa.com" + m.Groups[1].ToString() + ".lrc";
            }
            else
            {
                return null;
            }
        }
    }
}
