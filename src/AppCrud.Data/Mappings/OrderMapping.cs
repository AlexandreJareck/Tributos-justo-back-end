using AppCrud.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCrud.Data.Mappings;

public class OrderMapping
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(t => t.Id);

        // 1 : N => Order : Products
        builder.HasMany(o => o.Items)
            .WithOne(i => i.Order)
            .HasForeignKey(p => p.OrderId);
    }
}
