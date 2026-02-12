using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    //Fluent API configuration for Product entity
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.HasKey(p => p.ProductId); // Set Id as primary key
            builder.Property(p => p.ProductName)
                .IsRequired() // Make ProductName required
                .HasMaxLength(100); // Set maximum length for ProductName
            builder.Property(p => p.ProductDescription)
                .IsRequired().HasMaxLength(100); // Set maximum length for ProductDescription
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)"); // Set column type for Price
            builder.Property(p => p.AvailableQty)
                .IsRequired(); // Make AvailableQty required

            builder.HasOne(prd => prd.ProductDetail) // Configure one-to-one relationship with ProductDetails i.e FK and PK relation
                .WithOne(pd => pd.product)
                .HasForeignKey<ProductDetail>(pd => pd.ProductId)
                .OnDelete(DeleteBehavior.Cascade); // Set cascade delete behavior
        } 
    }
}
