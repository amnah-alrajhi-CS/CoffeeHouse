using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeHouse.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(
            100,
            MinimumLength = 2,
            ErrorMessage = "Product name must be between 2 and 100 characters."
        )]
        [Display(Name = "Product Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(
            1,
            1000,
            ErrorMessage = "Price must be between 1 and 1000 SAR."
        )]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [StringLength(
            500,
            ErrorMessage = "Description cannot exceed 500 characters."
        )]
        public string? Description { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        [NotMapped]
        [Display(Name = "Upload Image")]
        public IFormFile? ImageFile { get; set; }
    }
}