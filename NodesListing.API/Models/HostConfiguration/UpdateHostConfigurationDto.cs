using System.ComponentModel.DataAnnotations;

namespace NodesListing.API.Models.HostConfiguration;

public class UpdateHostConfigurationDto
{
    [Required]
    public int? Id { get; set; }

    public string? Hostname { get; set; }

    public int? OnionServicePort { get; set; }

    public int? DirectoryServicePort { get; set; }
}
