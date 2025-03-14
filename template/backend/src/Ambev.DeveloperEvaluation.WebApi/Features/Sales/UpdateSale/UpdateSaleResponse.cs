using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleResponse
{
    public int Id { get; set; }
    public int Number { get; set; }
    public DateTime InitialDate { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public string BranchSaleWasMade { get; set; } = string.Empty;
    public List<CreateProductRequest> Products { get; set; } = new List<CreateProductRequest>();
    public int Quantities { get; set; }
    public decimal UnitPrices { get; set; }
    public float Discounts { get; set; }
    public decimal ProductsTotalAmount { get; set; }
    public bool IsCanceled { get; set; } = false;
}
