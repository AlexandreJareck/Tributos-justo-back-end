using AppCrud.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCrud.Data.Mappings
{
    public class OrderItemMapping
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
