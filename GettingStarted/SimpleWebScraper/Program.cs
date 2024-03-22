using System.Text.RegularExpressions;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;

namespace SimpleWebScraper;

public class Program
{
    private const string Method = "search";
    public static async Task Main(string[] args)
    {
        try
        {
            Console.Write("Please enter which city you would like to scrape information from: ");
            var craigsListCity = Console.ReadLine() ?? String.Empty;
            
            Console.Write("Please enter the craigsList category that you would like to scrape: ");
            var craigsListCat = Console.ReadLine() ?? String.Empty;

            // http request uses HttpClient
            HttpClient httpClient = new();
            string url = $"https://{craigsListCity.Replace(" ", String.Empty)}.craigslist.org/{Method}/{craigsListCat}";
            
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
            using HttpResponseMessage response = await httpClient.SendAsync(message);
            
            string content = await response.Content.ReadAsStringAsync();
            
            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(
                    @"<li class=""(.*?)"" title=""(.*?)"">(.*?)</li>")
                .WithRegexOption(RegexOptions.Singleline)
                .WithPart(new ScrapeCriteriaPartBuilder()
                    .WithRegex(@"<div class=""title"">(.*?)</div>") // scrape description
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .WithPart(new ScrapeCriteriaPartBuilder()
                    .WithRegex(@"<a href=""(.*?)"">") // scrape href value (url)
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .Build();

            Scraper scraper = new Scraper();
            var scrapedElements = scraper.Scrape(scrapeCriteria);

            if (scrapedElements.Any())
            {
                foreach (var scrapedElement in scrapedElements) Console.WriteLine(scrapedElement);
            }
            else
            {
                Console.WriteLine("There were no matches for the specified scrape criteria.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
