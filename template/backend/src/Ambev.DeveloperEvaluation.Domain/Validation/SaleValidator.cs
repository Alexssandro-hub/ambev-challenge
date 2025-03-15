using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.Id)
            .NotEmpty()
            .WithMessage($"The {nameof(Sale)} {nameof(Sale.Id)} property can't be empty or 0");

        
    }
}
