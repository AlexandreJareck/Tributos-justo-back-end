using System.ComponentModel.DataAnnotations;

namespace AppCrud.Api.DTOs;

public class OrderItemDTO
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int Quantity { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public decimal? UnitPrice { get; set; }

    public OrderDTO Order { get; set; }
    public ProductDTO Product { get; set; }
}
