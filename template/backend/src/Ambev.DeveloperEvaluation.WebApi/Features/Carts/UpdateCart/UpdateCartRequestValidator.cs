using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
{
    public UpdateCartRequestValidator()
    {
        RuleFor(cart => cart.UserId)
            .NotEmpty();

        RuleFor(cart => cart.Date)
            .Equal(DateTime.MinValue);

        RuleFor(cart => cart.Date)
            .Equal(DateTime.MaxValue);

        RuleFor(cart => cart.ProductCarts)
            .NotEmpty();
    }
}
