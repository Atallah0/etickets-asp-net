using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Cinemas : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema logo")]
        [Required(ErrorMessage = "Cinema logo is required!")]
        public string cinemaLogo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required!")]
        public string name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema description is required!")]
        public string description { get; set; }

        //Relationships
        public List<Movies> movies { get; set; }
    }
}