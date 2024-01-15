using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopbackAPI.CustomActionFilter;
using shopbackAPI.Data;
using shopbackAPI.Models.Domain;
using shopbackAPI.Models.DTOs;
using shopbackAPI.Repositories;

namespace shopbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ShopBackDbContext dbContext;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoriesController(ShopBackDbContext dbContext,ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var categories = await categoryRepository.GetAllAsync();
            var categoriesDto = mapper.Map<List<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if(category == null)
            {
                return NotFound("Not found");
            }
            return Ok(mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateCategory([FromBody]AddCategory addCategory)
        {
            if (ModelState.IsValid)
            {
                var categoryDomain = mapper.Map<ProductCategory>(addCategory);
                categoryDomain = await categoryRepository.CreateAsync(categoryDomain);
                var categoryDto = mapper.Map<CategoryDto>(categoryDomain);
                return CreatedAtAction("GetById",new {id = categoryDto.Id},categoryDto);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var categoryDomain = mapper.Map<ProductCategory>(updateCategoryDto);
            categoryDomain = await categoryRepository.UpdateAsync(id, categoryDomain);
            if (categoryDomain == null) return NotFound("Not found");
            var categoryDto = mapper.Map<CategoryDto> (categoryDomain);
            return Ok(categoryDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var categoryDomain = await categoryRepository.DeleteAsync(id);
            if (categoryDomain == null) return NotFound("Not found");
            return Ok(mapper.Map<CategoryDto>(categoryDomain));
        }
    }
}
