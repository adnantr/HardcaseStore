using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;
using System.Net;
using System.Text.RegularExpressions;

namespace AlkutayUI.Controllers
{
    [AllowAnonymous]
    public class ContactUsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactUsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var result=_contactService.TGetList();
            return View(result);
        }

        
    }
}
