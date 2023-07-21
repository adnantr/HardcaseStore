using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AlkutayUI.Models
{
    public class ImageGallery
    {
        public int id { get; set; }   
        [Required(ErrorMessage = "Lütfen fotoğraf ekleyiniz.")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Lütfen boş bırakmayın.")]
        public string Text { get; set; }
        public string Style { get; set; }
    }
}
