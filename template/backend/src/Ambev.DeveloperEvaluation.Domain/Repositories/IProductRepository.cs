using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{ 
    Task<Product> CreateAsync(Product entity, CancellationToken cancellationToken = default);
    Task<bool> UpdatedAsync(Product entity, CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default); 
    Task<List<Product>> GetAllAsync(int take, int skip); 
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
