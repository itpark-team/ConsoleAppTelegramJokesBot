using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTelegramJokesBot
{
    internal class BashorgParser
    {
        private const string url = "http://bashorg.org/casual";
        private const string xPathEpression = "//div[@class='q']/div[2]";
        private HtmlWeb htmlWeb;

        public BashorgParser()
        {
            htmlWeb = new HtmlWeb();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            htmlWeb.OverrideEncoding = Encoding.GetEncoding("windows-1251");
        }

        public string GetRandomQuote()
        {
            HtmlDocument document = htmlWeb.Load(url);
            string innerText = document.DocumentNode.SelectSingleNode(xPathEpression).InnerHtml;

            innerText = innerText.Replace("&quot;", "\"").Replace("<br>","\n");

            //todo process innerText
            return innerText;
        }
    }
}
