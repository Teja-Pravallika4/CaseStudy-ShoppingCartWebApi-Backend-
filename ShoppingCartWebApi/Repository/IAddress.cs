using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Models

{
    public interface IAddress
    {
        //public string SaveAddress(Address Address);
        //public string UpdateAddress(Address Address);
        //public string DeleteAddress(int AddressId);
        //Address GetAddress(int AddressId);

        //Address GetUserAddress(int UserId);
        //List<Address> GetAllAddress();

        Task<IEnumerable<Address>> GetAllAddress();
        Task<Address> GetAddress(int AddressId);
       /* Task<Address> GetUserAddress(int UserId)*/
        Task<Address> SaveAddress(Address address);
        Task<Address> UpdateAddress(Address address);
        void DeleteAddress(int AddressId);


    }



}