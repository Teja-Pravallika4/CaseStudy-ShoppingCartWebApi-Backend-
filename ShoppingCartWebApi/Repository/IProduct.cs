using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Repository
{
    public interface IProduct
    {
        //public string SaveProduct(Product Product);
        //public string UpdateProduct(Product Product);
        //public string DeleteProduct(int ProductId);
        //Product GetProduct(int ProductId);
        //List<Product> GetAllProduct();

        //Task<IEnumerable<Product>> Search(string ProductName);

        Task<Product> AddProduct(Product product);
        //Task<Product> UpdateProduct(Product product);

        Task UpdateProduct(Product product, int id);
        Task<Product> GetProduct(int ProductId);
        void DeleteProduct(int ProductId);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> Search(string name);


    }
}