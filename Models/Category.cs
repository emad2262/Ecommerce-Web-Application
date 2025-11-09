using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Web_Application.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        public bool Status { get; set; }

        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
