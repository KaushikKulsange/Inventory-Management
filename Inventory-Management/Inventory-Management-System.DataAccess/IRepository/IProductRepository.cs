using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.DomainModel.DTO;
using Inventory_Management_System.DomainModel.Models;

namespace Inventory_Management_System.DataAccess.IRepository
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product, int productId);
        Task<Product> DeleteProduct(int productId);
        Task<Product> GetProduct(int productId);
        Task<List<Product>> GetAllProducts();

        Task<Product> IncreaseProductStock(int productId, int stock);
        Task<Product> DecreaseProductStock(int productId, int stock);
        Task<List<Product>> GetLowStockProducts();
    }
}
