using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork9
{
   public class Crawler
   {
        private Hashtable urls = new Hashtable(); 
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];

            myCrawler.urls.Add(startUrl, false);                //加入初始页面
            new Thread(myCrawler.Crawl).Start();                //开始爬行
        }
        private void Crawl()
        {
            Console.WriteLine("开始爬行了.....");
            while (true)
            {
                string current = null;
                ArrayList htmls = new ArrayList();
                Parallel.For(0, 10, i =>
                    {
                        foreach (string url in urls.Keys)
                            htmls.Add(DownLoad(url));
                        count++;
                    });

                if (current == null || count > 10) break;
                
                foreach (string html in htmls)              
                {
                    Parse(html);
                }
                urls[current] = true;
            }
            Console.WriteLine("爬行结束");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html= webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return " ";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef=match.Value.Substring(match.Value.IndexOf('=')+1).Trim('"','\\','#','>');
                if(strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
   }
    
}
