using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Menu.ViewComponents
{
    public class _GalleryPartial:ViewComponent
    {
        private readonly IGalleryService _galleryService;

        public _GalleryPartial(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public IViewComponentResult Invoke()
        {
            var result=_galleryService.TGetList();
            return View(result);
        }
    }
}
