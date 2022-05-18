using a5pwt_ctvrtek.Application.ViewModels.Products;
using a5pwt_ctvrtek.Domain.Entities.Products;
using System.Collections;
using System.Collections.Generic;

namespace a5pwt_ctvrtek.Application.Mappers.Products
{
    public interface IProductMapper
    {
        ProductViewModel GetViewModelFromEntity(Product entity);
        Product GetEntityFromViewModel(ProductViewModel viewModel);
        IList<ProductViewModel> GetViewModelsFromEntities(IList<Product> entities);
    }
}
