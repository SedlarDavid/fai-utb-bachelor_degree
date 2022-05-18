using a5pwt_ctvrtek.Application.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Application.ApplicationServices.Orders
{
    public interface IOrderApplicationService
    {
        void CreateOrder(int userID, string userTrackingCode);
        IndexViewModel GetIndexViewModel(int userID);
    }
}
