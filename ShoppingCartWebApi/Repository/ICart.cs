using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Repository
{
    public interface ICart
    {
        //public string SaveCart(Cart cart);
        //public string UpdateCart(Cart cart);
        //public string DeleteCart(int CartId);
        //Cart GetCart(int CartId);
        //List<Cart> GetAllCart();
        //public IEnumerable<Cart> GetCartByUserID(int UserId);
        //public int GetCartId(int UserId);

        //Task<IEnumerable<Cart>> GetAllCart();
        //Task<Cart> GetCartByUserID(int UserId);
        //Task<Cart> AddCart(Cart cart);
        //Task<Cart> UpdateCart(Cart cart);
        //void DeleteCart(int CartId);
        //Task<Cart> GetCart(int CartId);

        Task<IEnumerable<Cart>> GetAllCart();

        Task<Cart> AddCart(Cart cart);
        Task<Cart> UpdateCart(Cart cart);
        void DeleteCart(int CartId);
        Task<Cart> GetCart(int CartId);

    }

}