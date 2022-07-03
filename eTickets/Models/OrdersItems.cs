using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class OrdersItems
    {
        [Key]
        public int Id { get; set; }

        public int amount { get; set; }
        public double price { get; set; }

        //Relationships
        //Movies
        public int movieId { get; set; }
        [ForeignKey("movieId")]
        public Movies movies { get; set; }

        //Orders
        public int ordreId { get; set; }
        [ForeignKey("ordreId")]
        public Orders orders { get; set; }
    }
}
