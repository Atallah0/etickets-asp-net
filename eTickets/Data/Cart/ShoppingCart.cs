using eTickets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string shoppingCartId { get; set; }
        public List<ShoppingCartItems> shoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { shoppingCartId = cartId };
        }

        public void AddItemToCart(Movies movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.movies.Id == movie.Id &&
            n.shoppingCartId == shoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItems()
                {
                    shoppingCartId = shoppingCartId,
                    movies = movie,
                    amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Movies movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.movies.Id == movie.Id &&
            n.shoppingCartId == shoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.amount > 1)
                {
                    shoppingCartItem.amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);

                }
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItems> GetShoppingCartItems()
        {
            return shoppingCartItems ?? (shoppingCartItems = _context.ShoppingCartItems.Where(n => n.shoppingCartId ==
            shoppingCartId).Include(n => n.movies).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.shoppingCartId ==
        shoppingCartId).Select(n => n.movies.price * n.amount).Sum();

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.shoppingCartId == shoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
