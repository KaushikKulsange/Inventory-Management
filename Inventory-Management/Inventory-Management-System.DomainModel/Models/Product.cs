using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.DomainModel.Models
{
    public class Product
    {
        [Key] // Primary key
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public int LowStockThreshold { get; set; }
    }
}
