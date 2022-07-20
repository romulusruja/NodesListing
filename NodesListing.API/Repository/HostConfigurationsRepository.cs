using Microsoft.EntityFrameworkCore;
using NodesListing.API.Contracts;
using NodesListing.API.Data;

namespace NodesListing.API.Repository;

public class HostConfigurationsRepository : GenericRepository<HostConfiguration>, IHostConfigurationsRepository
{
    private readonly NodeListingDbContext _context;

    public HostConfigurationsRepository(NodeListingDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<HostConfiguration?> GetDetailsAsync(int id)
    {
        if(_context.HostConfigurations == null)
        {
            return null;
        }

        return await _context.HostConfigurations.Include(q => q.Node).FirstOrDefaultAsync(q => q.Id == id);
    }
}
