namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetCategory;

public class GetCategoryRequest
{
    public string Name { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string OrderBy { get; set; } = string.Empty;
}
