using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetCategory;

public class GetCategoryResponse : PaginatedResponse<GetCategoryResponse>
{
    public string Name { get; set; } = string.Empty;
}
