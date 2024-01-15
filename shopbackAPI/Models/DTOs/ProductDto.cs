using shopbackAPI.Models.Domain;

namespace shopbackAPI.Models.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public double OldPrice { get; set; }
        public double SalePrice { get; set; }
        public ProductCategory Category { get; set; }
    }
}
