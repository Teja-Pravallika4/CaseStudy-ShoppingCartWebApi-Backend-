using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Repository
{
    public interface IOrder
    {
        //public string SaveOrderDetails(Order orderDetails);
        //Order GetOrderDetails(int OrderId);
        //List<Order> GetAllOrderDetails();


        Task<IEnumerable<Order>> GetOrder();
        Task<Order> GetOrder(int UserId);
        Task<Order> AddOrder(Order Order);

        //void DeleteOrder(int Order);
    }
}