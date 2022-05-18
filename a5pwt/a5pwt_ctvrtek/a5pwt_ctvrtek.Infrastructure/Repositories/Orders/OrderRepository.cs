using a5pwt_ctvrtek.Domain.Entities.Orders;
using a5pwt_ctvrtek.Domain.Repositories.Carts;
using a5pwt_ctvrtek.Domain.Repositories.Orders;
using a5pwt_ctvrtek.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace a5pwt_ctvrtek.Infrastructure.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ICartRepository _cartRepository;
        private readonly DataContext _dataContext;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(
            ICartRepository cartRepository,
            DataContext dataContext)
        {
            _cartRepository = cartRepository;
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<Order>();
        }

        public void CreateOrder(int userID, string userTrackingCode)
        {
            var cart = _cartRepository.GetCurrentCart(userTrackingCode);
            var order = new Order
            {
                UserID = userID,
                OrderItems = new List<OrderItem>(),
                OrderNumber = userTrackingCode.Take(8).ToString()
            };

            foreach (var item in cart.CartItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductID = item.ProductID,
                    Amount = item.Amount,
                    Price = item.Product.Price
                });
            }

            while (cart.CartItems.FirstOrDefault() != null)
                cart.CartItems.RemoveAt(0);

            _dbSet.Add(order);
            _dataContext.SaveChanges();
        }

        public IList<Order> GetOrders(int userID)
        {
            return _dbSet.Where(x => x.UserID == userID)
                        .Include(x => x.OrderItems)
                        .ToList();
        }
    }
}
