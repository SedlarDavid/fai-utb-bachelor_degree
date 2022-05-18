using a5pwt_ctvrtek.Domain.Entities.Addresses;
using System;
using System.Collections.Generic;

namespace a5pwt_ctvrtek.Domain.Entities.Orders
{
    public class Order : Entity
    {
        public int UserID { get; set; }
        public string OrderNumber { get; set; }
        public int? ShippingAddressID { get; set; }
        public int? BillingAddressID { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
    }
}
