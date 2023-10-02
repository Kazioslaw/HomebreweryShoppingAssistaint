using HomebreweryShoppingAssistaint.Models;
using HtmlAgilityPack;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HomebreweryShoppingAssistaint.WebScrappers
{
    internal class BrowamatorWebScrapper
    {
        public static void Run()
        {
            var sites = new List<string> { "https://browamator.pl/produkty/piwo/2-282?sort=12&pageId=1#products",
                                           "https://browamator.pl/produkty/wino/2-94?sort=12&pageId=1#products",
                                           "https://browamator.pl/produkty/cydr/2-236?sort=12&pageId=1#products",
                                           "https://browamator.pl/produkty/nalewki/2-158?sort=12&pageId=1#products",
                                           "https://browamator.pl/produkty/destylaty/2-203?sort=12&pageId=1#products" };

            var web = new HtmlWeb();
            var products = new List<Product>();

            foreach (var site in sites)
            {
                var firstSiteToScrape = site;
                var sitesDiscovered = new List<string> { firstSiteToScrape };
                var sitesToScrape = new Queue<string>();

                sitesToScrape.Enqueue(firstSiteToScrape);

                int i = 1;
                int limit = 100;

                while (sitesToScrape.Count != 0 && i < limit)
                {
                    var currentSite = sitesToScrape.Dequeue();

                    var currentDocument = web.Load(currentSite);

                    var paginationHTMLElements = currentDocument.DocumentNode.QuerySelectorAll("li.pagination__link > a[aria-label=\"extraClass\"]");
                    foreach (var paginationHTMLElement in paginationHTMLElements)
                    {
                        var newPaginationLink = "https://browamator.pl" + paginationHTMLElement.Attributes["href"].Value;
                        if (!sitesDiscovered.Contains(newPaginationLink))
                        {
                            if (!sitesToScrape.Contains(newPaginationLink))
                            {
                                sitesToScrape.Enqueue(newPaginationLink);
                            }
                            sitesDiscovered.Add(newPaginationLink);
                        }
                    }

                    var productHTMLElements = currentDocument.DocumentNode.QuerySelectorAll("div.product-item");
                    foreach (var productHTMLElement in productHTMLElements)
                    {
                        var link = "https://browamator.pl/" + HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("a").Attributes["href"].Value);
                        var name = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("h2").InnerText);
                        var price = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("span:nth-child(4)").InnerText);
                        //var isAvailable = brak "niedostępnych" produktów jedynie na zamówienie.
                        var product = new Product() { ProductLink = link, ProductName = name, ProductPrice = price };
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
                    Console.WriteLine("Link do produktu: " + product.ProductLink);
                    Console.WriteLine();
                    itemNum++;
                } */
            }
            /*
            var jsonFile = "Browamator.json";
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

