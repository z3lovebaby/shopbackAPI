using Microsoft.EntityFrameworkCore;
using shopbackAPI.Data;
using shopbackAPI.Models.Domain;

namespace shopbackAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopBackDbContext dbContext;

        public ProductRepository(ShopBackDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Product> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateAsync(Guid id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
