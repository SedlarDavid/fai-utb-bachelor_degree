using System;
using System.Linq;
using a5pwt_ctvrtek.Application.Mappers.Products;
using a5pwt_ctvrtek.Application.ViewModels.Products;
using a5pwt_ctvrtek.Domain.Services.Files;
using a5pwt_ctvrtek.Domain.Services.Products;

namespace a5pwt_ctvrtek.Application.ApplicationServices.Products
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductMapper _productMapper;
        private readonly IProductService _productService;
        private readonly IFileHandler _fileHandler;

        public ProductApplicationService(
            IProductMapper productMapper,
            IProductService productService,
            IFileHandler fileHandler)
        {
            _productMapper = productMapper;
            _productService = productService;
            _fileHandler = fileHandler;
        }

        public ProductViewModel Delete(ProductViewModel model)
        {
            var entity = _productMapper.GetEntityFromViewModel(model);
            return _productMapper.GetViewModelFromEntity(_productService.Delete(entity));
        }

        public ProductViewModel Edit(ProductViewModel model)
        {
            var entity = _productMapper.GetEntityFromViewModel(model);
            if (model.Image != null)
            {
                entity.ImageURL = _fileHandler.SaveImage(model.Image);
            }
            return _productMapper.GetViewModelFromEntity(_productService.Update(entity));
        }

        public ProductViewModel Insert(ProductViewModel model)
        {
            var entity = _productMapper.GetEntityFromViewModel(model);
            if (model.Image != null)
            {
                entity.ImageURL = _fileHandler.SaveImage(model.Image);
            }
            return _productMapper.GetViewModelFromEntity(_productService.Insert(entity));
        }

        public ProductViewModel GetProductViewModel(int ID)
        {
            return _productMapper.GetViewModelFromEntity(
                _productService.Get(e => e.ID == ID));
        }

        public IndexViewModel GetIndexViewModel()
        {
            return new IndexViewModel
            {
                Products = _productMapper.GetViewModelsFromEntities(
                    _productService.GetAll()).ToList()
            };
        }

    
    }
}
