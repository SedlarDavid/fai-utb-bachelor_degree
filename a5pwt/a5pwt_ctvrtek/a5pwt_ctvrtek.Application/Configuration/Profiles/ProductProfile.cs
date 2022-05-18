using a5pwt_ctvrtek.Application.ViewModels.Products;
using a5pwt_ctvrtek.Domain.Entities.Products;
using AutoMapper;

namespace a5pwt_ctvrtek.Application.Configuration.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
