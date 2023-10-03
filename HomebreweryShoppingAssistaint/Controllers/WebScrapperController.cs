using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistaint.WebScrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult ScrappingBrowamator()
        {
            if (!_context.Product.Any(p => p.ProductLink.Contains("https://browamator.pl/")))
            {
                var products = BrowamatorWebScrapper.Run();
                _context.Product.AddRange(products);
                _context.SaveChanges();
            }
            return Content("Baza została zapełniona");
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
