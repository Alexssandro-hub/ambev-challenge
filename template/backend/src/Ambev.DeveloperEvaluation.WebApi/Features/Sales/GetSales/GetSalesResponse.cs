using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public class GetSalesResponse : PaginatedResponse<GetSalesResponse>
{
    public int Id { get; set; }
    public int Number { get; set; }
    public DateTime InitialDate { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public string BranchSaleWasMade { get; set; } = string.Empty;
    public List<UpdateProductResponse> Products { get; set; } = new List<UpdateProductResponse>();
    public int Quantities { get; set; }
    public decimal UnitPrices { get; set; }
    public float Discounts { get; set; }
    public decimal ProductsTotalAmount { get; set; }
    public bool IsCanceled { get; set; } = false;
}
