using Microsoft.AspNetCore.Mvc;

namespace AlkutayUI.ViewComponents
{
    public class _SidebarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
