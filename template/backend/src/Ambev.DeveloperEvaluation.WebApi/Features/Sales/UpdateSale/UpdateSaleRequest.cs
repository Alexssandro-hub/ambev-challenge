using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequest
{ 
    public DateTime InitialDate { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public string BranchSaleWasMade { get; set; } = string.Empty;
    public List<CreateProductRequest> Products { get; set; } = new List<CreateProductRequest>(); 
    public SaleStatus Status { get; set; }
}
