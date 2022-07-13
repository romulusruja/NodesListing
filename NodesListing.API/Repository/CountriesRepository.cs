using Microsoft.EntityFrameworkCore;
using NodesListing.API.Contracts;
using NodesListing.API.Data;

namespace NodesListing.API.Repository;

public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
{
    private readonly NodeListingDbContext _context;

    public CountriesRepository(NodeListingDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Country?> GetDetails(string code)
    {
        if(_context.Countries == null)
        {
            return null;
        }

        return await _context.Countries.Include(q => q.Nodes).FirstOrDefaultAsync(q => q.Code == code);
    }
}
