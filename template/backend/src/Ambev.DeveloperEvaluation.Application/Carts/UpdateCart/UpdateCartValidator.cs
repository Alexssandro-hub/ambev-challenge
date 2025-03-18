using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
{
    private const string ShortDateFormat = "d";
    public UpdateCartCommandValidator()
    {
        RuleFor(cart => cart.UserId)
            .Equal(Guid.NewGuid())
            .WithMessage("User ID is required");

        RuleFor(cart => cart.UserId)
            .Equal(Guid.Empty)
            .WithMessage("User ID is required");

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
