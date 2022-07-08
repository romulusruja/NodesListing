using Microsoft.EntityFrameworkCore;
using NodesListing.API.Contracts;
using NodesListing.API.Data;

namespace NodesListing.API.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T: class
{
    private readonly NodeListingDbContext _context;

    public GenericRepository(NodeListingDbContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(object id)
    {
        var entity = await GetAsync(id);
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(object id)
    {
        var entity = await GetAsync(id);

        return entity != null;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(object id)
    {
        if(id == null)
        {
            return null;
        }

        return await _context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
