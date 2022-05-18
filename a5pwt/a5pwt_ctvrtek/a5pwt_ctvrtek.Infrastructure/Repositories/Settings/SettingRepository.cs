
using a5pwt_ctvrtek.Domain.Entities.Settings;
using a5pwt_ctvrtek.Domain.Repositories.Settings;
using a5pwt_ctvrtek.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace a5pwt_ctvrtek.Infrastructure.Repositories.Settings
{
    public class SettingRepository : ISettingRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Setting> _dbSet;

        public SettingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<Setting>();
        }
        public Setting Add(Setting entity)
        {
            _dbSet.Add(entity);
            _dataContext.SaveChanges();

            return entity;
        }

        public Setting Get(Func<Setting, bool> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IList<Setting> GetAll()
        {
            return _dbSet.Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.ID)
                .ToList();
        }

        public IList<Setting> GetAll(Func<Setting, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public Setting Remove(Setting entity)
        {
            if (!IsAttached(entity))
            {
                _dbSet.Attach(entity);
            }
            entity.IsDeleted = true;
            _dataContext.SaveChanges();

            return entity;
        }

        public Setting Update(Setting entity)
        {
            if (!IsAttached(entity))
            {
                _dbSet.Attach(entity);
            }
            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();

            return entity;
        }

        private bool IsAttached(Setting entity)
        {
            return _dbSet.Local.Any(e => e == entity);
        }
    }
}
