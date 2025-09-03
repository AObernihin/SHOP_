using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SHOP_.Models;

namespace SHOP_.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
            private readonly AppDbContext _context;

            public CategoryController(AppDbContext context)
            {
                _context = context;
            }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories;
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            var res = _context.Categories.Any(c=>c.Name.ToLower() == model.Name.ToLower());
            if(res)
            {
                return RedirectToAction("Index");
            }
            _context.Categories.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
           var model = _context.Categories.Find(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category model)
        {
            var res = _context.Categories.Any(c => c.Name.ToLower() == model.Name.ToLower());
            if (res)
            {
                return RedirectToAction("Index");
            }
            _context.Categories.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
