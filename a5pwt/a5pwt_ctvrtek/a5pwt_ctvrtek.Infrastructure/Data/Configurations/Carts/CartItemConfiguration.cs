using a5pwt_ctvrtek.Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Infrastructure.Data.Configurations.Carts
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems", "Web");

            builder.HasKey(e => e.ID);

            builder.HasOne(e => e.Product)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(e => e.ProductID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
