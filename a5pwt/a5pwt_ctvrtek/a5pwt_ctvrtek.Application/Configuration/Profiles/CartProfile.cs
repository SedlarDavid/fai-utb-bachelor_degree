using a5pwt_ctvrtek.Application.ViewModels.Carts;
using a5pwt_ctvrtek.Domain.Entities.Carts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Application.Configuration.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<CartItem, CartItemViewModel>()
                .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.Product.ImageURL))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => src.Product.ID))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Product.Price));
        }
    }
}
