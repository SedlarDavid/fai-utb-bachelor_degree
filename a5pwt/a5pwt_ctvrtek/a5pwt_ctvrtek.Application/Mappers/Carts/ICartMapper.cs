using a5pwt_ctvrtek.Application.ViewModels.Carts;
using a5pwt_ctvrtek.Domain.Entities.Carts;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Application.Mappers.Carts
{
    public interface ICartMapper
    {
        IList<CartItemViewModel> GetViewModelsFromEntities(IList<CartItem> entities);
    }
}
