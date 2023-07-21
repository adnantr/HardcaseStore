using Microsoft.AspNetCore.Mvc;

namespace Menu.ViewComponents
{
    public class _HeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
