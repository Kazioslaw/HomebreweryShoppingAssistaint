using HomebreweryShoppingAssistaint.Models;
using HtmlAgilityPack;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HomebreweryShoppingAssistaint.WebScrappers
{
    internal class TwojBrowarWebScrapper
    {

        public static List<Product> Run()
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
            var products = new List<Product>();
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
                        var isAvailable = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector(".pb-available-title > span:nth-child(1)").InnerText) == "Chwilowy brak towaru" ? false : true;
                        var product = new Product()
                        {
                            ProductLink = link,
                            ProductName = name,
                            ProductPrice = decimal.Parse(price),
                            IsAvailable = isAvailable,
                            ShopID = (int)ShopNameEnum.TwojBrowar,
                            CategoryID = (int)ProductCategory.Inne /* Tymczasowe przypisywanie do kategori inne*/
                        };
                        products.Add(product);
                    }
                    Console.WriteLine("Scraped: " + i + " page");
                    i++;

                }
                /*
                int itemNum = 1;
                foreach (var product in products)
                {
                    Console.WriteLine("ID: " + itemNum);
                    Console.WriteLine("Nazwa: " + product.ProductName);
                    Console.WriteLine("Cena: " + product.ProductPrice);
                    Console.WriteLine("Link: " + product.ProductLink);
                    Console.WriteLine();
                    itemNum++;
                }
                */

            }
            return products;
            /*
            var jsonFile = "TwojBrowar.json";
            var jsonString = JsonSerializer.Serialize(products);
            using (StreamWriter writer = new StreamWriter(jsonFile, true))
            {
                writer.WriteLine(jsonString);
            }
            Console.WriteLine("Serialized?");
            */
        }
    }
}


