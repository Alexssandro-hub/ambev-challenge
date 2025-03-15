using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartCommandValidator()
    {
        RuleFor(cart => cart.UserId).Equal(Guid.NewGuid());
        RuleFor(cart => cart.UserId).Equal(Guid.Empty);
        RuleFor(cart => cart.Date).Equal(DateTime.MinValue);
        RuleFor(cart => cart.Date).Equal(DateTime.MaxValue);
        RuleFor(cart => cart.ProductCarts).NotEmpty();
    }
}
