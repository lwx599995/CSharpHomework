using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CrawlTest
{
    public class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            Crawler myClawer = new Crawler();
            string[] starturls = {"https://www.baidu.com/",
                                    "https://hao.360.cn/" };
            foreach (string url in starturls)
                myClawer.urls.Add(url, false);   //加入初始界面
            new Thread(myClawer.Crawl).Start();   //开始爬行
        }
        private void Crawl()
        {
            Console.WriteLine("开始爬行了......");
            List<string> list = new List<string>();
            foreach (string url in urls.Keys)
            {
                if ((bool)list.Contains(url)) continue;    //已经添加过的不再添加
                list.Add(url);
            }
            Parallel.ForEach(list, (string url) =>         //并行处理
            {
                string current = url;
                Console.WriteLine("爬行" + current + "页面！");
                string html = DownLoad(current);   //下载
                urls[current] = true;
                Parse(html);
                count++;
            });
            Console.WriteLine("爬行结束");
        }
        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string filename = count.ToString()+".html";
                File.WriteAllText(filename, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF) [] * = [] * [""'][^""'#>]+[""']";

            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).
                    Trim('"', '\"', '#', ' ', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
