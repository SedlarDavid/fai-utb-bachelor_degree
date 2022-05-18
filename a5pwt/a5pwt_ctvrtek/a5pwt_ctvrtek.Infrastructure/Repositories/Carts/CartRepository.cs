using a5pwt_ctvrtek.Domain.Entities.Carts;
using a5pwt_ctvrtek.Domain.Repositories.Carts;
using a5pwt_ctvrtek.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace a5pwt_ctvrtek.Infrastructure.Repositories.Carts
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Cart> _dbSet;

        public CartRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<Cart>();
        }

        public CartItem AddToCart(int productID, int amount, string userTrackingCode)
        {
            var cart = GetCurrentCart(userTrackingCode);
            var cartItem = cart.CartItems.FirstOrDefault(t => t.ProductID == productID);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductID = productID,
                    Amount = amount,
                    CartID = cart.ID
                };
                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Amount += amount;
            }

            _dataContext.SaveChanges();

            return cartItem;
        }

        public IList<CartItem> GetCartItems(string userTrackingCode)
        {
            var cart = GetCurrentCart(userTrackingCode);
            return cart.CartItems;
        }

        public void RemoveFromCart(int productID, string userTrackingCode)
        {
            var cart = GetCurrentCart(userTrackingCode);
            var cartItem = cart.CartItems.FirstOrDefault(t => t.ProductID == productID);

            if (cartItem == null)
            {
                return;
            }

            cart.CartItems.Remove(cartItem);
            _dataContext.Entry(cartItem).State = EntityState.Deleted;
            _dataContext.SaveChanges();
        }

        public Cart GetCurrentCart(string userTrackingCode)
        {
            var cart = _dbSet
                .Include(t => t.CartItems)
                .ThenInclude(cartItem => cartItem.Product)
                .FirstOrDefault(t => t.UserTrackingCode == userTrackingCode);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserTrackingCode = userTrackingCode,
                    CartItems = new List<CartItem>()
                };
                _dbSet.Add(cart);
                _dataContext.SaveChanges();
            }

            return cart;
        }
    }
}
