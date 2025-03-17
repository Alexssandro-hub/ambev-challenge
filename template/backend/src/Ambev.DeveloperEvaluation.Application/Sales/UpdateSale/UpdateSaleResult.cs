using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleResult
{
    public int Id { get; set; }
    public DateTime InitialDate { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public string BranchSaleWasMade { get; set; } = string.Empty;
    public List<UpdateProductCommand> Products { get; set; } = new List<UpdateProductCommand>();
    public SaleStatus Status { get; set; }
}
