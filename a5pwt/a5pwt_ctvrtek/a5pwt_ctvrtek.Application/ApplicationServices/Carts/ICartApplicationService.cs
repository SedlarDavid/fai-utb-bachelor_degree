using a5pwt_ctvrtek.Application.ViewModels.Carts;
using a5pwt_ctvrtek.Domain.Entities.Carts;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Application.ApplicationServices.Carts
{
    public interface ICartApplicationService
    {
        CartItem AddToCart(int productID, int amount, string userTrackingCode);

        void RemoveFromCart(int productID, string userTrackingCode);

        IndexViewModel GetIndexViewModel(string userTrackingCode);
    }
}
