using a5pwt_ctvrtek.Application.ViewModels.Orders;
using a5pwt_ctvrtek.Domain.Services.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace a5pwt_ctvrtek.Application.ApplicationServices.Orders
{
    public class OrderApplicationService : IOrderApplicationService
    {
        private readonly IOrderService _orderService;

        public OrderApplicationService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void CreateOrder(int userID, string userTrackingCode)
        {
            _orderService.CreateOrder(userID, userTrackingCode);
        }

        public IndexViewModel GetIndexViewModel(int userID)
        {
            var orders = _orderService.GetOrders(userID);
            var orderViewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                orderViewModels.Add(new OrderViewModel
                {
                    DateCreated = order.DateCreated,
                    ItemCount = order.OrderItems.Count,
                    Total = order.OrderItems.Sum(x => x.Price * x.Amount)
                });
            }

            return new IndexViewModel
            {
                Orders = orderViewModels
            };
        }
    }
}
