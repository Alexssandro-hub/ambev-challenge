using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Quantity)
            .NotEmpty()
            .WithMessage($"The {nameof(Product)} {nameof(Product.Quantity)} must be greater than 0");

        RuleFor(p => p.UnitPrice)
            .Equal(decimal.Zero)
            .WithMessage($"The {nameof(Product)} {nameof(Product.UnitPrice)} property must be greater than 0");

        RuleFor(p => p.Category)
            .NotEmpty()
            .WithMessage($"The {nameof(Product)} {nameof(Product.Category)} is required");

        RuleFor(p => p.Image)
            .NotEmpty()
            .WithMessage($"The {nameof(Product)} {nameof(Product.Image)} is required");

        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage($"The {nameof(Product)} {nameof(Product.Title)} is required");

        RuleFor(p => p.Total)
            .Equal(decimal.Zero)
            .WithMessage($"The {nameof(Product)} {nameof(Product.Total)} must be greater than 0");

    }
}
