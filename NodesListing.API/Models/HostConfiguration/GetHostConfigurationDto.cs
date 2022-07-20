using NodesListing.API.Models.Node;

namespace NodesListing.API.Models.HostConfiguration;

public class GetHostConfigurationDto: BaseHostConfiguration 
{
    public int Id { get; set; }
}

public class GetHostConfigurationDetailsDto: BaseHostConfiguration
{
    public GetNodeDto? Node { get; set; }
}