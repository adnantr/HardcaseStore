using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Menu.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categorytService;
        private readonly ApplicationDbContext _context;

        public CategoryController(ICategoryService categorytService, ApplicationDbContext context)
        {
            _categorytService = categorytService;
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _categorytService.TGetList();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            _categorytService.TInsert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var result = _categorytService.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category p)
        {
            _categorytService.TUpdate(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Products.FirstOrDefault(x=>x.Id==id);
            var productControl = _context.Products.Where(a => a.CategoryId == id).ToList();
            if (!productControl.Any())
            {
                var value = _categorytService.TGetById(id);
                _categorytService.TDelete(value);
                return RedirectToAction("Index");
            }
            else if (category.CategoryId == id)
            {
                TempData["message"] = " Silinecek kategoriye kayıtlı bir ürün bulunmaktadır lütfen önce onu siliniz.";
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        
    }
}

