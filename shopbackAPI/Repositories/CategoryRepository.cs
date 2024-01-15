using Microsoft.EntityFrameworkCore;
using shopbackAPI.Data;
using shopbackAPI.Models.Domain;

namespace shopbackAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopBackDbContext dbContext;

        public CategoryRepository(ShopBackDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ProductCategory> CreateAsync(ProductCategory category)
        {
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<ProductCategory?> DeleteAsync(Guid id)
        {
            var existingCategory = await dbContext.ProductCategories.FindAsync(id);
            if(existingCategory == null)
            {
                return null;
            }
            dbContext.ProductCategories.Remove(existingCategory);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<List<ProductCategory>> GetAllAsync()
        {
            return await dbContext.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory?> GetByIdAsync(Guid id)
        {
            return await dbContext.ProductCategories.FindAsync(id);
        }

        public async Task<ProductCategory?> UpdateAsync(Guid id, ProductCategory category)
        {
            var existingCategory = await dbContext.ProductCategories.FindAsync(id);
            if (existingCategory == null) { return null; }
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.Description = category.Description;
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }
    }
}
