using System.Net.Http;
using HtmlAgilityPack.CssSelectors;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace WebScrapper.Models;
public class ScrapeGame
{
    public async Task<List<string>> ScrapeWebsite(string url, string className)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string htmlContent = await response.Content.ReadAsStringAsync();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlContent);

            List<string> extractedTextList = new();

            foreach ( HtmlNode element in htmlDocument.DocumentNode.Descendants().Where(d => d.HasClass(className)))
            {
                extractedTextList.Add(element.InnerText);
            }

            //var element = htmlDocument.DocumentNode.SelectSingleNode("//h1");

            //string? extractedText = element?.InnerText;

            return extractedTextList;
        }
    }
}
