using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetCategories;

public class GetCategoriesResponse : PaginatedResponse<GetCategoriesResponse>
{
    public string Name { get; } = string.Empty;
}
