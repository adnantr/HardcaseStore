using AlkutayUI.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Menu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public IActionResult Index()
        {
            var result = _galleryService.TGetList();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddGallery()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGallery(ImageGallery p)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = " Tüm Alanları doldurunuz.";
                return View();
            }
            Gallery g = new Gallery();
            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/alkutay/images/",newImageName);
                var stream=new FileStream(location, FileMode.Create);
                p.Image.CopyTo(stream);
                g.Image = newImageName;
            }
            g.Text = p.Text;
            g.Style = p.Style;

            _galleryService.TInsert(g);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateGallery(int id)
        {
            var result=_galleryService.TGetById(id);
            return View();
        }
        [HttpPost]
        public IActionResult UpdateGallery(Gallery p,ImageGallery g)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = " Tüm Alanları doldurunuz.";
                return View();
            }
            var extension = Path.GetExtension(g.Image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/alkutay/images/", newImageName);
            var stream = new FileStream(location, FileMode.Create);
            g.Image.CopyTo(stream);
            p.Image = newImageName;
            p.Text = g.Text;
            p.Style = g.Style;
            _galleryService.TUpdate(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteGallery(int id)
        {
            var value = _galleryService.TGetById(id);
            _galleryService.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
