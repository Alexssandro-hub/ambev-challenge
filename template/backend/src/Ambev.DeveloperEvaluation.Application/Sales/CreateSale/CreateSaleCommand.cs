using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand
    {
        public DateTime InitialDate { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string BranchSaleWasMade { get; set; } = string.Empty;
        public List<CreateProductCommand> Products { get; set; } = new List<CreateProductCommand>();
        public SaleStatus Status { get; set; }
    }
}
