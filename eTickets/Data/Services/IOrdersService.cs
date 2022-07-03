using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItems> items, string userId, string userEmailAddress);
        Task<List<Orders>> GetOrderByUserIdAndRoleAsync(string userId, string userRole);
    }
}
