using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Domain.Entities.Products
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
