using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlkutayUI.Controllers
{
    [AllowAnonymous]
    public class AboutUsController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutUsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var result=_aboutService.TGetList();
            return View(result);
        }
    }
}
