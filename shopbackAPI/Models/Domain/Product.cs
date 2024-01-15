namespace shopbackAPI.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public double  OldPrice{ get; set; }
        public double SalePrice { get; set; }
        public Guid cId { get; set; }
        public ProductCategory Category { get; set; }
    }
}
