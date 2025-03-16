using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleResponse
{
    public int Id { get; set; }
    public int Number { get; set; }
    public DateTime InitialDate { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public string BranchSaleWasMade { get; set; } = string.Empty;
    public List<UpdateProductResponse> Products { get; set; } = new List<UpdateProductResponse>();
    public int Quantities { get; set; }
    public decimal UnitPrices { get; set; }
    public float Discounts { get; set; }
    public decimal ProductsTotalAmount { get; set; }
    public SaleStatus Status { get; set; }
}
