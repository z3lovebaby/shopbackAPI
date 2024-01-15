using System.ComponentModel.DataAnnotations;

namespace shopbackAPI.Models.DTOs
{
    public class UpdateCategoryDto
    {
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
