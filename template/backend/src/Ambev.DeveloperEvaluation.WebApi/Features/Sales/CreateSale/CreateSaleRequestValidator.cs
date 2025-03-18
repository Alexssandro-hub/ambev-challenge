using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    const string ShortDateFormat = "d";
    public CreateSaleRequestValidator()
    {  
        RuleFor(sale => sale.BranchSaleWasMade)
            .Equal(string.Empty)
            .WithMessage($"");

        RuleFor(sale => sale.InitialDate)
            .Equal(DateTime.MinValue)
            .WithMessage($"The Date property can't be {DateTime.MinValue.ToString(ShortDateFormat)}");

        RuleFor(sale => sale.InitialDate)
            .Equal(DateTime.MaxValue)
            .WithMessage($"The Date property can't be {DateTime.MaxValue.ToString(ShortDateFormat)}");

        RuleFor(sale => sale.CustomerId)
            .NotEmpty()
            .WithMessage($"The {nameof(User)} {nameof(User.Id)} property is required");

        RuleFor(sale => sale.TotalAmount)
            .Equal(decimal.Zero)
            .WithMessage($"The {nameof(Sale)} {nameof(Sale.TotalAmount)} property can't be 0");

        RuleFor(sale => sale.Products)
            .Must(products => products.All(p => p.Quantity <= 20))
            .WithMessage("A product cannot have more than 20 units.");
    }
}
