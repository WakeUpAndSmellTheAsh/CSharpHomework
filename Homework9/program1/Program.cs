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
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            Program myCrawer = new Program();
            string startUrl = "https://www.zhihu.com/search?type=content&q=%E5%89%8D%E7%AB%AF%E6%97%A5%E5%B8%B8";
            if (args.Length >= 1) startUrl = args[0];
            myCrawer.urls.Add(startUrl, false);     //加入初始页面
            new Thread(myCrawer.Crawl).Start();

        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了....");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)    //找到一个还没有下载过的链接
                {
                    if ((bool)urls[url])          //已经下载过的，不再下载
                        continue;
                    current = url;
                }             
                if (current == null || count > 100)   
                    break;
                Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current);  //下载
                urls[current] = true;
                count++;
                Parse(html);                    //解析,并加入断的链接
                Console.WriteLine("爬行结束");
            }

        }
        public string DownLoad(string url)
        {

            try {

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;

                string html = webClient.DownloadString(url);

                string fileName = count.ToString();

                File.WriteAllText(fileName, html, Encoding.UTF8); return html;
            }

            catch (Exception ex) {

                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html) {
            string strRef = @"(href|HREF)[ ]*=[ ]*[""'][^""'#(img)]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\\', '#', ' ', '>');

                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }


    }
}
