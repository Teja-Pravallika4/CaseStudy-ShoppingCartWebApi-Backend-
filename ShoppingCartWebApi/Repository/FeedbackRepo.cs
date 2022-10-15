using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Repository;

namespace ShoppingCartWebApi.Models
{
    public class FeedbackRepo : IFeedback
    {
       
        private readonly ShoppingCartDbContext _ShoppingCartDb;
        #region FeedbackRepo
        /// <summary>
        /// Feedback Constuctor
        /// </summary>
        /// <param name="ShoppingCartDb"></param>
        public FeedbackRepo(ShoppingCartDbContext shoppingCartDbContext)
        {
            _ShoppingCartDb = shoppingCartDbContext;
        }
        #endregion

        #region GetAllFeedbackDetails
        /// <summary>
        /// Method to get all feedback details
        /// </summary>
       
        public async Task<IEnumerable<feedback>> GetAllFeedbackDetails()
        {
            return await _ShoppingCartDb.feedback.ToListAsync();
        }
        #endregion

        #region GetFeedbackDetails
        /// <summary>
        /// Method to get feedback details by Username
        /// </summary>
        /// <param name="Username"></param>
       
        public async Task<feedback> GetFeedbackDetails(string Username)
        {
            return await _ShoppingCartDb.feedback
                .FirstOrDefaultAsync(e => e.Username == Username);
        }
        #endregion

        #region GetFeedBackDetails
        /// <summary>
        /// Method to get feedback details by UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<feedback> GetFeedBackDetails(int UserId)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region SaveFeedbackDetails
        /// <summary>
        /// Method to save feedback details
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        public async Task<feedback> SaveFeedbackDetails(feedback feedback)
        {
            var result = await _ShoppingCartDb.feedback.AddAsync(feedback);
            await _ShoppingCartDb.SaveChangesAsync();
            return result.Entity;
        }
        #endregion
    }
}

 