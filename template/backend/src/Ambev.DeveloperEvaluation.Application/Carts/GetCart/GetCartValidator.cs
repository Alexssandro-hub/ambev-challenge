using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

public class GetCartCommandValidator : AbstractValidator<GetCartCommand>
{
    public GetCartCommandValidator()
    {
        RuleFor(cart => cart.Id).Equal(ushort.MinValue);
    }
}
