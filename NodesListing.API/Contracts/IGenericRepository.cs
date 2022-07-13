namespace NodesListing.API.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetAsync(object id);

    Task<List<T>> GetAllAsync();

    Task<T> AddAsync(T entity);

    Task DeleteAsync(T entity);

    Task UpdateAsync(T entity);

    Task<bool> Exists(object id);
}

