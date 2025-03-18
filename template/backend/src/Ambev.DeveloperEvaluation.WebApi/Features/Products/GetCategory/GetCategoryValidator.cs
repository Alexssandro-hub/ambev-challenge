using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetCategory;

public class GetCategoryValidator : AbstractValidator<GetCategoryRequest>
{
    public GetCategoryValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty()
            .WithMessage("The product's category name is required");
    }
}
