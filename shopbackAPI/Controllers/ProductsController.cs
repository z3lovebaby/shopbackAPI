using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopbackAPI.CustomActionFilter;
using shopbackAPI.Models.Domain;
using shopbackAPI.Models.DTOs;
using shopbackAPI.Repositories;

namespace shopbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepository,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productRepository.GetAllAsync();
            return Ok(mapper.Map<List<ProductDto>>(products));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound("Not found");
            }
            return Ok(mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateProduct([FromBody] AddProduct addProduct)
        {
            if (ModelState.IsValid)
            {
                var productDomain = mapper.Map<Product>(addProduct);
                productDomain = await productRepository.CreateAsync(productDomain);
                var productDto = mapper.Map<ProductDto>(productDomain);
                return CreatedAtAction("GetById", new { id = productDto.Id }, productDto);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            var productDomain = mapper.Map<Product>(updateProductDto);
            productDomain = await productRepository.UpdateAsync(id, productDomain);
            if (productDomain == null) return NotFound("Not found");
            var categoryDto = mapper.Map<ProductDto>(productDomain);
            return Ok(categoryDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            var productDomain = await productRepository.DeleteAsync(id);
            if (productDomain == null) return NotFound("Not found");
            return Ok(mapper.Map<ProductDto>(productDomain));
        }
    }
}
