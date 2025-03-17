using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICartRepository
{
    Task<Cart> CreateAsync(Cart entity, CancellationToken cancellationToken = default);
    Task<bool> UpdatedAsync(Cart entity, CancellationToken cancellationToken = default);
    Task<Cart?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Cart>> GetAllAsync(int take, int skip);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
