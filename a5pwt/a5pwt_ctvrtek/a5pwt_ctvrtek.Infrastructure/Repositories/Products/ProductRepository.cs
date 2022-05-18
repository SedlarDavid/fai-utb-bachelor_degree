using System;
using System.Collections.Generic;
using System.Linq;
using a5pwt_ctvrtek.Domain.Entities.Products;
using a5pwt_ctvrtek.Domain.Repositories.Products;
using a5pwt_ctvrtek.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace a5pwt_ctvrtek.Infrastructure.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<Product>();
        }

        public Product Add(Product entity)
        {
            _dbSet.Add(entity);
            _dataContext.SaveChanges();

            return entity;
        }

        public Product Get(Func<Product, bool> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IList<Product> GetAll()
        {
            return _dbSet.Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.ID)
                //.ThenBy(x => x.Price)
                .ToList();
        }

        public IList<Product> GetAll(Func<Product, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public Product Remove(Product entity)
        {
            if (!IsAttached(entity))
            {
                _dbSet.Attach(entity);
            }
            entity.IsDeleted = true;
            _dataContext.SaveChanges();

            return entity;
        }

        public Product Update(Product entity)
        {
            if (!IsAttached(entity))
            {
                _dbSet.Attach(entity);
            }
            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();

            return entity;
        }

        private bool IsAttached(Product entity)
        {
            return _dbSet.Local.Any(e => e == entity);
        }
    }
}
