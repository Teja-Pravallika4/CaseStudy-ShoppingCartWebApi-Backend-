
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Repository;

namespace ShoppingCartWebApi.Models
{
    public class PaymentRepo : IPayment
    {
       
        private readonly ShoppingCartDbContext _ShoppingCartDb;
        #region PaymentRepo
        /// <summary>
        /// PaymentRepo Constuctor
        /// </summary>
        /// <param name="ShoppingCartDb"></param>
        public PaymentRepo(ShoppingCartDbContext shoppingCartDbContext)
        {
            _ShoppingCartDb = shoppingCartDbContext;
        }
        #endregion

        #region GetAllTransaction
        /// <summary>
        /// Method to get all transaction
        /// </summary>
        
        public async Task<IEnumerable<Payment>> GetAllTransaction()
        {
            return await _ShoppingCartDb.Payment.ToListAsync();
        }
        #endregion

        #region GetTransaction
        /// <summary>
        /// Method to get transaction
        /// </summary>
        /// <param name="TransactionId"></param>
        
        public async Task<Payment> GetTransaction(int TransactionId)
        {
            return await _ShoppingCartDb.Payment
                .FirstOrDefaultAsync(e => e.TransactionId == TransactionId);
        }
        #endregion

        #region SaveTransaction
        /// <summary>
        /// Method to save transaction
        /// </summary>
        /// <param name="payment"></param>
       
        public async Task<Payment> SaveTransaction(Payment payment)
        {
            var result = await _ShoppingCartDb.Payment.AddAsync(payment);
            await _ShoppingCartDb.SaveChangesAsync();
            return result.Entity;

        }
        #endregion
    }
}



            

            