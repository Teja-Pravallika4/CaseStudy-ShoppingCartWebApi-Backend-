using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Repository
{
    public interface IPayment
    {
        //public string SaveTransaction(Payment Payment);
        //Payment GetTransaction(int TransactionId);
        //List<Payment> GetAllTransaction();

        Task<IEnumerable<Payment>> GetAllTransaction();
        Task<Payment> GetTransaction(int TransactionId);
        Task<Payment> SaveTransaction(Payment payment);

    }
}