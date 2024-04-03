using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistaint.WebScrappers;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.AspNetCore.Mvc;

namespace HomebreweryShoppingAssistaint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebScrapperController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public WebScrapperController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        /*[HttpPost("AddingCategories")]
        public ActionResult AddingCategories()
        {
            if (!_context.Category.Any())
            {
                var categories = new List<Category>
                {
                    new Category {CategoryName = ProductCategory.Chmiel },
                    new Category {CategoryName = ProductCategory.Drożdże },
                    new Category {CategoryName = ProductCategory.Słód },
                    new Category {CategoryName = ProductCategory.Inne }
                };
                _context.Category.AddRange(categories);
                _context.SaveChanges();
            }
            return Ok("Baza została zapełniona.");
        }

        [HttpPost("AddingShops")]
        public ActionResult AddingShops()
        {
            if (!_context.Shop.Any())
            {
                var shops = new List<Shop>
                {
                    new Shop { ShopName = ShopNameEnum.AlePiwo, ShopLink = "https://alepiwo.pl" },
                    new Shop { ShopName = ShopNameEnum.Browamator, ShopLink = "https://browamator.pl"},
                    new Shop { ShopName = ShopNameEnum.CentrumPiwowarstwa, ShopLink = "https://www.browar.biz/centrumpiwowarstwa" },
                    new Shop { ShopName = ShopNameEnum.Homebrewing, ShopLink = "https://homebrewing.pl/"},
                    new Shop { ShopName = ShopNameEnum.TwojBrowar, ShopLink = "https://twojbrowar.pl/pl/"}
                };
                _context.Shop.AddRange(shops);
                _context.SaveChanges();
            }
            return Ok("Baza została zapełniona.");
        }

        [HttpPost("AddingDelivery")]
        public ActionResult AddingDelivery()
        {
            if (!_context.Delivery.Any())
            {
                var delivery = new List<Delivery>
                {
                    // CentrumPiwowarstwa
                    new Delivery {DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 0.99m, DeliveryPrice = 15.99m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 4.99m, DeliveryPrice = 18.55m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 29.99m, DeliveryPrice = 22.03m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 59.99m, DeliveryPrice = 44.08m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 89.99m, DeliveryPrice = 66.12m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 119.99m, DeliveryPrice = 88.16m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 149.99m, DeliveryPrice = 110.20m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 179.99m, DeliveryPrice = 132.24m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 209.99m, DeliveryPrice = 154.28m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 239.99m, DeliveryPrice = 176.32m, ShopID = 3 },

                    new Delivery {DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 4.99m, DeliveryPrice = 23.19m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 29.99m, DeliveryPrice = 27.83m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 59.99m, DeliveryPrice = 49.88m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 89.99m, DeliveryPrice = 71.92m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 119.99m, DeliveryPrice = 93.96m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 149.99m, DeliveryPrice = 116.00m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 179.99m, DeliveryPrice = 138.04m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 209.99m, DeliveryPrice = 160.08m, ShopID = 3 },
                    new Delivery {DeliveryName = DeliverySupplier.DPD_Pobraniowa, DeliveryWeight = 239.99m, DeliveryPrice = 182.12m, ShopID = 3 },

                    // Homebrewing
                    new Delivery {DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 15, DeliveryPrice = 22.90m, ShopID = 4},
                    new Delivery {DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 30, DeliveryPrice = 24.90m, ShopID = 4},
                    new Delivery {DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 60, DeliveryPrice = 49.80m, ShopID = 4},
                    new Delivery {DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 90, DeliveryPrice = 68.70m, ShopID = 4},
                    new Delivery {DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 120, DeliveryPrice = 91.20m, ShopID = 4},
                    new Delivery {DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 150, DeliveryPrice = 114.50m, ShopID = 4},
                    new Delivery {DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 180, DeliveryPrice = 137.40m, ShopID = 4},

                    new Delivery {DeliveryName = DeliverySupplier.Inpost, DeliveryWeight = 20, DeliveryPrice = 24.90m, ShopID = 4 },
                    new Delivery {DeliveryName = DeliverySupplier.Inpost_Paczkomat, DeliveryWeight = 13, DeliveryPrice = 14.95m, ShopID = 4},

                    // TwojBrowar
                    new Delivery {DeliveryName = DeliverySupplier.Inpost, DeliveryWeight = 25, DeliveryPrice = 17.50m, ShopID = 5},
                    new Delivery {DeliveryName = DeliverySupplier.GLS, DeliveryWeight = 30, DeliveryPrice = 23.90m, ShopID = 5 },
                    new Delivery {DeliveryName = DeliverySupplier.GLS_Pobraniowa, DeliveryWeight = 30, DeliveryPrice = 29.90m, ShopID = 5},
                    new Delivery {DeliveryName = DeliverySupplier.DPD, DeliveryWeight = 30, DeliveryPrice = 25.90m, ShopID = 5}
                };

                _context.Delivery.AddRange(delivery);
                _context.SaveChanges();
            }
            return Ok("Baza została zapełniona");
        }

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
        public ActionResult ScrappingBrowamator()
        {
            List<Product> scrappedProducts = BrowamatorWebScrapper.Run();
            foreach (var scrappedProduct in scrappedProducts)
            {
                var existingProduct = _context.Product.FirstOrDefault(p => p.ProductLink == scrappedProduct.ProductLink);
                if (existingProduct == null)
                {
                    _context.Product.Add(scrappedProduct);
                }
            }

            var shopCheckHistory = new ShopCheckHistory()
            {
                ShopID = (int)ShopNameEnum.Browamator,
                CheckDateTime = DateTime.Now,
            };
            //Problem do rozwiązania związany z bazą danych
            _context.ShopCheckHistory.Add(shopCheckHistory);
            _context.SaveChanges();
            return Ok("Dodano produkty do bazy danych: ");
        }

        [HttpPost("BrowamatorPriceCheck")]
        public async Task<IActionResult> BrowamatorPriceChange()
        {
            List<Product> productsFromDatabase = _context.Product.ToList();
            List<Product> updatedProduct = BrowamatorWebScrapper.Run();

            foreach (var product in productsFromDatabase)
            {
                var matchingProduct = updatedProduct.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct != null && matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: ");
                    _context.Product.Update(product);
                }
                var productCheckHistory = new ProductCheckHistory()
                {
                    ProductID = product.ProductID,
                    CheckDateTime = DateTime.Now,
                };

                await _context.ProductCheckHistory.AddAsync(productCheckHistory);
            }
            await _context.SaveChangesAsync();
            return Ok("Zaktualizowano ceny");
        }

        [HttpPost("ScrappingCentrumPiwowarstwa")]
        public ActionResult ScrappingCentrumPiwowarstwa()
        {
            List<Product> scrappedProducts = CentrumPiwowarstwaWebScrapper.Run();
            foreach (var scrappedProduct in scrappedProducts)
            {
                var existingProduct = _context.Product.FirstOrDefault(p => p.ProductLink == scrappedProduct.ProductLink);
                if (existingProduct == null)
                {
                    _context.Product.Add(scrappedProduct);
                }
                _context.Product.Add(scrappedProduct);
            }

            var shopCheckHistory = new ShopCheckHistory()
            {
                ShopID = (int)ShopNameEnum.CentrumPiwowarstwa,
                CheckDateTime = DateTime.Now,
            };

            _context.ShopCheckHistory.Add(shopCheckHistory);
            _context.SaveChanges();
            return Ok("Baza została zapełniona");
        }

        [HttpPost("CentrumPiwowarstwaPriceCheck")]
        public async Task<IActionResult> CentrumPiwowarstwaPriceChange()
        {
            List<Product> productsFromDatabase = _context.Product.ToList();
            List<Product> updatedProduct = CentrumPiwowarstwaWebScrapper.Run();

            foreach (var product in productsFromDatabase)
            {
                var matchingProduct = updatedProduct.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct != null && matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: " + product.ProductID);
                    _context.Product.Update(product);
                }

                var productCheckHistory = new ProductCheckHistory()
                {
                    ProductID = product.ProductID,
                    CheckDateTime = DateTime.Now
                };
                await _context.ProductCheckHistory.AddAsync(productCheckHistory);
            }
            await _context.SaveChangesAsync();
            return Ok("Zaktualizowano ceny");
        }

        [HttpPost("ScrappingHomebrewing")]
        public ActionResult ScrappingHomeBrewing()
        {
            List<Product> scrappedProducts = HomeBrewingWebScrapper.Run();
            foreach (var scrappedProduct in scrappedProducts)
            {
                var existingProduct = _context.Product.FirstOrDefault(p => p.ProductLink == scrappedProduct.ProductLink);
                if (existingProduct == null)
                {
                    Console.WriteLine("Added to DB");
                    _context.Product.Add(scrappedProduct);
                }

            }

            var shopCheckHistory = new ShopCheckHistory()
            {
                ShopID = (int)ShopNameEnum.Homebrewing,
                CheckDateTime = DateTime.Now,
            };

            _context.ShopCheckHistory.Add(shopCheckHistory);
            _context.SaveChanges();
            return Ok("Baza została zapełniona");
        }

        [HttpPost("HomebrewingPriceCheck")]
        public async Task<IActionResult> HomeBrewingPriceChange()
        {
            List<Product> productsFromDatabase = _context.Product.ToList();
            List<Product> updatedProduct = HomeBrewingWebScrapper.Run();

            foreach (var product in productsFromDatabase)
            {
                var matchingProduct = updatedProduct.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct != null && matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: " + product.ProductID);
                    _context.Product.Update(product);
                }

                var productCheckHistory = new ProductCheckHistory()
                {
                    ProductID = product.ProductID,
                    CheckDateTime = DateTime.Now
                };
                await _context.ProductCheckHistory.AddAsync(productCheckHistory);
            }
            await _context.SaveChangesAsync();
            return Ok("Zaktualizowano ceny");
        }

        [HttpPost("ScrappingTwojBrowar")]
        public ActionResult ScrappingTwojBrowar()
        {
            List<Product> scrappedProducts = TwojBrowarWebScrapper.Run();
            foreach (var scrappedProduct in scrappedProducts)
            {
                var existingProduct = _context.Product.FirstOrDefault(p => p.ProductLink == scrappedProduct.ProductLink);
                if (existingProduct == null)
                {
                    _context.Product.Add(scrappedProduct);
                }

            }

            var shopCheckHistory = new ShopCheckHistory()
            {
                ShopID = (int)ShopNameEnum.TwojBrowar,
                CheckDateTime = DateTime.Now,
            };

            _context.ShopCheckHistory.Add(shopCheckHistory);
            _context.SaveChanges();
            return Ok("Baza została zapełniona");
        }

        [HttpPost("TwojBrowarPriceCheck")]
        public async Task<IActionResult> TwojBrowarPriceChange()
        {
            List<Product> productsFromDatabase = _context.Product.ToList();
            List<Product> updatedProduct = TwojBrowarWebScrapper.Run();

            foreach (var product in productsFromDatabase)
            {
                var matchingProduct = updatedProduct.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: " + product.ProductID);
                    _context.Product.Update(product);
                }

                var productCheckHistory = new ProductCheckHistory()
                {
                    ProductID = product.ProductID,
                    CheckDateTime = DateTime.Now
                };
                await _context.ProductCheckHistory.AddAsync(productCheckHistory);
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
                    _context.Product.Update(product);
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
                    _context.Product.Update(product);
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
                    product.ProductHarvestYear = int.TryParse(harvestYear, out int result) ? result : 0;
                    //Quantity = quantity,
                    _context.Product.Update(product);
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
                    product.ProductHarvestYear = int.TryParse(harvestYear, out int result) ? result : 0;
                    //Quantity = quantity,
                    _context.Product.Update(product);
                }
            }
            await _context.SaveChangesAsync();
            return Ok("Cena podanego produktu została sprawdzona i w razie potrzeby zaktualizowana.");
        }
    }
}