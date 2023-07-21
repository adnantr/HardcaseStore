using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AlkutayUI.Controllers
{
    [AllowAnonymous]
    public class ProduceController : Controller
    {
        private readonly IProductService _productService;
        private readonly ApplicationDbContext _db;

        public ProduceController(IProductService productService,ApplicationDbContext db)
        {
            _productService = productService;
            _db = db;
        }

        public IActionResult Index()
        {
            var result=_productService.TGetList();
            return View(result);
        }
        public IActionResult Detail(int? id)
        {
            var result = _db.Products.Where(x => x.Id == id).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    }
}
