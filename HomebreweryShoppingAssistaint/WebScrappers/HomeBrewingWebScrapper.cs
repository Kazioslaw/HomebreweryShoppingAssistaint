using HomebreweryShoppingAssistaint.Models;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace HomebreweryShoppingAssistaint.WebScrappers
{
    internal class HomeBrewingWebScrapper
    {

        public static List<Product> Run()
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

            var web = new HtmlWeb();
            var products = new List<Product>();

            foreach (var site in sites)
            {
                var currentDoc = web.Load(site);
                var i = 7;
                var countTags = currentDoc.DocumentNode.QuerySelectorAll("tr").Count();

                while (i <= countTags)
                {
                    var productHTMLElements = currentDoc.DocumentNode.QuerySelectorAll($"tr:nth-child({i})");
                    foreach (var productHTMLElement in productHTMLElements)
                    {
                        var link = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("a").Attributes["href"].Value);
                        var name = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("td:nth-child(1)").InnerText);
                        var price = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("td:nth-child(2)").InnerText.Replace(" zł", "").Replace(" ", ""));
                        var oldPrice = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("td:nth-child(4)").InnerText.Replace(" zł", "").Replace(" ", ""));
                        //var isAvailable = Brak jednoznacznego oznaczenia dostępności produktu.

                        decimal product30DaysPrice;

                        if (!decimal.TryParse(oldPrice, out product30DaysPrice))
                        {
                            product30DaysPrice = 0;
                        }
                        else
                        {
                            product30DaysPrice = decimal.Parse(oldPrice);
                        }

                        var product = new Product()
                        {
                            ProductLink = link,
                            ProductName = name,
                            ProductPrice = decimal.Parse(price),
                            Product30DaysPrice = product30DaysPrice,
                            ShopID = (int)ShopNameEnum.Homebrewing,
                            CategoryID = (int)ProductCategory.Inne /* Tymczasowe przypisywanie do kategori inne*/

                        };
                        products.Add(product);
                    }
                    //Console.WriteLine(countTags);
                    Console.WriteLine("Scraped: " + i + " line.");
                    i++;
                }
                /*
                int itemNum = 1;

                foreach (var product in products)
                {
                    Console.WriteLine("ID: " + itemNum);
                    Console.WriteLine("Nazwa: " + product.ProductName);
                    Console.WriteLine("Cena: " + product.ProductPrice);
                    Console.WriteLine("Stara Cena: " + product.Product30DaysPrice);
                    Console.WriteLine("Link: " + product.ProductLink);
                    Console.WriteLine();
                    itemNum++;
                }
                */

            }
            return products;

            /*
            var jsonFile = "HomeBrewery.json";
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
