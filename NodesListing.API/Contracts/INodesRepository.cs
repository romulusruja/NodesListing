using NodesListing.API.Data;

namespace NodesListing.API.Contracts;

public interface INodesRepository: IGenericRepository<Node>
{
    Task RemoveAllNodeDetailsAsync(Node node);

    Task<Node?> GetDetailsAsync(string address);
}
