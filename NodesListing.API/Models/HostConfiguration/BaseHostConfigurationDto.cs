using System.ComponentModel.DataAnnotations;

namespace NodesListing.API.Models.HostConfiguration;

#nullable disable

public class HostConfigurationDto
{
    [Required]
    public string Hostname { get; set; }

    [Required]
    public int OnionServicePort { get; set; }

    [Required]
    public int DirectoryServicePort { get; set; }
}

