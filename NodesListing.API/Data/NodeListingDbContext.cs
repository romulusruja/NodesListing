using Microsoft.EntityFrameworkCore;

namespace NodesListing.API.Data;

public class NodeListingDbContext: DbContext
{
    public NodeListingDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Node>? Nodes { get; set; }

    public DbSet<Country>? Countries { get; set; }

    public DbSet<HostConfiguration>? HostConfigurations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Code = "RO",
                Name = "Romania"
            });

        modelBuilder.Entity<HostConfiguration>().HasData(
            new HostConfiguration
            {
                Id = 1,
                Hostname = "localhost",
                OnionServicePort = 3000,
                DirectoryServicePort = 8080
            },
            new HostConfiguration
            {
                Id = 2,
                Hostname = "localhost",
                OnionServicePort = 3001,
                DirectoryServicePort = 8081
            });

        modelBuilder.Entity<Node>().HasData(
            new Node
            {
                Address = "node-1",
                PublicKey = "public-key-1",
                CountryCode = "RO",
                HostConfigurationId = 1,
            },
            new Node
            {
                Address = "node-2",
                PublicKey = "public-key-2",
                CountryCode = "RO",
                HostConfigurationId = 2
            });
    }
} 
