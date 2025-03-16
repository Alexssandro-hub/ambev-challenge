namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
public class DeleteProductCommand
{
    public int Id { get; set; }
    public DeleteProductCommand(int id)
    {
        Id = id;
    }
}
