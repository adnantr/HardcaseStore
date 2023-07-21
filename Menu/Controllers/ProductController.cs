using AlkutayUI.Models;
using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Menu.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IProductService _productService;

        public ProductController(ApplicationDbContext db,IProductService productService)
        {
            _db = db;
            _productService = productService;
        }
       
        public IActionResult Index()
        {
           var result= _productService.GetProductsListWithCategory();
            return View(result);
        }

        public void CategoryList()
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            ViewBag.categorylist = _db.Categories.ToList(); 
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            CategoryList();
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductImageModel p)
        {
            Product g = new Product();
            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/alkutay/images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.Image.CopyTo(stream);
                g.Image = newImageName;
            }
            if (p.ImageOne != null)
            {
                var extensionOne = Path.GetExtension(p.ImageOne.FileName);
                var newImageNameOne = Guid.NewGuid() + extensionOne;
                var locationOne = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/alkutay/images/", newImageNameOne);
                var streamOne = new FileStream(locationOne, FileMode.Create);
                p.ImageOne.CopyTo(streamOne);
                g.ImageOne = newImageNameOne;
            }
            if (p.ImageTwo != null)
            {
                var extensionTwo = Path.GetExtension(p.ImageTwo.FileName);
                var newImageNameTwo = Guid.NewGuid() + extensionTwo;
                var locationTwo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/alkutay/images/", newImageNameTwo);
                var streamTwo = new FileStream(locationTwo, FileMode.Create);
                p.ImageTwo.CopyTo(streamTwo);
                g.ImageTwo = newImageNameTwo;
            }

            g.Name = p.Name;
            g.Price = p.Price;
            g.Description = p.Description;
            g.CategoryId = p.CategoryId;

            _productService.TInsert(g);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            CategoryList();
            var result = _productService.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product g,ProductImageModel p)
        {
            
            var extension = Path.GetExtension(p.Image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/alkutay/images/", newImageName);
            var stream = new FileStream(location, FileMode.Create);
            p.Image.CopyTo(stream);
            g.Image = newImageName;


            var extensionOne = Path.GetExtension(p.ImageOne.FileName);
            var newImageNameOne = Guid.NewGuid() + extensionOne;
            var locationOne = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/alkutay/images/", newImageNameOne);
            var streamOne = new FileStream(locationOne, FileMode.Create);
            p.ImageOne.CopyTo(streamOne);
            g.ImageOne = newImageNameOne;

            var extensionTwo = Path.GetExtension(p.ImageTwo.FileName);
            var newImageNameTwo = Guid.NewGuid() + extensionTwo;
            var locationTwo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/alkutay/images/", newImageNameTwo);
            var streamTwo = new FileStream(locationTwo, FileMode.Create);
            p.ImageTwo.CopyTo(streamTwo);
            g.ImageTwo = newImageNameTwo;

            g.Name = p.Name;
            g.Price = p.Price;
            g.Description = p.Description;
            g.CategoryId = p.CategoryId;
             _productService.TUpdate(g);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return RedirectToAction("Index");
        }

    }
}
