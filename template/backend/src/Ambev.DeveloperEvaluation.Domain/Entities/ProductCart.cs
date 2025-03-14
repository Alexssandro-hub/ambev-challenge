using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ProductCart : BaseEntity
{
    public required int ProductId { get; set; }
    public required int Quantity { get; set; }
}
