using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actors_Movies
    {
        [ForeignKey("actorId")]
        public int actorId { get; set; }
        public Actors actors { get; set; }

        [ForeignKey("movieId")]
        public int movieId { get; set; }
        public Movies movies { get; set; }
    }
}