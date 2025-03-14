using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequest
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public List<ProductCart> ProductCarts { get; set; } = new List<ProductCart>();
}
