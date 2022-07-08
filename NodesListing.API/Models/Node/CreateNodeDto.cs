using System.ComponentModel.DataAnnotations;

namespace NodesListing.API.Models.Node;

public class CreateNodeDto
{
    [Required]
    public string PublicKey { get; set; }

    public string CountryCode { get; set; }
}

