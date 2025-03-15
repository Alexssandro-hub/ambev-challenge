using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductCartValidator : AbstractValidator<ProductCart>
{
    public ProductCartValidator()
    {
        RuleFor(productCart => productCart.Id)
            .NotEmpty()
            .WithMessage($"The ID property can't be empty or 0");

        RuleFor(productCart => productCart.ProductId)
            .NotEmpty()
            .WithMessage($"The {nameof(Product)} {nameof(Product.Id)} property can't be empty or 0");

        RuleFor(productCart => productCart.Quantity)
            .NotEmpty()
            .WithMessage(
                $"The {nameof(Product)} {nameof(ProductCart.Quantity)} property must be larger than 0 and can't be empty");
    }
}
