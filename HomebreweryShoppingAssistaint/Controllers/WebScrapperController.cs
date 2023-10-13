using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistaint.WebScrappers;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace HomebreweryShoppingAssistaint.Controllers
{
    public class WebScrapperController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public WebScrapperController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }
        
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
            return Content("Baza została zapełniona.");
        }

        public ActionResult AddingShops() 
        {
            if (!_context.Shop.Any())
            {
                var shops = new List<Shop>
                {
                    new Shop { ShopName = ShopNameEnum.AlePiwo, ShopLink = "https://alepiwo.pl" },
                    new Shop { ShopName =ShopNameEnum.Browamator, ShopLink = "https://browamator.pl"},
                    new Shop { ShopName = ShopNameEnum.CentrumPiwowarstwa, ShopLink = "https://www.browar.biz/centrumpiwowarstwa" },
                    new Shop { ShopName = ShopNameEnum.Homebrewing, ShopLink = "https://homebrewing.pl/"},
                    new Shop { ShopName = ShopNameEnum.TwojBrowar, ShopLink = "https://twojbrowar.pl/pl/"}
                };
            }
            return Content("Baza została zapełniona.");
        }

        //To Fix
        //public ActionResult ScappingAlePiwo() 
        //{
        //    if(!_context.Product.Any(p=> p.ProductLink.Contains("https://alepiwp.pl/")))
        //    {
        //        AlePiwoWebScrapper.Run();
        //    }
        //    return Content("Baza została zapełniona");
        //}

        //To Fix
        //public ActionResult ScrappingBrowamator()
        //{
        //    if (!_context.Product.Any(p => p.ProductLink.Contains("https://browamator.pl/")))
        //    {
        //        var products = BrowamatorWebScrapper.Run();
        //        _context.Product.AddRange(products);
        //        _context.SaveChanges();
        //    }
        //    return Content("Baza została zapełniona");
        //}

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
            _context.SaveChanges();
            return Content("Dodano produkty do bazy danych: ");
        }

        public async Task<IActionResult> BrowamatorPriceChange()
        {
            List<Product> productsFromDatabase = await _context.Product.ToListAsync();

            List<Product> updatedProduct = new List<Product>();

            foreach(var product in productsFromDatabase)
            {
                List<Product> scrapedProducts = BrowamatorWebScrapper.Run();
                var matchingProduct = scrapedProducts.FirstOrDefault(p=>p.ProductID == product.ProductID);                
                if(matchingProduct.ProductPrice != product.ProductPrice)
                {
                    product.ProductPrice = matchingProduct.ProductPrice;
                    Console.WriteLine("Zaktualizowano cene dla produktu o ID: ");
                    updatedProduct.Add(product);
                }                
            }
            await _context.SaveChangesAsync();
            return Content("Zaktualizowano ceny");
        }

        //To Fix
        public ActionResult ScrappingCentrumPiwowarstwa()
        {
            if (!_context.Product.Any(p => p.ProductLink.Contains("https://www.browar.biz/centrumpiwowarstwa/")))
            {
                var products = CentrumPiwowarstwaWebScrapper.Run();
                _context.Product.AddRange(products);
                _context.SaveChanges();
            }
            return Content("Baza została zapełniona");
        }
        //To Fix
        public ActionResult ScrappingHomeBrewing()
        {
            if (!_context.Product.Any(p => p.ProductLink.Contains("https://homebrewing.pl/")))
            {
                var products = HomeBrewingWebScrapper.Run();
                _context.Product.AddRange(products);
                _context.SaveChanges();
            }
            return Content("Baza została zapełniona");
        }
        //To Fix
        public ActionResult ScrappingTwojBrowar()
        {
            if (!_context.Product.Any(p => p.ProductLink.Contains("https://twojbrowar.pl/")))
            {
                var products = TwojBrowarWebScrapper.Run();
                _context.Product.AddRange(products);
                _context.SaveChanges();
            }
            return Content("Baza została zapełniona");
        }
    }
}
