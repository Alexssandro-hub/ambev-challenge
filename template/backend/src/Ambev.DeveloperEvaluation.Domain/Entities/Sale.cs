using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale
{
    public required int Id { get; set; } 
    public required DateTime InitialDate { get; set; }
    public required Guid CustomerId { get; set; }
    public required decimal TotalAmount { get; set; }
    public required string BranchSaleWasMade { get; set; } = string.Empty;
    public required List<Product> Products { get; set; } = new List<Product>();
    public required SaleStatus Status { get; set; }
    public required bool IsCanceled { get; set; }
}
