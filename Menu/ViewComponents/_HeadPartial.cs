using Microsoft.AspNetCore.Mvc;

namespace Menu.ViewComponents
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
