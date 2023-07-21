using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Gallery
    {
        public int id { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public string Style { get; set; }
    }
}
