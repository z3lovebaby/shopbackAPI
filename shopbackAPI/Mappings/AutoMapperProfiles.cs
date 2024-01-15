using AutoMapper;
using shopbackAPI.Models.Domain;
using shopbackAPI.Models.DTOs;

namespace shopbackAPI.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductCategory, CategoryDto>().ReverseMap();
            CreateMap<ProductCategory, AddCategory>().ReverseMap();
            CreateMap<ProductCategory,UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, AddProduct>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
