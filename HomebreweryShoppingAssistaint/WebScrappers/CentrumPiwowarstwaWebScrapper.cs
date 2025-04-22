using HomebreweryShoppingAssistaint.Models;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace HomebreweryShoppingAssistaint.WebScrappers
{
    internal class CentrumPiwowarstwaWebScrapper
    {

        public static List<Product> Run()
        {
            var site = "https://www.browar.biz/centrumpiwowarstwa/szybkie_zamawianie";
            var web = new HtmlWeb();
            var products = new List<Product>();
            var currentDocument = web.Load(site);
            var productHTMLElements = currentDocument.DocumentNode.QuerySelectorAll("div.fastshop_item_wrapper");
            foreach (var productHTMLElement in productHTMLElements)
            {
                var link = "https://www.browar.biz" + HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("div.fastshop_item_data > a").Attributes["href"].Value);
                var name = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("div.fastshop_item_data > a").InnerText);
                var price = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("div.fastshop_item_price").InnerText).Replace(" ", "");
                var isAvailable = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector(".id_avail_n").InnerText) == "N" ? false : true;
                var product = new Product()
                {
                    ProductLink = link,
                    ProductName = name,
                    ProductPrice = decimal.Parse(price),
                    Product30DaysPrice = 0,
                    IsAvailable = isAvailable,
                    ShopID = (int)ShopNameEnum.CentrumPiwowarstwa,
                    //CategoryID = (int)ProductCategory.Inne, /* Tymczasowe przypisywanie do kategori inne*/
                };
                products.Add(product);
            }

            return products;

        }
    }
}


