using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartCommandValidator()
    {
        RuleFor(cart => cart.UserId).Equal(Guid.NewGuid()).Equal(Guid.Empty);
        RuleFor(cart => cart.Date).Equal(DateTime.MinValue);
        RuleFor(cart => cart.Date).Equal(DateTime.MaxValue);
        RuleFor(cart => cart.ProductCarts).NotEmpty(); 
    }
}
