using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Repository
{
    public interface IUser
    {
        //public string SaveUserDetails(UserDetails userDetails);
        //public string UpdateUserDetails(UserDetails userDetails);
        ////public string DeleteUserDetails(int UserId);
        //UserDetails GetUserDetails(int UserId);
        //List<UserDetails> GetAllUserDetails();
        //UserDetails GetUserbyEmail(string EmailId);


        Task<IEnumerable<UserDetails>> GetAllUsers();
        Task<UserDetails> GetUser(int UserId);
        Task<UserDetails> RegisterUser(UserDetails User);
        Task<UserDetails> UpdateUserDetails(UserDetails User);
        //void DeleteUser(int UserId);
    }
}