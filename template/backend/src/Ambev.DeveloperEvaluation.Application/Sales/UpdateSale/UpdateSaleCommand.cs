using Ambev.DeveloperEvaluation.Application.Products.CreateProduct; 
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR; 

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommand : IRequest<UpdateSaleResult>
    {
        public DateTime InitialDate { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string BranchSaleWasMade { get; set; } = string.Empty;
        public List<CreateProductCommand> Products { get; set; } = new List<CreateProductCommand>();
        public SaleStatus Status { get; set; }
    }
}
