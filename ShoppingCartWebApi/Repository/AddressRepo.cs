using Microsoft.EntityFrameworkCore;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Repository
{
    public class AddressRepo : IAddress
    {
        private readonly ShoppingCartDbContext _ShoppingCartDb;
        #region AddressRepo
        /// <summary>
        /// AddressRepo Constuctor
        /// </summary>
        /// <param name="ShoppingCartDb"></param>
        public AddressRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        #endregion

        #region GetAllAddress
        /// <summary>
        /// Method to Get all the Address
        /// </summary>
        /// <param name="Product"></param>

        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            return await _ShoppingCartDb.Address.ToListAsync();
        }
        #endregion

        #region GetAddress
        /// <summary>
        /// Method to Get Address by Id
        /// </summary>
        /// <param name="AddressId"></param>
        
        public async Task<Address> GetAddress(int AddressId)
        {
            return await _ShoppingCartDb.Address
                .FirstOrDefaultAsync(e => e.AddressId == AddressId);
        }
        #endregion

        #region SaveAddress
        /// <summary>
        /// Method to SaveAddress by address
        /// </summary>
        /// <param name="address"></param>
        
        public async Task<Address> SaveAddress(Address address)
        {
            var result = await _ShoppingCartDb.Address.AddAsync(address);
            await _ShoppingCartDb.SaveChangesAsync();
            return result.Entity;
        }
        #endregion

        #region UpdateAddress
        /// <summary>
        /// Method to UpdateAddress by AddressId
        /// </summary>
        /// <param name="Address"></param>
        
        public async Task<Address> UpdateAddress(Address Address)
        {
            var result = await _ShoppingCartDb.Address
                .FirstOrDefaultAsync(e => e.AddressId == Address.AddressId);

            if (result != null)
            {

                await _ShoppingCartDb.SaveChangesAsync();

                return result;
            }

            return null;
        }
        #endregion

        #region DeleteAddress
        /// <summary>
        /// Method to delete address by Id
        /// </summary>
        /// <param name="AddressId"></param>
        public async void DeleteAddress(int AddressId)
        {
            var result = await _ShoppingCartDb.Address
                .FirstOrDefaultAsync(e => e.AddressId == AddressId);
            if (result != null)
            {
                _ShoppingCartDb.Address.Remove(result);
                await _ShoppingCartDb.SaveChangesAsync();
            }
        }
        #endregion

        Task<IEnumerable<Address>> IAddress.GetAllAddress()
        {
            throw new System.NotImplementedException();
        }

        Task<Address> IAddress.GetAddress(int UserId)
        {
            throw new System.NotImplementedException();
        }

        Task<Address> IAddress.SaveAddress(Address address)
        {
            throw new System.NotImplementedException();
        }

        Task<Address> IAddress.UpdateAddress(Address address)
        {
            throw new System.NotImplementedException();
        }
       
    }
}