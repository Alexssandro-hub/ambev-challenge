using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductValidator : AbstractValidator<GetProductCommand>
{
    public GetProductValidator()
    {
        RuleFor(product => product.Id)
            .NotEmpty()
            .WithMessage($"Product ID is required");
    }
}
