using a5pwt_ctvrtek.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Domain.Services.Products
{
    public interface IProductService
    {
        IList<Product> GetAll();
        Product Get(Func<Product, bool> predicate);
        Product Insert(Product product);
        Product Update(Product product);
        Product Delete(Product product);
    }
}
