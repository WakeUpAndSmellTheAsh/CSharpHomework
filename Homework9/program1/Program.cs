using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

using System.Collections;

using System.IO;

using System.Diagnostics;

namespace program1
{
    class Program
    {
        private Queue<string> urls = new Queue<string>();
        private int count = 0;
        public int Num = 5;
        static void Main(string[] args)
        { 
            Program myCrawer = new Program();
            string startUrl = "https://www.zhihu.com/search?type=content&q=%E5%89%8D%E7%AB%AF%E6%97%A5%E5%B8%B8";
            if (args.Length >= 1) startUrl = args[0];
            myCrawer.urls.Enqueue(startUrl);
            Thread thread = new Thread(new ThreadStart(myCrawer.mutiCrawl));
            thread.Start();
            Console.ReadKey();
        }

        private void mutiCrawl()
        {


            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            Console.WriteLine("开始爬行了....");
            Thread[] threadn = new Thread[21];
            for (int i = 0; i < 5; i++)
            {         
                    if (urls.Count != 0)
                    {             
                        ThreadStart startDownload = new ThreadStart(() => Crawl());
                        threadn[i] = new Thread(startDownload);
                        threadn[i].Start();
                        i++;
                  
                    }
            }
           // Console.WriteLine("爬行结束....");
            //stopWatch.Stop();
            //Console.WriteLine("time cost:" + stopWatch.ElapsedMilliseconds);


        }
        public void Crawl()
        {
            lock (this)
            {
                while (urls.Count != 0 && count<100)
                {
                    string current = urls.Dequeue();
                    Console.WriteLine("爬行" + current + "页面!");
                    string html = DownLoad(current);
                    count++;
                    Parse(html);                            //解析并加入新的页面
                }
            }
        }
    
        public string DownLoad(string url)
        {

            try {
                lock (this)
                {
                    WebClient webClient = new WebClient();
                    webClient.Encoding = Encoding.UTF8;
                    string html = webClient.DownloadString(url);
                    string fileName = count.ToString();
                    File.WriteAllText(fileName, html, Encoding.UTF8);
                    return html;
                }
            }

            catch (Exception ex) {

                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            lock (this)
            {
                string strRef = @"(href|HREF)[ ]*=[ ]*[""'][^""'#(img)]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
         
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\\', '#', ' ', '>');

                    if (strRef.Length == 0)
                    { continue; }
                    if (count < 100)
                        urls.Enqueue(strRef);
                }
            }
        }
    }
}
