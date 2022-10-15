using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Models;
namespace ShoppingCartWebApi.Repository
{
    public class CartRepo : ICart
    {
        //private readonly ShoppingCartDbContext _ShoppingCartDbContext;

        //public CartRepo(ShoppingCartDbContext ShoppingCartDb)
        //{
        //    _ShoppingCartDbContext = ShoppingCartDb;
        //}

        //public async Task<IEnumerable<Cart>> GetAllCart()
        //{
        //    return await _ShoppingCartDbContext.Cart.ToListAsync();
        //}

        //public async Task<Cart> GetCart(int cartId)
        //{
        //    return await _ShoppingCartDbContext.Cart
        //        .FirstOrDefaultAsync(e => e.CartId == cartId);
        //}
        //public async Task<Cart> GetCartByUserID(int userId)
        //{
        //    return await _ShoppingCartDbContext.Cart
        //        .FirstOrDefaultAsync(e => e.UserId == userId);
        //}

        //public async Task<Cart> AddCart(Cart cart)
        //{
        //    var result = await _ShoppingCartDbContext.Cart.AddAsync(cart);
        //    await _ShoppingCartDbContext.SaveChangesAsync();

        //    return result.Entity;

        //}

        //public async Task<Cart> UpdateCart(Cart cart)
        //{
        //    var result = await _ShoppingCartDbContext.Cart
        //        .FirstOrDefaultAsync(e => e.CartId == cart.CartId);

        //    if (result != null)
        //    {
        //        result.CartId = cart.CartId;
        //        result.UserId = cart.UserId;
        //        result.ProductId = cart.ProductId;
        //        result.Quantity = cart.Quantity;
        //        result.Price = cart.Price;



        //        await _ShoppingCartDbContext.SaveChangesAsync();

        //        return result;
        //    }

        //    return null;
        //}

        //public async void DeleteCart(int cartId)
        //{
        //    var result = await _ShoppingCartDbContext.Cart
        //        .FirstOrDefaultAsync(e => e.CartId == cartId);
        //    if (result != null)
        //    {
        //        _ShoppingCartDbContext.Cart.Remove(result);
        //        await _ShoppingCartDbContext.SaveChangesAsync();

        private readonly ShoppingCartDbContext _ShoppingCartDbContext;

        #region CartRepo
        /// <summary>
        /// CartRepo Constructor
        /// </summary>
        /// <param name="ShoppingCartDb"></param>
        public CartRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDbContext = ShoppingCartDb;
        }
        #endregion

        #region GetAllCart
        /// <summary>
        /// Method to get all cart
        /// </summary>
        public async Task<IEnumerable<Cart>> GetAllCart()
        {
            return await _ShoppingCartDbContext.Cart.ToListAsync();
        }
        #endregion

        #region GetCart
        /// <summary>
        /// Method to get cart by Id
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public async Task<Cart> GetCart(int cartId)
        {
            return await _ShoppingCartDbContext.Cart
                .FirstOrDefaultAsync(e => e.CartId == cartId);
        }
        #endregion

        #region AddCart
        /// <summary>
        /// Method to add to cart
        /// </summary>
        /// <param name="cart"></param>

        public async Task<Cart> AddCart(Cart cart)
        {
            var result = await _ShoppingCartDbContext.Cart.AddAsync(cart);
            await _ShoppingCartDbContext.SaveChangesAsync();

            return result.Entity;

        }
        #endregion

        #region UpdateCart
        /// <summary>
        /// Method to update cart by Id
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public async Task<Cart> UpdateCart(Cart cart)
        {
            var result = await _ShoppingCartDbContext.Cart
                .FirstOrDefaultAsync(e => e.CartId == cart.CartId);

            if (result != null)
            {
                result.CartId = cart.CartId;

                result.ProductId = cart.ProductId;
                result.Quantity = cart.Quantity;
                result.Price = cart.Price;



                await _ShoppingCartDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
        #endregion

        #region DeleteCart 
        /// <summary>
        /// Method to delete cart by Id
        /// </summary>
        /// <param name="cartId"></param>
        public async void DeleteCart(int cartId)
        {
            var result = await _ShoppingCartDbContext.Cart
                .FirstOrDefaultAsync(e => e.CartId == cartId);
            if (result != null)
            {
                _ShoppingCartDbContext.Cart.Remove(result);
                await _ShoppingCartDbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}