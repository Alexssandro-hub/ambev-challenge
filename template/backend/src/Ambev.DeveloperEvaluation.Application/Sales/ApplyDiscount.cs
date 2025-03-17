using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public static class ApplyDiscount
{
    public static void ApplyDiscountRules(Sale sale)
    {
        const decimal twentyPercent = 0.2m;
        const decimal tenPercent = 0.1m;

        foreach (var item in sale.Products)
        {
            item.Discount = item.Quantity switch
            {
                > 20 => throw new InvalidOperationException("Cannot sell more than 20 identical items."),
                >= 10 => twentyPercent,
                >= 4 => tenPercent,
                _ => 0
            };

            item.Total = item.Quantity * item.UnitPrice * (1 - item.Discount);
        }

        sale.TotalAmount = sale.Products.Sum(i => i.Total);
    }
}
