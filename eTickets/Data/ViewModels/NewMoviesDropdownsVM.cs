using eTickets.Models;
using System.Collections.Generic;

namespace eTickets.Data.ViewModels
{
    public class NewMoviesDropdownsVM
    {
        public NewMoviesDropdownsVM()
        {
            Producers = new List<Producers>();
            Cinemas = new List<Cinemas>();
            Actors = new List<Actors>();
        }

        public List<Producers> Producers { get; set; }
        public List<Cinemas> Cinemas { get; set; }
        public List<Actors> Actors { get; set; }
    }
}
