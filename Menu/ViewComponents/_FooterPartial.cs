using Microsoft.AspNetCore.Mvc;

namespace AlkutayUI.ViewComponents
{
    public class _FooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
