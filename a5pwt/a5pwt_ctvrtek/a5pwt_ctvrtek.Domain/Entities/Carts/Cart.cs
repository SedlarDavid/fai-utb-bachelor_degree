using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Domain.Entities.Carts
{
    public class Cart : Entity
    {
        public string UserTrackingCode { get; set; }

        public IList<CartItem> CartItems { get; set; }
    }
}
