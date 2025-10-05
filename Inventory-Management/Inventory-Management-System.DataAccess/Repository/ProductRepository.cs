using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.DataAccess.IRepository;
using Inventory_Management_System.DbConntext.Data;
using Inventory_Management_System.DomainModel.DTO;
using Inventory_Management_System.DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ProductDbContext context;
        public ProductRepository(ProductDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                await context.AddAsync(product);
                await context.SaveChangesAsync();
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>List<Product></returns>
        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var result = await context.Products.ToListAsync();
                return result;
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
        /// <returns>Product</returns>
        public async Task<Product> GetProduct(int productId)
        {
            try
            {
                var product = await context.Products.FindAsync(productId);
                if (product == null)
                    throw new KeyNotFoundException($"Product with ID {productId} not found");
                return product;
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
        /// <returns>Deleted Product</returns>
        public async Task<Product> DeleteProduct(int productId)
        {
            try
            {
                var p = await context.Products.FindAsync(productId);
                if (p == null)
                {
                    throw new Exception("Product not found");
                }
                context.Products.Remove(p);
                await context.SaveChangesAsync();
                return p;
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
        /// <returns>Updated Product</returns>
        public async Task<Product> IncreaseProductStock(int productId, int stock)
        {
            try
            {
                if (productId <= 0)
                    throw new ArgumentException("Invalid product ID");

                if (stock <= 0)
                    throw new ArgumentException("Stock to increase must be greater than zero"); // BadRequest
                var product = context.Products.Find(productId);

                if (product == null)
                    throw new KeyNotFoundException($"Product with ID {productId} not found");

                product.StockQuantity += stock;
                context.SaveChanges();
                return product;
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
        /// <returns>Updated Product</returns>
        public async Task<Product> DecreaseProductStock(int productId, int stock)
        {
            try
            {
                var product = context.Products.Find(productId);
                if (product == null)
                    throw new KeyNotFoundException($"Product with ID {productId} not found"); // NotFound

                if (product.StockQuantity < stock)
                    throw new InvalidOperationException("Insufficient stock to decrease"); // BadRequest

                product.StockQuantity -= stock;
                context.SaveChanges();
                return product;
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
        /// <returns>Updated Product</returns>
        public async Task<Product> UpdateProduct(Product product,int productId)
        {
            try
            {
                var p = await context.Products.FindAsync(productId);
                if (p == null)
                {
                    throw new Exception("Product not found");
                }
                p.Name = product.Name;
                p.Description = product.Description;
                p.StockQuantity = product.StockQuantity;
                p.LowStockThreshold = product.LowStockThreshold;
                await context.SaveChangesAsync();
                return p;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get Low Stock Products
        /// </summary>
        /// <returns>List<Product></returns>
        public async Task<List<Product>> GetLowStockProducts()
        {
            try
            {
                var lowStockProducts = await context.Products
                    .Where(p => p.StockQuantity < p.LowStockThreshold)
                    .ToListAsync();
                return lowStockProducts;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
