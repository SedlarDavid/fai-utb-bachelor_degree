using a5pwt_ctvrtek.Domain.Entities.Carts;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Domain.Services.Carts
{
    public interface ICartService
    {
        CartItem AddToCart(int productID, int amount, string userTrackingCode);
        void RemoveFromCart(int productID, string userTrackingCode);
        IList<CartItem> GetCartItems(string userTrackingCode);
    }
}
