using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Application.ViewModels.Products
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string Category { get; set; }
    }
}
