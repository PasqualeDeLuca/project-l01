using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_l01.Api.Models;

namespace Project_l01.Api.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        
        builder.ToTable("order_items", table =>
        {
            table.HasCheckConstraint(
                "CK_order_items_quantity_positive",
                "\"Quantity\" > 0"
            );

            table.HasCheckConstraint(
                "CK_order_items_unit_price_positive",
                "\"UnitPrice\" > 0" 
            );

        });

        builder.HasKey(item => item.Id);

        builder.Property(item => item.Quantity)
            .IsRequired();

        builder.Property(item => item.UnitPrice)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.HasOne(item => item.Order)
            .WithMany(order => order.Items)
            .HasForeignKey(item => item.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(item => item.Product)
            .WithMany()
            .HasForeignKey(item => item.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(item => item.OrderId);

        builder.HasIndex(item => item.ProductId);
    }
}