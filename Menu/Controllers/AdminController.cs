using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Menu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,ApplicationDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public  IActionResult UserList()
        {
            return View(_userManager.Users);
        }

        public async Task <IActionResult> DeleteUser(string id)
        {
            if (_userManager.Users.Count() == 1)
            {
                TempData["message"] = "Şuan sistemde kayıtlı sadece 1 kullanıcı bulunduğu için kullanıcı silme işlemi yapılamamaktadır. Lütfen önce yeni bir kullanıcı oluşturun.";
                return RedirectToAction("UserList");
                
            }
            else
            {
                var user = await _userManager.FindByNameAsync(id);
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Redirect("~/admin/UserList");
                }
            }
            return Redirect("~/admin/UserList");
        }
        public async Task<IActionResult> EmailConfirm(string id)
        {
            var mail = await _userManager.FindByNameAsync(id);
            if (_userManager.Users.Count() == 1 && mail.EmailConfirmed==true)
            {
                TempData["message"] = "Şuan sistemde kayıtlı sadece 1 kullanıcı bulunduğu için kullanıcı engelleme işlemi yapılamamaktadır. Lütfen önce yeni bir kullanıcı oluşturun.";
                return RedirectToAction("UserList");
            }
            else
            {
                if (mail.EmailConfirmed == false)
                {
                    mail.EmailConfirmed = true;
                }
                else
                {
                    mail.EmailConfirmed = false;
                }
                var result = await _userManager.UpdateAsync(mail);
            }  
            return RedirectToAction("UserList");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            var user = await _userManager.FindByNameAsync(p.Username);
            if (user == null)
            {
                TempData["message"] = "Böyle bir kullanıcı adı bulunmamaktadar";
                return View(p);
            }
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                TempData["message"] = "Hesabınız Onaylı değildir. Giriş yapabilmek için onaylanması gerekmektedir.";
                return View(p);
            }
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["message"] = "Hatalı kullanıcı adı veya şifre. Lütfen tekrardan deneyin.";
                }
            }
                return View();
            }
        
        public async Task<ActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Admin");
        }
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.SurName,
                UserName = model.UserName,
                Email = model.Mail

            };
            if (model.Password == null)
            {
                TempData["PasswordNull"] = "Lütfen şifre giriniz";
            }
            else
            {
                if (model.Password == model.ComfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }

                    }

                }
                else
                {
                    TempData["PasswordNull"] = "Şifreler eşleşmiyor.Lütfen dikkatli giriş yapınız.";
                }
            }
            return View(model);
        }
    }
}
