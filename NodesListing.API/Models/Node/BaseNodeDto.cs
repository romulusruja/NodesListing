using System.ComponentModel.DataAnnotations;

namespace NodesListing.API.Models.Node;

#nullable disable

public class BaseNodeDto
{
    [Required]
    public string Address { get; set; }

    public string CountryCode { get; set; }
}
