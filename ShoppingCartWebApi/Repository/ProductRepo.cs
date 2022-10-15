using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShoppingCartWebApi.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly ShoppingCartDbContext _ShoppingCartDb;
        #region ProductRepo
        /// <summary>
        /// ProductRepo Constuctor
        /// </summary>
        /// <param name="ShoppingCartDb"></param>
        public ProductRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }

        #endregion

        #region AddProduct
        /// <summary>
        /// Method to save the product details
        /// </summary>
        /// <param name="Product"></param>
        public async Task<Product> AddProduct(Product product)
        {
            var result = await _ShoppingCartDb.Product.AddAsync(product);
            await _ShoppingCartDb.SaveChangesAsync();
            return result.Entity;
        }
        #endregion

        #region GetAllProduct
        /// <summary>
        /// Method to get all the product
        /// </summary>
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _ShoppingCartDb.Product.ToListAsync();
        }
        #endregion

        #region GetProduct
        /// <summary>
        /// Method to get product by id
        /// </summary>
        /// <param name="ProductId"></param>
        public async Task<Product> GetProduct(int ProductId)
        {
            return await _ShoppingCartDb.Product.FirstOrDefaultAsync(p => p.ProductId == ProductId);
        }
        #endregion

        #region Search
        /// <summary>
        /// Method to search products by productname
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> Search(string ProductName)
        {
            IQueryable<Product> query = _ShoppingCartDb.Product;
            if (!string.IsNullOrEmpty(ProductName))
            {
                query = query.Where(x => x.ProductName.Contains(ProductName));
            }
            return await query.ToListAsync();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Method to delete products by productname
        /// </summary>
        /// <param name="ProductName"></param>
       
        public async void DeleteProduct(int ProductId)
        {
            var result = await _ShoppingCartDb.Product
                .FirstOrDefaultAsync(p => p.ProductId == ProductId);
            if (result != null)
            {
                _ShoppingCartDb.Product.Remove(result);
                await _ShoppingCartDb.SaveChangesAsync();
            }
        }
        #endregion

        #region UpdateProduct
        /// <summary>
        /// Method to update products by productname
        /// </summary>
        /// <param name="product"></param>
        /// <param name="id"></param>

        public async Task UpdateProduct(Product product, int id)
        {
            //var result = await _ShoppingCartDb.Product.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);
            var result = await _ShoppingCartDb.Product.FindAsync(id);
            if (result != null)
            {
                result.Category = product.Category;
                result.ProductName = product.ProductName;
                result.Price = product.Price;
                result.Description = product.Description;
                result.ProductImage = product.ProductImage;



                await _ShoppingCartDb.SaveChangesAsync();




            }
        }
        #endregion



    }
    }