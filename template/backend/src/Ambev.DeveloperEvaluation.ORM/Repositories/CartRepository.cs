using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;

    public CartRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Cart> CreateAsync(Cart entity, CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<bool> UpdatedAsync(Cart entity, CancellationToken cancellationToken = default)
    {
        _context.Carts.Update(entity);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
     
    public async Task<Cart?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Carts.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    public async Task<List<Cart>> GetAllAsync(int take, int skip)
        => await _context.Carts.Skip(skip).Take(take).ToListAsync();
     
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var cart = await GetByIdAsync(id, cancellationToken);
        if (cart == null)
            return false;

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
