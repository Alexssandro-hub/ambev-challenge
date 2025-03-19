using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class ApplyDiscountTests
{
    /// <summary>
    /// Tests that a 20% discount is applied when the quantity is 10 or more.
    /// </summary>
    [Fact(DisplayName = "Given quantity >= 10 When applying discount Then applies 20% discount")]
    public void ApplyDiscount_QuantityGreaterThanOrEqualTo10_Applies20PercentDiscount()
    {
        // Given
        var sale = new Sale
        {
            Products = new List<Product>
            {
                new Product
                {
                    Quantity = 10,
                    UnitPrice = 100m,
                    Id = 0,
                    Title = null,
                    Category = null,
                    Image = null,
                    RatingId = 0,
                    Rating = null,
                    Discount = 0,
                    Total = 0
                },
                new Product
                {
                    Quantity = 15,
                    UnitPrice = 200m,
                    Id = 0,
                    Title = null,
                    Category = null,
                    Image = null,
                    RatingId = 0,
                    Rating = null,
                    Discount = 0,
                    Total = 0
                }
            },
            Id = 0,
            InitialDate = default,
            CustomerId = default,
            TotalAmount = 0,
            BranchSaleWasMade = null,
            Status = SaleStatus.None,
            IsCanceled = false
        };

        // When
        ApplyDiscount.ApplyDiscountRules(sale);

        // Then
        sale.Products[0].Discount.Should().Be(0.2m);
        sale.Products[1].Discount.Should().Be(0.2m);
        sale.Products[0].Total.Should().Be(800m); // 10 * 100 * (1 - 0.2)
        sale.Products[1].Total.Should().Be(2400m); // 15 * 200 * (1 - 0.2)
        sale.TotalAmount.Should().Be(3200m); // 800 + 2400
    }

    /// <summary>
    /// Tests that a 10% discount is applied when the quantity is between 4 and 9.
    /// </summary>
    [Fact(DisplayName = "Given quantity >= 4 and < 10 When applying discount Then applies 10% discount")]
    public void ApplyDiscount_QuantityGreaterThanOrEqualTo4_AndLessThan10_Applies10PercentDiscount()
    {
        // Given
        var sale = new Sale
        {
            Products = new List<Product>
            {
                new Product
                {
                    Quantity = 5,
                    UnitPrice = 100m,
                    Id = 0,
                    Title = null,
                    Category = null,
                    Image = null,
                    RatingId = 0,
                    Rating = null,
                    Discount = 0,
                    Total = 0
                },
                new Product
                {
                    Quantity = 8,
                    UnitPrice = 200m,
                    Id = 0,
                    Title = null,
                    Category = null,
                    Image = null,
                    RatingId = 0,
                    Rating = null,
                    Discount = 0,
                    Total = 0
                }
            },
            Id = 0,
            InitialDate = default,
            CustomerId = default,
            TotalAmount = 0,
            BranchSaleWasMade = null,
            Status = SaleStatus.None,
            IsCanceled = false
        };

        // When
        ApplyDiscount.ApplyDiscountRules(sale);

        // Then
        sale.Products[0].Discount.Should().Be(0.1m);
        sale.Products[1].Discount.Should().Be(0.1m);
        sale.Products[0].Total.Should().Be(450m); // 5 * 100 * (1 - 0.1)
        sale.Products[1].Total.Should().Be(1440m); // 8 * 200 * (1 - 0.1)
        sale.TotalAmount.Should().Be(1890m); // 450 + 1440
    }

    /// <summary>
    /// Tests that no discount is applied when the quantity is less than 4.
    /// </summary>
    [Fact(DisplayName = "Given quantity < 4 When applying discount Then applies no discount")]
    public void ApplyDiscount_QuantityLessThan4_AppliesNoDiscount()
    {
        // Given
        var sale = new Sale
        {
            Products = new List<Product>
            {
                new Product
                {
                    Quantity = 3,
                    UnitPrice = 100m,
                    Id = 0,
                    Title = null,
                    Category = null,
                    Image = null,
                    RatingId = 0,
                    Rating = null,
                    Discount = 0,
                    Total = 0
                },
                new Product
                {
                    Quantity = 2,
                    UnitPrice = 200m,
                    Id = 0,
                    Title = null,
                    Category = null,
                    Image = null,
                    RatingId = 0,
                    Rating = null,
                    Discount = 0,
                    Total = 0
                }
            },
            Id = 0,
            InitialDate = default,
            CustomerId = default,
            TotalAmount = 0,
            BranchSaleWasMade = null,
            Status = SaleStatus.None,
            IsCanceled = false
        };

        // When
        ApplyDiscount.ApplyDiscountRules(sale);

        // Then
        sale.Products[0].Discount.Should().Be(0);
        sale.Products[1].Discount.Should().Be(0);
        sale.Products[0].Total.Should().Be(300m); // 3 * 100
        sale.Products[1].Total.Should().Be(400m); // 2 * 200
        sale.TotalAmount.Should().Be(700m); // 300 + 400
    }

    /// <summary>
    /// Tests that an exception is thrown when the quantity is greater than 20.
    /// </summary>
    [Fact(DisplayName = "Given quantity > 20 When applying discount Then throws exception")]
    public void ApplyDiscount_QuantityGreaterThan20_ThrowsException()
    {
        // Given
        var sale = new Sale
        {
            Products = new List<Product>
            {
                new Product
                {
                    Quantity = 21,
                    UnitPrice = 100m,
                    Id = 0,
                    Title = null,
                    Category = null,
                    Image = null,
                    RatingId = 0,
                    Rating = null,
                    Discount = 0,
                    Total = 0
                }
            },
            Id = 0,
            InitialDate = default,
            CustomerId = default,
            TotalAmount = 0,
            BranchSaleWasMade = null,
            Status = SaleStatus.None,
            IsCanceled = false
        };

        // When
        var act = () => ApplyDiscount.ApplyDiscountRules(sale);

        // Then
        act.Should().Throw<InvalidOperationException>().WithMessage("Cannot sell more than 20 identical items.");
    }

    /// <summary>
    /// Tests that the total amount of the sale is correctly calculated after applying discounts.
    /// </summary>
    [Fact(DisplayName = "Given products with discounts When applying discount Then recalculates total amount")]
    public void ApplyDiscount_RecalculatesTotalAmountCorrectly()
    {
        // Given
        var sale = new Sale
        {
            Products = new List<Product>
            {
                new Product
                {
                    Quantity = 5,
                    UnitPrice = 100m,
                    Id = 0,
                    Title = null,
                    Category = null,
                    Image = null,
                    RatingId = 0,
                    Rating = null,
                    Discount = 0,
                    Total = 0
                },
                new Product
                {
                    Quantity = 15,
                    UnitPrice = 200m,
                    Id = 0,
                    Title = null,
                    Category = null,
                    Image = null,
                    RatingId = 0,
                    Rating = null,
                    Discount = 0,
                    Total = 0
                }
            },
            Id = 0,
            InitialDate = default,
            CustomerId = default,
            TotalAmount = 0,
            BranchSaleWasMade = null,
            Status = SaleStatus.None,
            IsCanceled = false
        };

        // When
        ApplyDiscount.ApplyDiscountRules(sale);

        // Then
        sale.TotalAmount.Should().Be(3200m); // 450 + 2400
    }
}
