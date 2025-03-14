using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts
{
    public class GetCartsResponse : PaginatedResponse<GetCartsResponse>
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public List<ProductCart> ProductCarts { get; set; } = new List<ProductCart>();
    }
}
