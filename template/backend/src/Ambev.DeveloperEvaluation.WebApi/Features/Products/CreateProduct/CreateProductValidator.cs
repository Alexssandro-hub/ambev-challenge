using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{ 
    public CreateProductValidator()
    {
        RuleFor(product => product.Title)
            .Equal(string.Empty)
            .WithMessage($"The Title property can't be empty");

        RuleFor(product => product.UnitPrice)
            .Equal(decimal.Zero)
            .WithMessage($"The Unit Price can't be 0");

        RuleFor(product => product.Total)
            .Equal(decimal.Zero)
            .WithMessage($"The Total property can't be 0");

        RuleFor(product => product.Quantity)
            .Equal(ushort.MinValue)
            .WithMessage($"The product must have at least one item");

        RuleFor(product => product.Category)
            .Equal(string.Empty)
            .WithMessage($"The Category is required");
    }
}
