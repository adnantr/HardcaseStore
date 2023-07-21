using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AlkutayUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly ApplicationDbContext _db;

        public MessageController(IMessageService messageService, ApplicationDbContext db)
        {
            _messageService = messageService;
            _db = db;
        }

        public IActionResult Index()
        {
            
            var result=_messageService.TGetList();
            return View(result);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddMessage(Message p)
        {
             _messageService.TInsert(p);
            return RedirectToAction("Index","Home");
        }
        public IActionResult DeleteMessage(int id)
        {
            var result = _messageService.TGetById(id);
            _messageService.TDelete(result);
            return RedirectToAction("Index");
        }
        public IActionResult IsReadMessage(int id)
        {

            var read= _messageService.TGetById(id);
            if (read.IsRead == false)
            {
                read.IsRead = true;
            }
            else
            {
                read.IsRead = false;
            }
            _messageService.TUpdate(read);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int? id)
        {
            var result = _db.Messages.Where(x => x.Id == id).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    }
}
