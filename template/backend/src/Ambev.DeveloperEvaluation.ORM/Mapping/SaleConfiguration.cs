using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");
        builder.HasKey(s => s.Id); 

        builder.Property(s => s.InitialDate)
            .IsRequired();

        builder.Property(s => s.CustomerId)
            .IsRequired();

        builder.Property(s => s.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.BranchSaleWasMade)
            .IsRequired()
            .HasMaxLength(100); 

        builder.Property(s => s.Status)
            .IsRequired()
            .HasConversion<string>();  

        builder.Property(s => s.IsCanceled)
            .IsRequired();
         
        builder.HasMany(s => s.Products)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);  
    }
}
