using Ecommerce_Web_Application.Data;
using Ecommerce_Web_Application.Models;
using Ecommerce_Web_Application.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce_Web_Application.Areas.Customar.Controllers
{
    [Area("Customar")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(FilterWithVm filterWithVm,int page=1)
        {
            #region quiery
            IQueryable<Product> products = _context.Products.Include(e=>e.Category);
            var categories = _context.Categories.ToList();
            #endregion
            #region pagination
            var totalpagenumper = Math.Ceiling(products.Count() / 8.0);
            products = _context.Products.Skip((page - 1) * 8).Take(8);
            #endregion
            #region filter


            if (filterWithVm.ProductName is not null)
            {
                products= products.Where(e=>e.Name.Contains(filterWithVm.ProductName));
            }
            if (filterWithVm.MinPrice is not null)
            {
                products = products.Where(e => e.Price - e.Price * e.Discount / 100 > filterWithVm.MinPrice);
            }
            if (filterWithVm.MaxPrice is not null)
            {
                products = products.Where(e => e.Price - e.Price * e.Discount / 100 < filterWithVm.MaxPrice);
            }

            if (filterWithVm.categoryId > 0 && filterWithVm.categoryId <= categories.Count)
            {
                products = products.Where(e => e.CategoryId == filterWithVm.categoryId);

            }
            #endregion
            

            ProductAndFilter productAndFilter = new()
            {
                Products = products.ToList(),
                filterWithVm = filterWithVm,
                categories= categories.ToList(),
                totalpagenumper= totalpagenumper
            };
            return View(productAndFilter);
        }
        public IActionResult Details(int id) 
        {
            var product = _context.Products.Find(id);
            if (product is not null)
            {
                var relatedproduct = _context.Products
                    .Where(e => e.Name.Contains(product.Name.Substring(0, 4))&&e.Id!=product.Id).Take(4);
                    

                var topvisited = _context.Products.OrderByDescending(e => e.Traffic).Skip(0).Take(4);
                product.Traffic++;
                _context.SaveChanges();

                var categoryproducts = _context.Products.Include(e => e.Category)
                    .Where(e => e.CategoryId == product.CategoryId).Take(4);

                DetailsProduct detailsProduct = new()
                {
                    Product = product,
                    Relatedproduct = relatedproduct.ToList(),
                    Topvisited=  topvisited.ToList(),
                    CategoryProduct= categoryproducts.ToList()

                };

                return View(detailsProduct);
            }

            return RedirectToAction(nameof(NotFoundPage));
        }
        public IActionResult NotFoundPage()
        {
                    
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
