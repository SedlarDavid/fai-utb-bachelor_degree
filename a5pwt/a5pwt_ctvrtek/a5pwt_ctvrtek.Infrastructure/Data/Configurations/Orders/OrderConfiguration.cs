using a5pwt_ctvrtek.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Infrastructure.Data.Configurations.Orders
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Web");

            builder.HasKey(e => e.ID);

            builder.HasMany(e => e.OrderItems)
                .WithOne(e => e.Order)
                .IsRequired()
                .HasForeignKey(e => e.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.BillingAddress)
                .WithMany()
                .IsRequired(false)
                .HasForeignKey(e => e.BillingAddressID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.ShippingAddress)
                .WithMany()
                .IsRequired(false)
                .HasForeignKey(e => e.ShippingAddressID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
