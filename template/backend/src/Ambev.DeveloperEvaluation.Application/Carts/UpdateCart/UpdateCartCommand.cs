using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartCommand
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public List<ProductCart> ProductCarts { get; set; } = new List<ProductCart>();

        public ValidationResultDetail Validate()
        {
            var validator = new UpdateCartCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
