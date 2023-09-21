using Microsoft.AspNetCore.Mvc;
using WebScrapper.Models;


namespace WebScrapper.Controllers
{
    public class ScrapperController : Controller
    {
        public IActionResult Index()
        {
            string url = "https://www.game.co.za/Home-Appliances/Kitchen-Large-Appliances/Built-In-Ovens/l/c/G3056";
            string className = "css-901oao css-cens5h r-1tvphgr r-ukjfwf r-1b43r93 r-14yzgew r-14gqq1x r-17j37da";
            var scraper = new ScrapeGame();
            Task<List<string>> scrapeTask = scraper.ScrapeWebsite(url, className);
            scrapeTask.Wait();

            List<string> extractedTextList = scrapeTask.Result;

            ViewBag.ExtractedText = extractedTextList;
            return View();
        }
    }

}
