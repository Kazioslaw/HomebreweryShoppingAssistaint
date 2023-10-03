using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
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
                _context.AddRange(categories);
                _context.SaveChanges();
            }
        }

        public ActionResult AddingShops() 
        {

        }

        public ActionResult ScrappingSites() {
        }
    }
}
