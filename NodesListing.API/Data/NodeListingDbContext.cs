using Microsoft.EntityFrameworkCore;

namespace NodesListing.API.Data;

public class NodeListingDbContext: DbContext
{
    public NodeListingDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Node>? Nodes { get; set; }

    public DbSet<Country>? Countries { get; set; }

    public DbSet<HostConfiguration>? HostConfigurations { get; set; }
} 
