using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

public class CreateSaleHandlerTestData
{
    private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
        .RuleFor(s => s.InitialDate, f => f.Date.Past(1))
        .RuleFor(s => s.CustomerId, f => Guid.NewGuid())
        .RuleFor(s => s.BranchSaleWasMade, f => f.Company.CompanyName())
        .RuleFor(s => s.TotalAmount, f => f.Random.Decimal(10, 10000))
        .RuleFor(s => s.Status, f => f.PickRandom<SaleStatus>())
        .RuleFor(s => s.Products, f => f.Make(3, () => new Faker<CreateProductCommand>()
            .RuleFor(p => p.Title, f => f.Commerce.ProductName())
            .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0])
            .RuleFor(p => p.Quantity, f => f.Random.Int(1, 100))
            .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(1, 1000))
            .Generate()));

    public static CreateSaleCommand GenerateValidCommand()
    {
        return createSaleHandlerFaker.Generate();
    }
}
