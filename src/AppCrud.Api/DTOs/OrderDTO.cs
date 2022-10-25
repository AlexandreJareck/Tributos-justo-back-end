namespace AppCrud.Api.DTOs;

public class OrderDTO
{
    public Guid Id { get; set; }
    public decimal TotalValue { get; set; }
    public ClientDTO Client { get; set; }
    public List<ProductDTO> Products { get; set; }
}
