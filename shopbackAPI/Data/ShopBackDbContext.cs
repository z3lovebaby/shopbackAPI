using Microsoft.EntityFrameworkCore;
using shopbackAPI.Models.Domain;

namespace shopbackAPI.Data
{
    public class ShopBackDbContext:DbContext
    {
        public ShopBackDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
