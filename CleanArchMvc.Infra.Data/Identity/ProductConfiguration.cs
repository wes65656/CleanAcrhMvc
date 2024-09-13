using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.Identity;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        
        builder.Property(c => c.Description).HasMaxLength(150).IsRequired();
        builder.Property(c => c.Price).HasPrecision(10, 2).IsRequired();

        builder.HasOne(c => c.Category).WithMany(c => c.Products).HasForeignKey(c => c.CategoryId);

    }
}