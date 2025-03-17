using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale> CreateAsync(Sale entity, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<bool> UpdatedAsync(Sale entity, CancellationToken cancellationToken = default)
    {
        _context.Sales.Update(entity);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<Sale?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Sales.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    public async Task<List<Sale>> GetAllAsync(int take, int skip)
        => await _context.Sales.Skip(skip).Take(take).ToListAsync();

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
