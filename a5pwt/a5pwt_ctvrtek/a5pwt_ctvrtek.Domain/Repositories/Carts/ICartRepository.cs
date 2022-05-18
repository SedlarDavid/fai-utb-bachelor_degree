using a5pwt_ctvrtek.Domain.Entities.Carts;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Domain.Repositories.Carts
{
    public interface ICartRepository
    {
        CartItem AddToCart(int productID, int amount, string userTrackingCode);

        void RemoveFromCart(int productID, string userTrackingCode);

        IList<CartItem> GetCartItems(string userTrackingCode);

        Cart GetCurrentCart(string userTrackingCode);
    }
}
