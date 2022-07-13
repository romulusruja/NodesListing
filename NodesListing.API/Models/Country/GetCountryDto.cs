using NodesListing.API.Models.Node;

namespace NodesListing.API.Models.Country;

#nullable disable

public class GetCountryDto: BaseCountryDto { }

public class GetCountryDetailsDto: BaseCountryDto
{
    public List<GetNodeDto> Nodes { get; set; }
}
