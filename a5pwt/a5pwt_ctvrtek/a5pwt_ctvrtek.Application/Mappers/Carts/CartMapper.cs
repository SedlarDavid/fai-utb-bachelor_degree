using System;
using System.Collections.Generic;
using System.Text;
using a5pwt_ctvrtek.Application.ViewModels.Carts;
using a5pwt_ctvrtek.Domain.Entities.Carts;
using AutoMapper;

namespace a5pwt_ctvrtek.Application.Mappers.Carts
{
    public class CartMapper : ICartMapper
    {
        private readonly IMapper _mapper;

        public CartMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IList<CartItemViewModel> GetViewModelsFromEntities(IList<CartItem> entities)
        {
            return _mapper.Map<IList<CartItemViewModel>>(entities);
        }
    }
}
