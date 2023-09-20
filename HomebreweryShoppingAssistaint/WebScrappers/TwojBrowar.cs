using HtmlAgilityPack;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebScrapperCode.WebScrappers
{
    internal class TwojBrowar
    {
        public class ProductTwojBrowar
        {
            public string? Link { get; set; }
            [JsonPropertyName("Nazwa")]
            public string? Name { get; set; }
            [JsonPropertyName("Cena")]
            public string? Price { get; set; }
            [JsonPropertyName("Nazwa Sklepu")]
            public string? ShopName { get { return "Twój Browar"; } set { } }
        }

        public static void WebScrapper()
        {
            var sites = new List<string>
            {
                "https://twojbrowar.pl/pl/ekstrakty-slodowe",
                "https://twojbrowar.pl/pl/slody",
                "https://twojbrowar.pl/pl/zestawy-surowcow-piwowarskich",
                "https://twojbrowar.pl/pl/dodatki-piwowarskie",
                "https://twojbrowar.pl/pl/drozdze-piwowarskie",
                "https://twojbrowar.pl/pl/brewkity",
                "https://twojbrowar.pl/pl/chmiele"
            };
            var web = new HtmlWeb();
            var products = new List<ProductTwojBrowar>();
            foreach (var site in sites)
            {
                var firstSiteToScrape = site;
                var sitesDiscovered = new List<string> { firstSiteToScrape };
                var sitesToScrape = new Queue<string>();

                sitesToScrape.Enqueue(firstSiteToScrape);

                int i = 1;
                int limit = 1000;

                while (sitesToScrape.Count != 0 && i < limit)
                {
                    var currentSite = sitesToScrape.Dequeue();
                    var currentDocument = web.Load(currentSite);
                    var paginationHTMLElements = currentDocument.DocumentNode.QuerySelectorAll("ul.pagination > li > a");
                    foreach (var paginationHTMLElement in paginationHTMLElements)
                    {
                        var newPaginationLink = "https://twojbrowar.pl" + paginationHTMLElement.Attributes["href"].Value;
                        if (!sitesDiscovered.Contains(newPaginationLink))
                        {
                            if (!sitesToScrape.Contains(newPaginationLink))
                            {
                                sitesToScrape.Enqueue(newPaginationLink);
                            }
                            sitesDiscovered.Add(newPaginationLink);
                        }
                    }

                    var productHTMLElements = currentDocument.DocumentNode.QuerySelectorAll("li.pla_block");
                    foreach (var productHTMLElement in productHTMLElements)
                    {
                        var link = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("a.product-name").Attributes["href"].Value);
                        var name = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("a.product-name").InnerText);
                        var price = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("span.product-price").InnerText);
                        var product = new ProductTwojBrowar() { Link = link, Name = name, Price = price };
                        products.Add(product);
                    }
                    Console.WriteLine("Scraped: " + i + " page");
                    i++;

                }
                int itemNum = 1;
                foreach (var product in products)
                {
                    Console.WriteLine("ID: " + itemNum);
                    Console.WriteLine("Nazwa: " + product.Name);
                    Console.WriteLine("Cena: " + product.Price);
                    Console.WriteLine("Link: " + product.Link);
                    Console.WriteLine();
                    itemNum++;
                }

            }

            var jsonFile = "TwojBrowar.json";
            var jsonString = JsonSerializer.Serialize(products);
            using (StreamWriter writer = new StreamWriter(jsonFile, true))
            {
                writer.WriteLine(jsonString);
            }
            Console.WriteLine("Serialized?");
        }
    }
}


