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
    public class NewMoviesVM
    {
        public int Id { get; set; }

        [Display(Name = "Movie name")]
        [Required(ErrorMessage = "Movie Name is required!")]
        public string name { get; set; }

        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "Movie description is required!")]
        public string description { get; set; }

        [Display(Name = "Movie start date")]
        [Required(ErrorMessage = "Movie start date is required!")]
        public DateTime startDate { get; set; }

        [Display(Name = "Movie end date")]
        [Required(ErrorMessage = "Movie end date is required!")]
        public DateTime endDate { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Movie price is required!")]
        public double price { get; set; }

        //enum MovieCategory
        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required!")]
        public MovieCategory movieCategory { get; set; }

        [Display(Name = "Movie poster URL")]
        [Required(ErrorMessage = "Movie poster URL is required!")]
        public string imageURL { get; set; }

        //Relationships
        [Display(Name = "Select an actor/s")]
        [Required(ErrorMessage = "Movie actor/s is required!")]
        public List<int> actorIds { get; set; }

        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "Movie cenima is required!")]
        public int cinemaId { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Movie producer is required!")]
        public int producerId { get; set; }
      

    }
}