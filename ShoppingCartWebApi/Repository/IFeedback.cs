using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Models;
namespace ShoppingCartWebApi.Repository
{
    public interface IFeedback
    {
        //public string SaveFeedDetails(feedback feedback);
        //feedback GetFeedDetails(int UserId);
        //List<feedback> GetAllFeedDetails();

        Task<IEnumerable<feedback>> GetAllFeedbackDetails();
        Task<feedback> GetFeedBackDetails(int UserId);
        Task<feedback> SaveFeedbackDetails(feedback feedback);
    }
}