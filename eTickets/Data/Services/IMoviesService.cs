using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movies>
    {
        Task<Movies> GetMovieByIdAsync(int id);

        Task<NewMoviesDropdownsVM> GetNewMoviesDropdownsValues();

        Task AddNewMovieAsync(NewMoviesVM data);

        Task UpdateMovieAsync(NewMoviesVM data);


    }
}
