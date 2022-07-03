using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movies>, IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMoviesVM data)
        {
            var newMovie = new Movies()
            {
                name = data.name,
                description = data.description,
                price = data.price,
                imageURL = data.imageURL,
                cinemaId = data.cinemaId,
                startDate = data.startDate,
                endDate = data.endDate,
                movieCategory = data.movieCategory,
                producerId = data.producerId,
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.actorIds)
            {
                var newActorMovie = new Actors_Movies()
                {
                    movieId = newMovie.Id,
                    actorId = actorId,
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movies> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.cinemas)
                .Include(p => p.producers)
                .Include(am => am.actors_Movies).ThenInclude(a => a.actors)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMoviesDropdownsVM> GetNewMoviesDropdownsValues()
        {
            var response = new NewMoviesDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.fullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.fullName).ToListAsync()
            };
            return response;
        }

        public async Task UpdateMovieAsync(NewMoviesVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.name = data.name;
                dbMovie.description = data.description;
                dbMovie.price = data.price;
                dbMovie.imageURL = data.imageURL;
                dbMovie.cinemaId = data.cinemaId;
                dbMovie.startDate = data.startDate;
                dbMovie.endDate = data.endDate;
                dbMovie.movieCategory = data.movieCategory;
                dbMovie.producerId = data.producerId;

                await _context.SaveChangesAsync();
            }

            //Remove Existing Actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.movieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.actorIds)
            {
                var newActorMovie = new Actors_Movies()
                {
                    movieId = data.Id,
                    actorId = actorId,
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
