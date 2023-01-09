using DemoStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoStore.Date.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AppDbContext _context;

        public ProductsService(AppDbContext contex)
        {
            _context= contex;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            _context.Products.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var result = await _context.Products.ToListAsync();

            return result;
        }

        public async Task<Product> GetProductAsync(long id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Product> UpdateAsync(long id, Product newProduct)
        {
            _context.Update(newProduct);
            await _context.SaveChangesAsync();

            return newProduct;
        }
    }
}
