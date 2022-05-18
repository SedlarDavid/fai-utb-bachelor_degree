using a5pwt_ctvrtek.Domain.Entities.Products;

namespace a5pwt_ctvrtek.Domain.Entities.Orders
{
    public class OrderItem : Entity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}