using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class ShoppingCartItems
    {
        [Key]
        public int Id { get; set; }

        public Movies movies { get; set; }
        public int amount { get; set; }

        public string shoppingCartId { get; set; }
    }
}
