using a5pwt_ctvrtek.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Application.ViewModels.Carts
{
    public class IndexViewModel
    {
        public IList<CartItemViewModel> CartItems { get; set; }
        public IList<ProductViewModel> RelatedItems { get; set; }
        public decimal Total { get; set; }
        public int? UserID { get; set; }
        public string UserEmail { get; set; }
    }
}
