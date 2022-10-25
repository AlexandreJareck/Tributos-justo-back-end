using System.ComponentModel.DataAnnotations;

namespace AppCrud.Api.DTOs;

public class ClientDTO
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(18, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracateres", MinimumLength = 11)]
    public string Document { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracateres", MinimumLength = 3)]
    public string Name { get; set; }
}
