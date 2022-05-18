using System;
using System.Collections.Generic;
using System.Text;
using a5pwt_ctvrtek.Domain.Entities.Products;
using a5pwt_ctvrtek.Domain.Repositories.Products;

namespace a5pwt_ctvrtek.Domain.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Delete(Product product)
        {
            return _productRepository.Remove(product);
        }

        public Product Get(Func<Product, bool> predicate)
        {
            return _productRepository.Get(predicate);
        }

        public IList<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product Insert(Product product)
        {
            return _productRepository.Add(product);
        }

        public Product Update(Product product)
        {
            return _productRepository.Update(product);
        }
    }
}
