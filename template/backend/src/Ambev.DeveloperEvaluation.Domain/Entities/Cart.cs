using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Cart
{
    public required int Id { get; set; }
    public required Guid UserId { get; set; }
    public required DateTime Date { get; set; }
    public required List<ProductCart> ProductCarts { get; set; }
}
