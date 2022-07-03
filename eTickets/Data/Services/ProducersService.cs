using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producers>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {

        }
    }
}
