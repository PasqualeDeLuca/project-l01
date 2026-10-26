using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_l01.Api.Models;

namespace Project_l01.Api.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        
        builder.ToTable("orders", table =>
        {
            table.HasCheckConstraint(
                "CK_orders_total_non_negative",
                "\"Total\" >= 0"
            ); 
        });

        builder.HasKey(order => order.Id);

        builder.Property(order => order.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(order => order.Total)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(order => order.CreatedAt)
            .IsRequired();

        builder.HasOne(order => order.Customer)
            .WithMany(customer => customer.Orders)
            .HasForeignKey(order => order.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(order => order.CustomerId);

        builder.HasIndex(order => order.Status);


    }
}