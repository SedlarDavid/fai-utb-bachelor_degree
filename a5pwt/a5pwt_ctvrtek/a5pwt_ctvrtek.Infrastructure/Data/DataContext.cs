using a5pwt_ctvrtek.Domain.Entities;
using a5pwt_ctvrtek.Domain.Entities.Carts;
using a5pwt_ctvrtek.Domain.Entities.Orders;
using a5pwt_ctvrtek.Domain.Entities.Products;
using a5pwt_ctvrtek.Domain.Entities.Settings;
using a5pwt_ctvrtek.Infrastructure.Identity.Roles;
using a5pwt_ctvrtek.Infrastructure.Identity.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace a5pwt_ctvrtek.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Setting> Setting { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName =
                    entity.Relational().TableName.Replace("AspNet", string.Empty);
            }
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var changedEntities = ChangeTracker.Entries().Where(e => e.Entity is Entity
                                                && (e.State == EntityState.Modified ||
                                                    e.State == EntityState.Added ||
                                                    e.State == EntityState.Deleted));

            foreach (var item in changedEntities)
            {
                var entity = item.Entity as Entity;

                if(item.State == EntityState.Added)
                {
                    entity.DateCreated = DateTime.Now;
                }
                entity.DateUpdated = DateTime.Now;
            }

            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChanges();
            ChangeTracker.AutoDetectChangesEnabled = true;

            return result;
        }
    }
}
