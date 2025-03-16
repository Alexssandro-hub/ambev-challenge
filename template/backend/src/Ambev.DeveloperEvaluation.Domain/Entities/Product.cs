using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product 
{
    public required int Id { get; set; }
    public required string Title { get; set; } 
    public required string Category { get; set; }
    public required string Image { get; set; }
    public required Rating Rating { get; set; }
    public required int Quantity { get; set; }
    public required decimal UnitPrice { get; set; }
    public required decimal Discount { get; set; }
    public required decimal Total { get; set; }  
}
