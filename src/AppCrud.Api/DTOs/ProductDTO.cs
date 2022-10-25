using System.ComponentModel.DataAnnotations;

namespace AppCrud.Api.DTOs;

public class ProductDTO
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracateres", MinimumLength = 3)]
    public string Description { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int Quantity { get; set; }
}
