using AlkutayUI.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;

namespace Menu.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var result = _aboutService.TGetList();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAbout(ImageAbout p)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = " Tüm Alanları doldurunuz.";
                return View();
            }
            About g = new About();
            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/alkutay/images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.Image.CopyTo(stream);
                g.Image = newImageName;


            }
            g.Text = p.Text;

            _aboutService.TInsert(g);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAbout()
        {
            //var result = _aboutService.TGetById(id);
            return View();
        }
        [HttpPost]
        public IActionResult UpdateAbout(About g, ImageAbout p)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = " Tüm Alanları doldurunuz.";
                return View(p);
            }
            var extension = Path.GetExtension(p.Image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/alkutay/images/", newImageName);
            var stream = new FileStream(location, FileMode.Create);
            p.Image.CopyTo(stream);
            g.Image = newImageName;
            g.Text = p.Text;
            _aboutService.TUpdate(g);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAbout(int id)
        {
            var value=_aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
