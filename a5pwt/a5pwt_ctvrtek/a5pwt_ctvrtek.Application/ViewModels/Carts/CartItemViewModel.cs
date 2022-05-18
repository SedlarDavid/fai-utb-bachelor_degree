using System.ComponentModel.DataAnnotations.Schema;

namespace a5pwt_ctvrtek.Application.ViewModels.Carts
{
    public class CartItemViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ImageURL { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}