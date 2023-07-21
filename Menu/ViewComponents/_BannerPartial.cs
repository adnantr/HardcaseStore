using Microsoft.AspNetCore.Mvc;

namespace AlkutayUI.ViewComponents
{
    public class _BannerPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
