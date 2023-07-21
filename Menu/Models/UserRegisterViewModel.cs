using System.ComponentModel.DataAnnotations;

namespace Menu.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen isim değeri giriniz!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen soyisim değeri giriniz!")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen bir mail giriniz!")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Lütfen şifre giriniz!")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz!")]
        [Compare("Password", ErrorMessage ="Şifreler eşleşmiyor!")]
        public string ComfirmPassword { get; set; }
    }
}
