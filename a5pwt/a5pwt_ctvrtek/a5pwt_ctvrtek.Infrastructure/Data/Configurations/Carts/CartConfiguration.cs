using a5pwt_ctvrtek.Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Infrastructure.Data.Configurations.Carts
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts", "Web");

            builder.HasKey(e => e.ID);

            builder.HasMany(e => e.CartItems)
                .WithOne(e => e.Cart)
                .HasForeignKey(e => e.CartID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
