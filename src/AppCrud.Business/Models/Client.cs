using FluentValidation;

namespace AppCrud.Business.Models;

public class Client : Entity
{
    public Client()
    {
        CreatedAt = DateTime.Now;
    }

    public string Name { get; set; }

    public string Document { get; set; }
    public DateTime? CreatedAt { get; set; }
}

public class ClientValidation : AbstractValidator<Client>
{
    public ClientValidation()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 200)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.Document)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(11, 14)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
    }
}
