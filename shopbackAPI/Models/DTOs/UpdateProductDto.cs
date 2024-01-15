namespace shopbackAPI.Models.DTOs
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public double OldPrice { get; set; }
        public double SalePrice { get; set; }
    }
}
