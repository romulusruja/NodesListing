using NodesListing.API.Data;

namespace NodesListing.API.Contracts;

public interface ICountriesRepository : IGenericRepository<Country>
{
    Task<Country?> GetDetails(string id);
}
