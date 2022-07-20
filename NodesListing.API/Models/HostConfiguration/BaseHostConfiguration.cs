using System.ComponentModel.DataAnnotations;

namespace NodesListing.API.Models.HostConfiguration;

public abstract class BaseHostConfiguration
{
    [Required]
    public string? Hostname { get; set; }

    [Required]
    public int? OnionServicePort { get; set; }

    [Required]
    public int? DirectoryServicePort { get; set; }
}
