using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sale> CreateAsync(Sale entity, CancellationToken cancellationToken = default);
    Task<bool> UpdatedAsync(Sale entity, CancellationToken cancellationToken = default);
    Task<Sale?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Sale>> GetAllAsync(int take, int skip);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
