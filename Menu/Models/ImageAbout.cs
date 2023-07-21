using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AlkutayUI.Models
{
    public class ImageAbout
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen fotoğraf ekleyiniz.")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Lütfen boş bırakmayın.")]
        public string Text { get; set; }
    }
}
