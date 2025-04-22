using HomebreweryShoppingAssistaint.Models;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

//Do naprawy bo nadal nie działa
namespace HomebreweryShoppingAssistaint.WebScrappers
{
    internal class AlePiwoWebScrapper
    {
        public static List<Product> Run()
        {
            var web = new HtmlWeb();
            var products = new List<Product>();

            //var firstSiteToScrape = "C:\\Users\\Kazioslaw\\Downloads\\Grupy produktów - Alepiwo.pl.htm";
            var firstSiteToScrape = "https://www.alepiwo.pl/?produkty/";
            var sitesDiscovered = new List<string> { firstSiteToScrape };
            var sitesToScrape = new Queue<string>();

            sitesToScrape.Enqueue(firstSiteToScrape);

            int i = 1;
            int limit = 100;

            while (sitesToScrape.Count != 0 && i < limit)
            {
                var currentSite = sitesToScrape.Dequeue();
                var currentDocument = web.Load(currentSite);
                var paginationHTMLElements = currentDocument.DocumentNode.QuerySelectorAll("div.pager > a");
                foreach (var paginationElement in paginationHTMLElements)
                {
                    var newPaginationLink = "https://www.alepiwo.pl/" + paginationElement.Attributes["href"].Value;

                    if (!sitesDiscovered.Contains(newPaginationLink))
                    {
                        sitesToScrape.Enqueue(newPaginationLink);
                    }
                    sitesDiscovered.Add(newPaginationLink);
                }

                var productHTMLElements = currentDocument.DocumentNode.QuerySelectorAll("div.item_bg");
                foreach (var productElement in productHTMLElements)
                {
                    var link = "https://www.alepiwo.pl/" + HtmlEntity.DeEntitize(productElement.QuerySelector("a").Attributes["href"].Value);
                    var name = HtmlEntity.DeEntitize(productElement.QuerySelector("p.title > a").InnerText);
                    var price = HtmlEntity.DeEntitize(productElement.QuerySelector("div.prices > div.price").InnerText);
                    //var isAvailable = Brak jednoznacznego oznaczenia dostępności produktu.
                    var product = new Product()
                    {
                        ProductLink = link,
                        ProductName = name,
                        ProductPrice = decimal.Parse(price),
                        ShopID = (int)ShopNameEnum.AlePiwo,
                        //CategoryID = (int)ProductCategory.Inne /* Tymczasowe przypisywanie do kategori inne*/ 
                    };
                    products.Add(product);
                }
                Console.WriteLine("Scraped: " + i + " page");
                i++;
            }

            return products;
        }
    }
}

