using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AlkutayUI.ViewComponents
{
    public class _ProductPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ApplicationDbContext _db;

        public _ProductPartial(IProductService productService, ApplicationDbContext db)
        {
            _productService = productService;
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var product = _db.Products.Where(x => x.Categories.Serial == 1).ToList();
            return View(product);
        }
    }
}
