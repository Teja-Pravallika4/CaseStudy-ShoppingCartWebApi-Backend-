using Microsoft.EntityFrameworkCore;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Repository
{
    public class OrderRepo : IOrder
    {
       
        private readonly ShoppingCartDbContext _shoppingCartDbContext;
        #region OrderRepo
        /// <summary>
        /// Order Constuctor
        /// </summary>
        /// <param name="ShoppingCartDb"></param>
        public OrderRepo(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }
        #endregion


        #region GetOrder
        /// <summary>
        /// Method to get order details
        /// </summary>
       
        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await _shoppingCartDbContext.Order.ToListAsync();
        }
        #endregion

        #region GetOrder 
        /// <summary>
        /// Method to get order by Id
        /// </summary>
        /// <param name="OrderId"></param>
        
        public async Task<Order> GetOrder(int OrderId)
        {
            return await _shoppingCartDbContext.Order
                .FirstOrDefaultAsync(e => e.OrderId == OrderId);
        }
        #endregion

        #region AddOrder
        /// <summary>
        /// Method to add order
        /// </summary>
        /// <param name="Order"></param>
        
        public async Task<Order> AddOrder(Order Order)
        {
            var result = await _shoppingCartDbContext.Order.AddAsync(Order);
            await _shoppingCartDbContext.SaveChangesAsync();
            return result.Entity;
        }
        #endregion

    }
}