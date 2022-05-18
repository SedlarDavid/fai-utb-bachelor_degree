using a5pwt_ctvrtek.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Domain.Entities.Carts
{
    public class CartItem : Entity
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
