using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class RatingRepository : IRatingRepository
{
    public Task<Rating> CreateAsync(Rating entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Rating?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Rating?> GetAllAsync(int take, int skip)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
