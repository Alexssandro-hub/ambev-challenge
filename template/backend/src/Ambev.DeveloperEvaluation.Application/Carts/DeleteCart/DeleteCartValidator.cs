﻿using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public class DeleteCartValidator : AbstractValidator<DeleteCartCommand>
{
    public DeleteCartValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required");
    }
}
