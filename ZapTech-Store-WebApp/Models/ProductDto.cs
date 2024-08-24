using System.ComponentModel.DataAnnotations;

namespace ZapTech_Store_WebApp.Models
{
    public class ProductDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        [Required, MaxLength(100)]
        public string Brand { get; set; } = "";

        [Required, MaxLength(100)]
        public string Category { get; set; } = "";

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; } = "";

        public IFormFile? ImageFile { get; set; }

        // Add the following properties for editing scenarios
        public string? ImageFileName { get; set; } // Existing image filename
        public DateTime CreatedAt { get; set; } // Date product was created
    }
}
