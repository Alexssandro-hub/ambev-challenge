using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{ 
    public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        public CreateCartRequestValidator()
        {
            RuleFor(cart => cart.UserId).Equal(Guid.NewGuid()).Equal(Guid.Empty);
            RuleFor(cart => cart.Date).Equal(DateTime.MinValue);
            RuleFor(cart => cart.Date).Equal(DateTime.MaxValue);
            RuleFor(cart => cart.ProductCarts).NotEmpty();
        }
    }
}
