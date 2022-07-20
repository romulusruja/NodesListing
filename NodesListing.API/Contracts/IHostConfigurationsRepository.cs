using NodesListing.API.Data;

namespace NodesListing.API.Contracts;

public interface IHostConfigurationsRepository: IGenericRepository<HostConfiguration>
{
    Task<HostConfiguration?> GetDetailsAsync(int id);
}
