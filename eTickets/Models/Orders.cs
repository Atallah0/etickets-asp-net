using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        public string email { get; set; }

        public string userId { get; set; }
        [ForeignKey(nameof(userId))]
        public ApplicationUser user { get; set; }

        //Relationships
        public List<OrdersItems> ordersItems { get; set; }
    }
}
