using NodesListing.API.Models.HostConfiguration;

namespace NodesListing.API.Models.Node;

#nullable disable

public class GetNodeDto : BaseNodeDto
{
    public string PublicKey { get; set; }
}

public class GetNodeDetailsDto: BaseNodeDto
{
    public string PublicKey { get; set; }

    public HostConfigurationDto HostConfiguration { get; set; }
}
