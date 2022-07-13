using AutoMapper;
using NodesListing.API.Data;
using NodesListing.API.Models.Country;
using NodesListing.API.Models.HostConfiguration;
using NodesListing.API.Models.Node;

namespace NodesListing.API.Configurations;

public class MapperConfig: Profile
{
    public MapperConfig()
    {
        CreateMap<Node, CreateNodeDto>().ReverseMap();
        CreateMap<Node, GetNodeDto>().ReverseMap();
        CreateMap<Node, GetNodeDetailsDto>().ReverseMap();
        CreateMap<Node, UpdateNodeDto>().ReverseMap();

        CreateMap<Country, GetCountryDto>().ReverseMap();
        CreateMap<Country, GetCountryDetailsDto>().ReverseMap();

        CreateMap<HostConfiguration, HostConfigurationDto>().ReverseMap();
    }
}
