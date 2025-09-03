using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHOP_.Models;

namespace SHOP_.Controllers
{
    public class ProductController : Controller
    {
       private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Products;
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product model)
        {
            var res = _context.Products.Any(c => c.Name.ToLower() == model.Name.ToLower());
            if (res)
            {
                return RedirectToAction("Index");
            }
            _context.Products.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Product product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product model)
        {
            _context.Products.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
