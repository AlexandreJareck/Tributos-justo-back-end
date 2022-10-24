namespace AppCrud.Api.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
