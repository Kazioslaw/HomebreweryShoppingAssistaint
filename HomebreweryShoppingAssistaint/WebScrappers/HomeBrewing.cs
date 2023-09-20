using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace WebScrapperCode.WebScrappers
{
    internal class HomeBrewing
    {
        public class ProductHomeBrewery
        {
            public string? Link { get; set; }
            [JsonPropertyName("Nazwa")]
            public string? Name { get; set; }
            [JsonPropertyName("Stara Cena")]
            public string? OldPrice { get; set; }
            [JsonPropertyName("Nowa Cena")]
            public string? NewPrice { get; set; }
            [JsonPropertyName("Nazwa Sklepu")]
            public string? ShopName { get { return "HomeBrewery"; } set { } }
        }

        public static void WebScrapper()
        {
            var sites = new List<string>
            {
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=82",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=18",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=4",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=29",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=1",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=26",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=38",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=44",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=83",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=43",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=39",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=42",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=32",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=40",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=8",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=41",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=37",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=51",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=45",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=52",
                "https://homebrewing.pl/pobierz-cennik.html/typ=html/id=55"
            };

            var html = new HtmlWeb();
            var products = new List<ProductHomeBrewery>();

            foreach (var site in sites)
            {
                var currentDoc = html.Load(site);
                var i = 7;
                //var limit = 1000;
                var countTags = currentDoc.DocumentNode.QuerySelectorAll("tr").Count();

                while (i <= countTags)
                {
                    var productHTMLElements = currentDoc.DocumentNode.QuerySelectorAll($"tr:nth-child({i})");
                    foreach (var productHTMLElement in productHTMLElements)
                    {
                        var link = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("a").Attributes["href"].Value);
                        var name = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("td:nth-child(1)").InnerText);
                        var price = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("td:nth-child(2)").InnerText);
                        var oldPrice = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("td:nth-child(4)").InnerText);
                        var product = new ProductHomeBrewery() { Link = link, Name = name, NewPrice = price, OldPrice = oldPrice };
                        products.Add(product);
                    }
                    //Console.WriteLine(countTags);
                    Console.WriteLine("Scraped: " + i + " line");
                    i++;
                }
                int itemNum = 1;

                foreach (var product in products)
                {
                    Console.WriteLine("ID: " + itemNum);
                    Console.WriteLine("Nazwa: " + product.Name);
                    Console.WriteLine("Cena: " + product.NewPrice);
                    Console.WriteLine("Stara Cena: " + product.OldPrice);
                    Console.WriteLine("Link: " + product.Link);
                    Console.WriteLine();
                    itemNum++;
                }

            }

            var jsonFile = "HomeBrewery.json";
            var jsonString = JsonSerializer.Serialize(products);
            using (StreamWriter writer = new StreamWriter(jsonFile, true))
            {
                writer.WriteLine(jsonString);
            }
            Console.WriteLine("Serialized?");
        }

    }

}
