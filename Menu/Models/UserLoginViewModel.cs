using System.ComponentModel.DataAnnotations;

namespace Menu.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenzi Giriniz")]
        public string Password { get; set; }
    }
}
