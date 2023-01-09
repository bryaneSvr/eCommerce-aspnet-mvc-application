using DemoStore.Models;

namespace DemoStore.Date.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetProductAsync(long id);

        Task AddAsync(Product product);

        Task<Product> UpdateAsync(long id, Product product);

        Task DeleteAsync(long id);
    }
}
