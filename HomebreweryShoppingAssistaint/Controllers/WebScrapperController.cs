using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistaint.WebScrappers;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

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

        [HttpPost("Test")]
        public ActionResult Test() {
            var company = new List<Company>
        {
            new Company { CompanyName = "Heniek Strajkt"},
            new Company
            {
                CompanyName = "Test",
            },
        };
            _context.AddRange(company);
            _context.SaveChanges();
            return Ok("Dodano do bazy");
        }

        [HttpPost("AddingCategories")]
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
            List<Product> productsFromDatabase = await _context.Product.ToListAsync();

            List<Product> updatedProduct = new List<Product>();

            foreach (var product in productsFromDatabase)
            {
                List<Product> scrapedProducts = BrowamatorWebScrapper.Run();
                var matchingProduct = scrapedProducts.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct != null && matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: ");
                    updatedProduct.Add(product);
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
            List<Product> productsFromDatabase = await _context.Product.ToListAsync();
            List<Product> updatedProduct = new List<Product>();

            foreach (var product in productsFromDatabase)
            {
                List<Product> scrappedProducts = CentrumPiwowarstwaWebScrapper.Run();
                var matchingProduct = scrappedProducts.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct != null && matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: " + product.ProductID);
                    _context.Product.Add(product);
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
                    _context.Product.Add(scrappedProduct);
                }

            }

            var shopCheckHistory = new ShopCheckHistory()
            {
                ShopID = (int)ShopNameEnum.CentrumPiwowarstwa,
                CheckDateTime = DateTime.Now,
            };

            _context.ShopCheckHistory.Add(shopCheckHistory);
            return Ok("Baza została zapełniona");
        }

        [HttpPost("HomebrewingPriceCheck")]
        public async Task<IActionResult> HomeBrewingPriceChange()
        {
            List<Product> productsFromDatabase = await _context.Product.ToListAsync();
            List<Product> updatedProduct = new List<Product>();

            foreach (var product in productsFromDatabase)
            {
                List<Product> scrappedProducts = CentrumPiwowarstwaWebScrapper.Run();
                var matchingProduct = scrappedProducts.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct != null && matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: " + product.ProductID);
                    _context.Product.Add(product);
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
                ShopID = (int)ShopNameEnum.CentrumPiwowarstwa,
                CheckDateTime = DateTime.Now,
            };
            
            _context.ShopCheckHistory.Add(shopCheckHistory);
            return Ok("Baza została zapełniona");
        }

        [HttpPost("TwojBrowarPriceCheck")]
        public async Task<IActionResult> TwojBrowarPriceChange()
        {
            List<Product> productsFromDatabase = await _context.Product.ToListAsync();
            List<Product> updatedProduct = new List<Product>();

            foreach (var product in productsFromDatabase)
            {
                List<Product> scrappedProducts = CentrumPiwowarstwaWebScrapper.Run();
                var matchingProduct = scrappedProducts.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.Product30DaysPrice = product.ProductPrice;
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: " + product.ProductID);
                    _context.Product.Add(product);
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
    }
}
