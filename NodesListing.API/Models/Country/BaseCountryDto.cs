using System.ComponentModel.DataAnnotations;

namespace NodesListing.API.Models.Country;

public abstract class BaseCountryDto
{
    [Required]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }
}
