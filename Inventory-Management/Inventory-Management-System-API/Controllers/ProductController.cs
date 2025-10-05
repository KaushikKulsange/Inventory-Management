using Inventory_Management_System.BusinessLogic.ILogic;
using Inventory_Management_System.DomainModel.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBusinessLogic domainLogic;
        public ProductController(IProductBusinessLogic domainLogic) 
        { 
            this.domainLogic = domainLogic;
        }


        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>ProductDto</returns>
        [HttpGet("GetProduct/{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            try
            {
                var result  = await this.domainLogic.GetProduct(productId);
                return Ok(result);
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
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var result = await this.domainLogic.GetAllProducts();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Added ProductDto</returns>
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddUpdateProductDTO product)
        {
            try
            {
                var result = await this.domainLogic.AddProduct(product);
                return CreatedAtAction(nameof(AddProduct),result);
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
        [HttpPut("UpdateProduct/{productId}")]
        public async Task<IActionResult> UpdateProduct(AddUpdateProductDTO product,int productId)
        {
            try
            {
                var result = await this.domainLogic.UpdateProduct(product, productId);
                return NoContent();
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
        [HttpDelete("DeleteProduct/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var result = await this.domainLogic.DeleteProduct(productId);
                return Ok(result);
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
        [HttpPut("AddStock/{productId}/{stock}")]
        public async Task<IActionResult> IncreaseStock(string productId,int stock)
        {
            try
            {
                var result = await this.domainLogic.IncreaseProductStock(int.Parse(productId), stock);
                return NoContent();
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
        [HttpPut("ReduceStock/{productId}/{stock}")]
        public async Task<IActionResult> DecreaseStock(string productId, int stock)
        {
            try
            {
                var result = await this.domainLogic.DecreaseProductStock(int.Parse(productId), stock);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Get Low Stock Products
        /// </summary>
        /// <returns>List<ProductDto></ProductDto></returns>
        [HttpGet("LowStockProducts")]
        public async Task<IActionResult> GetLowStockProducts()
        {
            try
            {
                var result = await this.domainLogic.GetLowStockProducts();
                if (result == null || result.Count == 0)
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
