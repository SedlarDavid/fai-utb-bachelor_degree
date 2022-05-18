using System;
using System.Collections.Generic;
using System.Text;
using a5pwt_ctvrtek.Domain.Entities.Carts;
using a5pwt_ctvrtek.Domain.Repositories.Carts;

namespace a5pwt_ctvrtek.Domain.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public CartItem AddToCart(int productID, int amount, string userTrackingCode)
        {
            return _cartRepository.AddToCart(productID, amount, userTrackingCode);
        }

        public IList<CartItem> GetCartItems(string userTrackingCode)
        {
            return _cartRepository.GetCartItems(userTrackingCode);
        }

        public void RemoveFromCart(int productID, string userTrackingCode)
        {
            _cartRepository.RemoveFromCart(productID, userTrackingCode);
        }
    }
}
