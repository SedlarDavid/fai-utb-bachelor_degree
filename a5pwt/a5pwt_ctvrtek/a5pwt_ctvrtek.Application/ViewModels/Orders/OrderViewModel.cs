using System;

namespace a5pwt_ctvrtek.Application.ViewModels.Orders
{
    public class OrderViewModel
    {
        public DateTime DateCreated { get; set; }
        public decimal Total { get; set; }
        public int ItemCount { get; set; }
    }
}