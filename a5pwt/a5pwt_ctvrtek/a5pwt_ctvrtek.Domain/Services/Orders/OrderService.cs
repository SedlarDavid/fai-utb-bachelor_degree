using a5pwt_ctvrtek.Domain.Entities.Orders;
using a5pwt_ctvrtek.Domain.Repositories.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Domain.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void CreateOrder(int userID, string userTrackingCode)
        {
            _orderRepository.CreateOrder(userID, userTrackingCode);
        }

        public IList<Order> GetOrders(int userID)
        {
            return _orderRepository.GetOrders(userID);
        }
    }
}
