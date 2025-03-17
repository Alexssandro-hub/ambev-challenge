using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class RatingRepository : IRatingRepository
{
    private readonly DefaultContext _context;

    public RatingRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Rating> CreateAsync(Rating entity, CancellationToken cancellationToken = default)
    {
        await _context.Ratings.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<bool> UpdatedAsync(Rating entity, CancellationToken cancellationToken = default)
    {
        _context.Ratings.Update(entity);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<Rating?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Ratings.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    public async Task<List<Rating>> GetAllAsync(int take, int skip)
        => await _context.Ratings.Skip(skip).Take(take).ToListAsync();

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var rating = await GetByIdAsync(id, cancellationToken);
        if (rating == null)
            return false;

        _context.Ratings.Remove(rating);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
