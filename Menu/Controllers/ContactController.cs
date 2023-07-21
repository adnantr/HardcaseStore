using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Menu.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var result = _contactService.TGetList();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(Contact p)
        {
            _contactService.TInsert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var result = _contactService.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateContact(Contact p)
        {
            _contactService.TUpdate(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteContact(int id)
        {
            var result = _contactService.TGetById(id);
            _contactService.TDelete(result);
            return RedirectToAction("Index");
        }
    }
}
