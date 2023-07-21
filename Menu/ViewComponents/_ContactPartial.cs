using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Menu.ViewComponents
{
    public class _ContactPartial:ViewComponent
    {
        private readonly IContactService _contactService;

        public _ContactPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
           var result= _contactService.TGetList();
            return View(result);
        }
    }
}
