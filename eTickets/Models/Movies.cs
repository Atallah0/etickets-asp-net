using eTickets.Data;
using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Movies : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double price { get; set; }

        //enum MovieCategory
        public MovieCategory movieCategory { get; set; }

        [Display(Name = "Image")]
        public string imageURL { get; set; }

        //Relationships
        public List<Actors_Movies> actors_Movies { get; set; }

        //Cinemas
        public int cinemaId { get; set; }
        [ForeignKey("cinemaId")]
        public Cinemas cinemas { get; set; }

        //Producers
        public int producerId { get; set; }
        [ForeignKey("producerId")]
        public Producers producers { get; set; }

    }
}