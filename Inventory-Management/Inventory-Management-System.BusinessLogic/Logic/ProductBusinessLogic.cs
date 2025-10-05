
using AutoMapper;
using Inventory_Management_System.BusinessLogic.ILogic;
using Inventory_Management_System.DataAccess.IRepository;
using Inventory_Management_System.DomainModel.DTO;
using Inventory_Management_System.DomainModel.Models;

namespace Inventory_Management_System.BusinessLogic.Logic
{
    public class ProductBusinessLogic : IProductBusinessLogic
    {
        private IMapper mapper;
        private IProductRepository repository;
        public ProductBusinessLogic(IMapper mapper,IProductRepository repository) 
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Added ProductDto</returns>
        public async Task<ProductDto> AddProduct(AddUpdateProductDTO product)
        {
            try
            {
                var prd = mapper.Map<Product>(product);
                var result = await this.repository.AddProduct(prd);
                return mapper.Map<ProductDto>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Decrease Stock of Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="stock"></param>
        /// <returns>Updated ProductDto</returns>
        public async Task<ProductDto> DecreaseProductStock(int productId, int stock)
        {
            try
            {
                var result =await this.repository.DecreaseProductStock(productId, stock);
                var prd = mapper.Map<ProductDto>(result);
                return prd;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Deleted ProductDto</returns>
        public async Task<ProductDto> DeleteProduct(int productId)
        {
            try
            {
                var result = await this.repository.DeleteProduct(productId);
                var prd = mapper.Map<ProductDto>(result);
                return prd;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>List<ProductDto></ProductDTO></returns>
        public async Task<List<ProductDto>> GetAllProducts()
        {
            try
            {
                var result = await this.repository.GetAllProducts();
                var resultDTO = mapper.Map<List<ProductDto>>(result);
                return resultDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>ProductDto</returns>
        public async Task<ProductDto> GetProduct(int productId)
        {
            try
            {
                var result = await this.repository.GetProduct(productId);
                var prd = mapper.Map<ProductDto>(result);
                return prd;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Increase Stock of Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="stock"></param>
        /// <returns>Updated ProductDto</returns>
        public async Task<ProductDto> IncreaseProductStock(int productId, int stock)
        {
            try
            {
                var result = await this.repository.IncreaseProductStock(productId, stock);
                var prd = mapper.Map<ProductDto>(result);
                return prd;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productId"></param>
        /// <returns>Updated ProductDto</returns>
        public async Task<ProductDto> UpdateProduct(AddUpdateProductDTO product,int productId)
        {
            try
            {
                var prd = mapper.Map<Product>(product);
                var result = await this.repository.UpdateProduct(prd, productId);
                return mapper.Map<ProductDto>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>List<ProductDto></ProductDTO></returns>
        public async Task<List<ProductDto>> GetLowStockProducts()
        {
            try
            {
                var result = await this.repository.GetLowStockProducts();
                var resultDTO = mapper.Map<List<ProductDto>>(result);
                return resultDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
