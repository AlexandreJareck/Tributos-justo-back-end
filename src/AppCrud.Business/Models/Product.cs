using FluentValidation;

namespace AppCrud.Business.Models;

public class Product : Entity
{
    public Product()
    {
        CreatedAt = DateTime.Now;
    }

    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public DateTime? CreatedAt { get; set; }
}

public class ProductValidation : AbstractValidator<Product>
{
    public ProductValidation()
    {
        RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.Quantity)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido")
            .GreaterThan(1);

        RuleFor(c => c.Price)
            .GreaterThan(0)
            .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
    }
}
