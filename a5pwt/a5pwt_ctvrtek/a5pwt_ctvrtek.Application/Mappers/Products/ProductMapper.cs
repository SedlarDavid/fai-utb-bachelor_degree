using System;
using System.Collections.Generic;
using a5pwt_ctvrtek.Application.ViewModels.Products;
using a5pwt_ctvrtek.Domain.Entities.Products;
using AutoMapper;

namespace a5pwt_ctvrtek.Application.Mappers.Products
{
    public class ProductMapper : IProductMapper
    {
        private readonly IMapper _mapper;

        public ProductMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Product GetEntityFromViewModel(ProductViewModel viewModel)
        {
            return _mapper.Map<Product>(viewModel);
        }

        public ProductViewModel GetViewModelFromEntity(Product entity)
        {
            return _mapper.Map<ProductViewModel>(entity);
        }

        public IList<ProductViewModel> GetViewModelsFromEntities(IList<Product> entities)
        {
            return _mapper.Map<IList<ProductViewModel>>(entities);
        }
    }
}
