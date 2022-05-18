using a5pwt_ctvrtek.Application.ViewModels.Products;

namespace a5pwt_ctvrtek.Application.ApplicationServices.Products
{
    public interface IProductApplicationService
    {
        IndexViewModel GetIndexViewModel();
        ProductViewModel GetProductViewModel(int ID);
        ProductViewModel Insert(ProductViewModel model);
        ProductViewModel Edit(ProductViewModel model);
        ProductViewModel Delete(ProductViewModel model);
    }
}
