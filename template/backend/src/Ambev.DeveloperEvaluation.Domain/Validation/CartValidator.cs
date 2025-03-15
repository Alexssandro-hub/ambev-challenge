using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartValidator : AbstractValidator<Cart>
{
    private const string shortDateFormat = "d";
    public CartValidator()
    {
        RuleFor(cart => cart.Id)
            .NotEmpty()
            .WithMessage($"The {nameof(Cart)} {nameof(Cart.Id)} property can't be empty or 0");

        RuleFor(cart => cart.UserId)
            .NotEmpty()
            .WithMessage($"The {nameof(Cart)} {nameof(Cart.UserId)} property can't be empty or 0");

        RuleFor(cart => cart.Date)
            .Equal(DateTime.MinValue)
            .WithMessage($"The {nameof(Cart)} {nameof(Cart.Date)} property can't be {DateTime.MinValue.ToString(shortDateFormat)}");

        RuleFor(cart => cart.Date)
            .Equal(DateTime.MaxValue)
            .WithMessage($"The {nameof(Cart)} {nameof(Cart.Date)} property can't be {DateTime.MaxValue.ToString(shortDateFormat)}");

        RuleFor(cart => cart.ProductCarts)
            .NotEmpty()
            .WithMessage($"The products are required");
    }
}
