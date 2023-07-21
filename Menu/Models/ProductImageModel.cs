using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace AlkutayUI.Models
{
    public class ProductImageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile ImageOne { get; set; }
        public IFormFile ImageTwo { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
