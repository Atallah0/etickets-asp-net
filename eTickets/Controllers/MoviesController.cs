using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.cinemas);
            return View(allMovies);
        }

        //Get: Search/Filter
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.cinemas);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filterdResult = allMovies.Where(n => n.name.Contains(searchString) || n.description.Contains(searchString)).ToList();
                return View("Index", filterdResult);
            }

            return View("Index", allMovies);
        }

        //Get: Movies/Details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }

        //Get: Movies/Create
        public async Task<IActionResult> Create()
        {
            var moviesDropdownsData = await _service.GetNewMoviesDropdownsValues();
            ViewBag.Cinemas = new SelectList(moviesDropdownsData.Cinemas, "Id", "name");
            ViewBag.Producers = new SelectList(moviesDropdownsData.Producers, "Id", "fullName");
            ViewBag.Actors = new SelectList(moviesDropdownsData.Actors, "Id", "fullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMoviesVM movie)
        {
            if (!ModelState.IsValid)
            {
                var moviesDropdownsData = await _service.GetNewMoviesDropdownsValues();
                ViewBag.Cinemas = new SelectList(moviesDropdownsData.Cinemas, "Id", "name");
                ViewBag.Producers = new SelectList(moviesDropdownsData.Producers, "Id", "fullName");
                ViewBag.Actors = new SelectList(moviesDropdownsData.Actors, "Id", "fullName");
                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //Get: Movies/Update
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if(movieDetails == null) return View("NotFound");

            var response = new NewMoviesVM()
            {
                Id = movieDetails.Id,
                name = movieDetails.name,
                description = movieDetails.description,
                price = movieDetails.price,
                startDate = movieDetails.startDate,
                endDate = movieDetails.endDate,
                imageURL = movieDetails.imageURL,
                movieCategory = movieDetails.movieCategory,
                cinemaId = movieDetails.cinemaId,
                producerId = movieDetails.producerId,
                actorIds = movieDetails.actors_Movies.Select(n => n.actorId).ToList()
            };

            var moviesDropdownsData = await _service.GetNewMoviesDropdownsValues();
            ViewBag.Cinemas = new SelectList(moviesDropdownsData.Cinemas, "Id", "name");
            ViewBag.Producers = new SelectList(moviesDropdownsData.Producers, "Id", "fullName");
            ViewBag.Actors = new SelectList(moviesDropdownsData.Actors, "Id", "fullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMoviesVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var moviesDropdownsData = await _service.GetNewMoviesDropdownsValues();
                ViewBag.Cinemas = new SelectList(moviesDropdownsData.Cinemas, "Id", "name");
                ViewBag.Producers = new SelectList(moviesDropdownsData.Producers, "Id", "fullName");
                ViewBag.Actors = new SelectList(moviesDropdownsData.Actors, "Id", "fullName");
                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}