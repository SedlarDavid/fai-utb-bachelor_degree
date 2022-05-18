using a5pwt_ctvrtek.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Domain.Services.Orders
{
    public interface IOrderService
    {
        void CreateOrder(int userID, string userTrackingCode);
        IList<Order> GetOrders(int userID);
    }
}
