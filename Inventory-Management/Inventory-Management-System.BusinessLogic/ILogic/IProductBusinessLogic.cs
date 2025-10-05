using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.DomainModel.DTO;

namespace Inventory_Management_System.BusinessLogic.ILogic
{
    public interface IProductBusinessLogic
    {
        Task<ProductDto> AddProduct(AddUpdateProductDTO product);
        public Task<ProductDto> UpdateProduct(AddUpdateProductDTO product, int productId);
        public Task<ProductDto> DeleteProduct(int ProductId);
        public Task<ProductDto> GetProduct(int productId);
        public Task<List<ProductDto>> GetAllProducts();
        public Task<ProductDto> IncreaseProductStock(int productId,int stock);
        public Task<ProductDto> DecreaseProductStock(int productId,int stock);
        Task<List<ProductDto>> GetLowStockProducts();
    }
}
