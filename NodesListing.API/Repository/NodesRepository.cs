using Microsoft.EntityFrameworkCore;
using NodesListing.API.Contracts;
using NodesListing.API.Data;

namespace NodesListing.API.Repository;
public class NodesRepository : GenericRepository<Node>, INodesRepository
{
    private readonly NodeListingDbContext _context;

    public NodesRepository(NodeListingDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Node?> GetDetailsAsync(string address)
    {
        if(_context.Nodes == null)
        {
            return null;
        }

        return await _context.Nodes.Include(q => q.HostConfiguration).FirstOrDefaultAsync(n => n.Address == address);
    }

    public async Task RemoveAllNodeDetailsAsync(Node node)
    {
        _context.Remove(node);
        
        if(_context.HostConfigurations != null)
        {
            _context.HostConfigurations.Remove(new HostConfiguration { Id = node.HostConfigurationId });
        }

        await _context.SaveChangesAsync();
    }
}
