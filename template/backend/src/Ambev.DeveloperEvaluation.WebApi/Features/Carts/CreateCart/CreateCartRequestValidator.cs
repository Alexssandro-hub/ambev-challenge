using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{ 
    public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        public CreateCartRequestValidator()
        {
            RuleFor(cart => cart.UserId)
                .NotEmpty()
                .WithMessage($"The User ID property is required");

            RuleFor(cart => cart.Date)
                .Equal(DateTime.MinValue);

            RuleFor(cart => cart.Date)
                .Equal(DateTime.MaxValue);

            RuleFor(cart => cart.ProductCarts)
                 .NotEmpty();
        }
    }
}
