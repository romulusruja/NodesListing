using NodesListing.API.Models.HostConfiguration;
using System.ComponentModel.DataAnnotations;

namespace NodesListing.API.Models.Node;

#nullable disable

public class CreateNodeDto: BaseNodeDto
{
    [Required]
    public string PublicKey { get; set; }

    [Required]
    public GetHostConfigurationDto HostConfiguration { get; set; }
}
