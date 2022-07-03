using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Orders>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.ordersItems).ThenInclude(n => n.movies).Include(n =>
            n.user).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.userId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItems> items, string userId, string userEmailAddress)
        {
            var order = new Orders()
            {
                userId = userId,
                email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrdersItems()
                {
                    amount = item.amount,
                    movieId = item.movies.Id,
                    ordreId = order.Id,
                    price = item.movies.price
                };
                await _context.OrdersItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
