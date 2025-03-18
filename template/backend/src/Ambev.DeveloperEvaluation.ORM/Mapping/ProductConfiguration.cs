using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id); 

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(200); 

        builder.Property(p => p.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Image)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Quantity)
            .IsRequired()
            .HasDefaultValue(1); 

        builder.Property(p => p.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); 

        builder.Property(p => p.Discount)
            .IsRequired()
            .HasColumnType("decimal(5,2)"); 

        builder.Property(p => p.Total)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
         
        builder.HasOne(p => p.Rating)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
