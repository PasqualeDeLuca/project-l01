using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_l01.Api.Models;

namespace Project_l01.Api.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products", table =>
        {
            table.HasCheckConstraint(
                "CK_products_price_positive",
                "\"Price\" > 0"
            );

            table.HasCheckConstraint(
                "CK_products_stock_non_negative",
                "\"StockQuantity\" > 0"
            );

            table.HasCheckConstraint(
                "Ck_products_minimum_stock_non_negative",
                "\"MinimumStock\" >= 0"
            );
  
        });

        builder.HasKey(product => product.Id);

        builder.Property(product => product.Sku)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(product => product.Sku)
            .IsUnique();

        builder.Property(product => product.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(product => product.Description)
            .HasMaxLength(1000);

        builder.Property(product => product.Price)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(product => product.StockQuantity)
            .IsRequired();

        builder.Property(product => product.MinimumStock)
            .IsRequired();

        builder.Property(product => product.CategoryId)
            .IsRequired();

        builder.Property(product => product.CreatedAt)
            .IsRequired();

        builder.HasOne(product => product.Category)
            .WithMany()
            .HasForeignKey(product => product.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}