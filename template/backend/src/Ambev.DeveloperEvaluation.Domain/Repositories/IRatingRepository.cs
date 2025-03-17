using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;
public interface IRatingRepository
{
    Task<Rating> CreateAsync(Rating entity, CancellationToken cancellationToken = default);
    Task<bool> UpdatedAsync(Rating entity, CancellationToken cancellationToken = default);
    Task<Rating?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Rating>> GetAllAsync(int take, int skip);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
