using shopbackAPI.Models.Domain;

namespace shopbackAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<ProductCategory>> GetAllAsync();
        Task<ProductCategory?> GetByIdAsync(Guid id);
        Task<ProductCategory> CreateAsync(ProductCategory category);
        Task<ProductCategory?> UpdateAsync(Guid id,ProductCategory category);
        Task<ProductCategory?> DeleteAsync(Guid id);
    }
}
