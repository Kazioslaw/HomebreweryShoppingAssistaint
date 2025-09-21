using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistaint.WebScrappers;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistaint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebScrapperController : ControllerBase
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public WebScrapperController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        /*
        //[HttpPost("ScrappingAlePiwo")]        
        //To Fix
        //public ActionResult ScappingAlePiwo() 
        //{
        //    if(!_context.Product.Any(p=> p.ProductLink.Contains("https://alepiwo.pl/")))
        //    {
        //        AlePiwoWebScrapper.Run();
        //    }
        //    return Content("Baza została zapełniona");
        //}
        //[HttpPost("AlePiwoPriceCheck")]
        */

        [HttpPost("ScrappingBrowamator")]
        public async Task<ActionResult> ScrappingBrowamator()
        {
            List<Product> scrappedProducts = BrowamatorWebScrapper.Run();
            foreach (var scrappedProduct in scrappedProducts)
            {
                var existingProduct = _context.Products.FirstOrDefault(p => p.ProductLink == scrappedProduct.ProductLink);
                if (existingProduct == null)
                {
                    _context.Products.Add(scrappedProduct);
                }
                var productCheckHistory = new ProductCheckHistory()
                {
                    ProductID = scrappedProduct.ProductID,
                    CheckDateTime = DateTime.Now,
                };
                _context.ProductCheckHistories.Add(productCheckHistory);
            }

            var shopCheckHistory = new ShopCheckHistory()
            {
                ShopID = (int)ShopName.Browamator,
                CheckDateTime = DateTime.Now,
            };
            //Problem do rozwiązania związany z bazą danych
            _context.ShopCheckHistories.Add(shopCheckHistory);
            await _context.SaveChangesAsync();
            Console.WriteLine("Baza została zapełniona");
            return Ok("Baza została zapełniona");
        }

        [HttpPost("BrowamatorPriceCheck")]
        public async Task<IActionResult> BrowamatorPriceChange()
        {
            List<Product> productsFromDatabase = await _context.Products.ToListAsync();
            List<Product> updatedProduct = BrowamatorWebScrapper.Run();

            foreach (var product in productsFromDatabase)
            {
                var matchingProduct = updatedProduct.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct != null && matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: ");
                    _context.Products.Update(product);
                }
                var productCheckHistory = new ProductCheckHistory()
                {
                    ProductID = product.ProductID,
                    CheckDateTime = DateTime.Now,
                };

                _context.ProductCheckHistories.Add(productCheckHistory);
            }
            await _context.SaveChangesAsync();
            return Ok("Zaktualizowano ceny");
        }

        [HttpPost("ScrappingCentrumPiwowarstwa")]
        public async Task<ActionResult> ScrappingCentrumPiwowarstwa()
        {
            List<Product> scrappedProducts = CentrumPiwowarstwaWebScrapper.Run();
            foreach (var scrappedProduct in scrappedProducts)
            {
                var existingProduct = _context.Products.FirstOrDefault(p => p.ProductLink == scrappedProduct.ProductLink);
                if (existingProduct == null)
                {

                    await _context.Products.AddAsync(scrappedProduct);
                }
                var productCheckHistory = new ProductCheckHistory
                {
                    ProductID = scrappedProduct.ProductID,
                    CheckDateTime = DateTime.Now,
                };
                _context.ProductCheckHistories.Add(productCheckHistory);
            }

            var shopCheckHistory = new ShopCheckHistory()
            {
                ShopID = (int)ShopName.CentrumPiwowarstwa,
                CheckDateTime = DateTime.Now,
            };

            await _context.ShopCheckHistories.AddAsync(shopCheckHistory);
            await _context.SaveChangesAsync();
            Console.WriteLine("Baza została zapełniona");
            return Ok("Baza została zapełniona");
        }

        [HttpPost("CentrumPiwowarstwaPriceCheck")]
        public async Task<IActionResult> CentrumPiwowarstwaPriceChange()
        {
            List<Product> productsFromDatabase = await _context.Products.ToListAsync();
            List<Product> updatedProduct = CentrumPiwowarstwaWebScrapper.Run();

            foreach (var product in productsFromDatabase)
            {
                var matchingProduct = updatedProduct.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct != null && matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: " + product.ProductID);
                    _context.Products.Update(product);
                }

                var productCheckHistory = new ProductCheckHistory()
                {
                    ProductID = product.ProductID,
                    CheckDateTime = DateTime.Now
                };
                _context.ProductCheckHistories.Add(productCheckHistory);
            }
            await _context.SaveChangesAsync();
            return Ok("Zaktualizowano ceny");
        }

        [HttpPost("ScrappingHomebrewing")]
        public async Task<ActionResult> ScrappingHomeBrewing()
        {
            List<Product> scrappedProducts = HomeBrewingWebScrapper.Run();
            foreach (var scrappedProduct in scrappedProducts)
            {
                var existingProduct = _context.Products.FirstOrDefault(p => p.ProductLink == scrappedProduct.ProductLink);
                if (existingProduct == null)
                {
                    _context.Products.Add(scrappedProduct);
                }
                var productCheckHistory = new ProductCheckHistory
                {
                    ProductID = scrappedProduct.ProductID,
                    CheckDateTime = DateTime.Now
                };
                _context.ProductCheckHistories.Add(productCheckHistory);
            }

            var shopCheckHistory = new ShopCheckHistory()
            {
                ShopID = (int)ShopName.Homebrewing,
                CheckDateTime = DateTime.Now,
            };

            _context.ShopCheckHistories.Add(shopCheckHistory);
            await _context.SaveChangesAsync();
            Console.WriteLine("Baza została zapełniona");
            return Ok("Baza została zapełniona");
        }

        [HttpPost("HomebrewingPriceCheck")]
        public async Task<IActionResult> HomeBrewingPriceChange()
        {
            List<Product> productsFromDatabase = await _context.Products.ToListAsync();
            List<Product> updatedProduct = HomeBrewingWebScrapper.Run();

            foreach (var product in productsFromDatabase)
            {
                var matchingProduct = updatedProduct.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct != null && matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: " + product.ProductID);
                    _context.Products.Update(product);
                }

                var productCheckHistory = new ProductCheckHistory()
                {
                    ProductID = product.ProductID,
                    CheckDateTime = DateTime.Now
                };
                _context.ProductCheckHistories.Add(productCheckHistory);
            }
            await _context.SaveChangesAsync();
            return Ok("Zaktualizowano ceny");
        }

        [HttpPost("ScrappingTwojBrowar")]
        public async Task<ActionResult> ScrappingTwojBrowar()
        {
            List<Product> scrappedProducts = TwojBrowarWebScrapper.Run();
            foreach (var scrappedProduct in scrappedProducts)
            {
                var existingProduct = _context.Products.FirstOrDefault(p => p.ProductLink == scrappedProduct.ProductLink);
                if (existingProduct == null)
                {
                    _context.Products.Add(scrappedProduct);
                }
                var productCheckHistory = new ProductCheckHistory
                {
                    ProductID = scrappedProduct.ProductID,
                    CheckDateTime = DateTime.Now
                };
                _context.ProductCheckHistories.Add(productCheckHistory);
            }

            var shopCheckHistory = new ShopCheckHistory()
            {
                ShopID = (int)ShopName.TwojBrowar,
                CheckDateTime = DateTime.Now,
            };

            _context.ShopCheckHistories.Add(shopCheckHistory);
            await _context.SaveChangesAsync();
            return Ok("Baza została zapełniona");
        }

        [HttpPost("TwojBrowarPriceCheck")]
        public async Task<IActionResult> TwojBrowarPriceChange()
        {
            List<Product> productsFromDatabase = await _context.Products.ToListAsync();
            List<Product> updatedProduct = TwojBrowarWebScrapper.Run();

            foreach (var product in productsFromDatabase)
            {
                var matchingProduct = updatedProduct.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct != null && matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: " + product.ProductID);
                    _context.Products.Update(product);
                }

                var productCheckHistory = new ProductCheckHistory()
                {
                    ProductID = product.ProductID,
                    CheckDateTime = DateTime.Now
                };
                _context.ProductCheckHistories.Add(productCheckHistory);
            }
            await _context.SaveChangesAsync();
            return Ok("Zaktualizowano ceny");
        }

        [HttpPost("OneProductPriceCheck")]
        public async Task<IActionResult> OneProductPriceCheck([FromBody] Product product)
        {
            var web = new HtmlWeb();

            var currentDoc = web.Load(product.ProductLink);

            if (product.ProductLink.Contains("browamator"))
            {
                var name = HtmlEntity.DeEntitize(currentDoc.QuerySelector(".product-details__add-to-cart > h1:nth-child(2)").InnerText);
                var price = decimal.Parse(HtmlEntity.DeEntitize(currentDoc.QuerySelector("div.price > span:nth-child(1) > span:nth-child(1)").InnerText));
                var isAvailable = HtmlEntity.DeEntitize(currentDoc.QuerySelector(".availability-container > span:nth-child(3)").InnerText.ToLower()) == "od ręki" ? true : false;
                var quantity = HtmlEntity.DeEntitize(currentDoc.QuerySelector(".value-to-replace").InnerText);

                if (product.ProductPrice != price)
                {
                    product.ProductName = name;
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = price;
                    product.IsAvailable = isAvailable;
                    //Quantity = quantity,
                    _context.Products.Update(product);
                }
            }
            else if (product.ProductLink.Contains("centrumpiwowarstwa"))
            {
                var name = HtmlEntity.DeEntitize(currentDoc.QuerySelector(".column-prod > h2:nth-child(3) > a:nth-child(1)").InnerText);
                var price = decimal.Parse(HtmlEntity.DeEntitize(currentDoc.QuerySelector(".amount").InnerText + "," + currentDoc.QuerySelector(".amount > span:nth-child(1)").InnerText));
                var isAvailable = HtmlEntity.DeEntitize(currentDoc.QuerySelector("div.row:nth-child(2)").InnerText.ToLower()) == "\r\nprodukt znajduje się w magazynie" ? true : false;

                if (product.ProductPrice != price)
                {
                    product.ProductName = name;
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = price;
                    product.IsAvailable = isAvailable;
                    //Quantity = quantity,
                    _context.Products.Update(product);
                }
            }
            else if (product.ProductLink.Contains("homebrewing"))
            {
                var name = HtmlEntity.DeEntitize(currentDoc.QuerySelector(".NazwaProducent > h1:nth-child(1)").InnerText);
                var price = decimal.Parse(HtmlEntity.DeEntitize(currentDoc.QuerySelector("#CenaGlownaProduktuBrutto > strong:nth-child(1) > span:nth-child(1)").InnerText.Replace(" zł", "").Replace(" ", "")));
                var isAvailable = HtmlEntity.DeEntitize(currentDoc.QuerySelector("#Dostepnosc > strong:nth-child(2)").InnerText.ToLower()) == "dostępny" ? true : false;
                var harvestYear = HtmlEntity.DeEntitize(currentDoc.QuerySelector(".widoczna > div:nth-child(1) > table:nth-child(22) > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(2)").InnerText);

                if (product.ProductPrice != price)
                {
                    product.ProductName = name;
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = price;
                    product.IsAvailable = isAvailable;
                    //dolozyc implementacje uzycia GeneralProduct
                    //if (product.CategoryID == (int)ProductCategory.Chmiel)
                    //{
                    //    product.ProductHarvestYear = int.TryParse(harvestYear, out int result) ? result : 0;
                    //}
                    //Quantity = quantity,
                    _context.Products.Update(product);
                }
            }
            else if (product.ProductLink.Contains("twojbrowar"))
            {
                var name = HtmlEntity.DeEntitize(currentDoc.QuerySelector(".pb-center-column > h1:nth-child(1)").InnerText);
                var price = decimal.Parse(HtmlEntity.DeEntitize(currentDoc.QuerySelector("#our_price_display").InnerText.Replace(" zł", "").Replace(" ", "")));
                var isAvailable = HtmlEntity.DeEntitize(currentDoc.QuerySelector("#pb-available-title > span").InnerText.ToLower()) == "chwilowy brak towaru" ? false : true;
                var harvestYear = HtmlEntity.DeEntitize(currentDoc.QuerySelector("#value_23949").InnerText);

                if (product.ProductPrice != price)
                {
                    product.ProductName = name;
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = price;
                    product.IsAvailable = isAvailable;
                    //dolozyc implementacje uzycia GeneralProduct
                    //if (product.CategoryID == (int)ProductCategory.Chmiel)
                    //{
                    //    product.ProductHarvestYear = int.TryParse(harvestYear, out int result) ? result : 0;
                    //}
                    //Quantity = quantity,
                    _context.Products.Update(product);
                }
            }
            await _context.SaveChangesAsync();
            return Ok("Cena podanego produktu została sprawdzona i w razie potrzeby zaktualizowana.");
        }
    }
}