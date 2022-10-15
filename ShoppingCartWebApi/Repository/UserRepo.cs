using ShoppingCartWebApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ShoppingCartWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCartWebApi.Repository
{
    public class UserRepo : IUser
    {
        private readonly ShoppingCartDbContext _shoppingCartDbContext;
        #region UserRepo
        /// <summary>
        /// UserRepo Constuctor
        /// </summary>
        /// <param name="ShoppingCartDb"></param>
        public UserRepo(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }
        #endregion

        #region GetAllUsers
        /// <summary>
        /// Method to getallusers
        /// </summary>
       
        public async Task<IEnumerable<UserDetails>> GetAllUsers()
        {
            return await _shoppingCartDbContext.UserDetails.ToListAsync();
        }
        #endregion

        #region GetUser
        /// <summary>
        /// Method to get user by Id
        /// </summary>
        /// <param name="UserId"></param>
       
        public async Task<UserDetails> GetUser(int UserId)
        {
            return await _shoppingCartDbContext.UserDetails
                .FirstOrDefaultAsync(u => u.UserId == UserId);
        }
        #endregion

        #region RegisterUser
        /// <summary>
        /// Method to get userdetails
        /// </summary>
        /// <param name="User"></param>
        
        public async Task<UserDetails> RegisterUser(UserDetails User)
        {
            var result = await _shoppingCartDbContext.UserDetails.AddAsync(User);
            await _shoppingCartDbContext.SaveChangesAsync();
            return result.Entity;
        }
        #endregion

        #region UpdateUserDetails
        /// <summary>
        /// Method to update User details
        /// </summary>
        /// <param name="User"></param>
       
        public async Task<UserDetails> UpdateUserDetails(UserDetails User)
        {
            var result = await _shoppingCartDbContext.UserDetails
                .FirstOrDefaultAsync(u => u.UserId == User.UserId);

            if (result != null)
            {
                result.UserId = User.UserId;
                result.Role = User.Role;
                result.FirstName = User.FirstName;
                result.LastName = User.LastName;
                result.EmailId = User.EmailId;
                result.MobileNumber = User.MobileNumber;
                result.AddressInfo = User.AddressInfo;
                result.City = User.UserState;
                result.Pincode = User.Pincode;
                result.Password = User.Password;
                result.IsLogin = User.IsLogin;

                await _shoppingCartDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
        #endregion 
    }
}