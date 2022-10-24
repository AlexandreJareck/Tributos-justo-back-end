using AppCrud.Business.Models;

namespace AppCrud.Api.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public decimal TotalValue { get; set; }
        public Client Client { get; set; }
        public List<Product> Products { get; set; }
    }
}
