using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    private const string ShortDateFormat = "d";

    public CreateCartCommandValidator()
    {
        RuleFor(cart => cart.UserId)
            .Equal(Guid.NewGuid())
            .WithMessage("The property User ID can't be 0");
        
        RuleFor(cart => cart.Date)
            .Equal(DateTime.MinValue)
            .WithMessage($"Date property can't be {DateTime.MinValue.ToString(ShortDateFormat)}");

        RuleFor(cart => cart.Date)
            .Equal(DateTime.MaxValue)
            .WithMessage($"Date property can't be {DateTime.MaxValue.ToString(ShortDateFormat)}");

        RuleFor(cart => cart.ProductCarts)
            .NotEmpty()
            .WithMessage("The products are required"); 
    }
}
