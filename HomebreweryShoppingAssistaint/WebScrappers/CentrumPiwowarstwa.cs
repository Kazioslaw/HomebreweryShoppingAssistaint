using HtmlAgilityPack;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebScrapperCode.WebScrappers
{
    internal class CentrumPiwowarstwa
    {
        public class ProductCentrumPiwowarstwa
        {
            public string? Link { get; set; }
            [JsonPropertyName("Nazwa")]
            public string? Name { get; set; }
            [JsonPropertyName("Cena")]
            public string? Price { get; set; }
            [JsonPropertyName("Nazwa Sklepu")]
            public string? ShopName { get { return "Centrum Piwowarstwa"; } set { } }
        }
        public static void WebScrapper()
        {
            var site = "https://www.browar.biz/centrumpiwowarstwa/szybkie_zamawianie";
            var web = new HtmlWeb();
            var products = new List<ProductCentrumPiwowarstwa>();
            var currentDocument = web.Load(site);
            var productHTMLElements = currentDocument.DocumentNode.QuerySelectorAll("div.fastshop_item_wrapper");
            foreach (var productHTMLElement in productHTMLElements)
            {
                var link = "https://www.browar.biz" + HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("div.fastshop_item_data > a").Attributes["href"].Value);
                var name = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("div.fastshop_item_data > a").InnerText);
                var price = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("div.fastshop_item_price").InnerText) + "zł";
                var product = new ProductCentrumPiwowarstwa() { Link = link, Name = name, Price = price };
                products.Add(product);
            }

            // Weryfikator scrappera
            int itemNum = 1;
            foreach (var product in products)
            {
                Console.WriteLine("ID: " + itemNum);
                Console.WriteLine("Nazwa: " + product.Name);
                Console.WriteLine("Cena: " + product.Price);
                Console.WriteLine("Link do produktu: " + product.Link);
                Console.WriteLine();
                itemNum++;

            }

            var jsonFile = "CentrumPiwowarstwa.json";
            var jsonString = JsonSerializer.Serialize(products);
            using (StreamWriter writer = new StreamWriter(jsonFile, true))
            {
                writer.WriteLine(jsonString);
            }
            Console.WriteLine("Serialized?");
        }
    }
}


