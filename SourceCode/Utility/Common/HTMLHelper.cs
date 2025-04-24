using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Utility
{
    public class HTMLHelper
    {
        public static string GetErrorMessage(string htmlContent)
        {
            string retMessage = "";
            // Load HTML into HtmlDocument
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            // Extract error message parts using XPath
            var h3Node = doc.DocumentNode.SelectSingleNode("//h3");
            var h4Node = doc.DocumentNode.SelectSingleNode("//h4");

            // Combine the messages
            if (h3Node != null && h4Node != null)
            {
                retMessage = $"{h3Node.InnerText} - {h4Node.InnerText}";
            }
            else
            {
                retMessage=htmlContent;
            }
            return retMessage;
        }
    }
}
