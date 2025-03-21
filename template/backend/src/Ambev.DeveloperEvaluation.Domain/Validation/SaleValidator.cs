﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    private const string ShortDateFormat = "d";
    public SaleValidator()
    {
        RuleFor(sale => sale.Id)
            .NotEmpty()
            .WithMessage($"The {nameof(Sale)} {nameof(Sale.Id)} property can't be empty or 0");

        RuleFor(sale => sale.BranchSaleWasMade)
            .Equal(string.Empty)
            .WithMessage($"The {nameof(Sale)} {nameof(Sale.BranchSaleWasMade)} property can't be empty");

        RuleFor(sale => sale.CustomerId)
            .NotEmpty() 
            .WithMessage($"The User ID property can't be empty or 0");

        RuleFor(sale => sale.InitialDate)
            .Equal(DateTime.MinValue)
            .WithMessage($"The {nameof(Sale)} Date property can't be {DateTime.MinValue.ToString(ShortDateFormat)}");

        RuleFor(sale => sale.InitialDate)
            .Equal(DateTime.MaxValue)
            .WithMessage($"The {nameof(Sale)} Date property can't be {DateTime.MaxValue.ToString(ShortDateFormat)}");

        RuleFor(sale => sale.Products)
            .NotEmpty()
            .WithMessage($"The products are required");

        RuleFor(sale => sale.Products)
            .Must(products => products.All(p => p.Quantity <= 20))
            .WithMessage("A product cannot have more than 20 units.");

        RuleFor(sale => sale.TotalAmount)
            .Equal(decimal.Zero)
            .WithMessage($"The {nameof(Sale)} {nameof(Sale.TotalAmount)} can't be 0");

    }
}
