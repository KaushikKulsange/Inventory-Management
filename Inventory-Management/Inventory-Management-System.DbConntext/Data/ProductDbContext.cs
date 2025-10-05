using Inventory_Management_System.DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.DbConntext.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
