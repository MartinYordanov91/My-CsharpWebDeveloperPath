using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static CinemaApp.Common.EntityValidationConstants.Movie;
namespace CinemaApp.Web.Controllers;

public class MovieController(CinemaDbContext dbContext) : Controller
{

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<Movie> movies = await dbContext
            .Movies
            .ToArrayAsync();

        return View(movies);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddMovieInputModel model)
    {
        if (ModelState.IsValid)
        {
            return this.View(model);
        }

        bool isReleaseDateTime = DateTime.TryParseExact(model.ReleaseDate, ReleaseDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDateValid);

        if (!isReleaseDateTime)
        {
            ModelState.AddModelError(nameof(model.ReleaseDate), "DateTime is not valid!");
            return View(model);
        }

        var movie = new Movie
        {
            Title = model.Title,
            Genre = model.Genre,
            ReleaseDate = releaseDateValid,
            Description = model.Description,
            Duration = model.Duration,
            Director = model.Director,
        };

        await dbContext.Movies.AddAsync(movie);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        bool isIdValid = Guid.TryParse(id, out Guid guidId);

        if (!isIdValid)
        {
            return RedirectToAction(nameof(Index));
        }

        Movie? movie = await dbContext.Movies.FirstOrDefaultAsync(m => m.Id == guidId);

        if (movie == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    [HttpGet]
    public async Task<IActionResult> AddToProgram(string id)
    {
        if (String.IsNullOrWhiteSpace(id))
        {
            return RedirectToAction(nameof(Index));
        }

        bool isValid = Guid.TryParse(id, out Guid movieGuid);

        if (!isValid)
        {
            return RedirectToAction(nameof(Index));
        }

        Movie? movie = await dbContext
            .Movies
            .FirstOrDefaultAsync(m => m.Id == movieGuid);

        if (movie == null)
        {
            return RedirectToAction(nameof(Index));
        }

        AddMovieToCinemaInputModel viewModel = new AddMovieToCinemaInputModel()
        {
            Id = id,
            MovieTitle = movie.Title,
            Cinemas = await dbContext
                     .Cinemas
                     .Include(c => c.CinemaMovies)
                     .ThenInclude(cm => cm.Movie)
                     .Select(c => new CinemaCheckBoxInputModel()
                     {
                         Id = c.Id.ToString(),
                         Name = c.Name,
                         IsSelected = c.CinemaMovies
                                     .Any(cm => cm.Movie.Id == movieGuid)
                     })
                     .ToArrayAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AddToProgram(AddMovieToCinemaInputModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        bool isValidMovie = Guid.TryParse(model.Id, out Guid movieGuid);

        if (!isValidMovie)
        {
            return RedirectToAction(nameof(Index));
        }


        Movie? movie = await dbContext
            .Movies
            .FirstOrDefaultAsync(m => m.Id == movieGuid);

        if (movie == null)
        {
            return RedirectToAction(nameof(Index));
        }

        ICollection<CinemaMovie> entityToAdd = new List<CinemaMovie>();

        foreach (CinemaCheckBoxInputModel cinemaInput in model.Cinemas)
        {
            if (cinemaInput.IsSelected == false)
            {
                continue;
            }

            bool isValidCinema = Guid.TryParse(cinemaInput.Id, out Guid cinemaGuid);

            if (!isValidCinema)
            {
                continue;
            }

            Cinema? cinema = await dbContext
                    .Cinemas
                    .FirstOrDefaultAsync(c => c.Id == cinemaGuid);

            if (cinema == null)
            {
                continue;
            }

           
            entityToAdd.Add(new CinemaMovie()
            {
                MovieId = movieGuid,
                CinemaId = cinemaGuid,
            });
        }

        await dbContext.CinemasMovies.AddRangeAsync(entityToAdd);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index) , "Cinema");
    }
}
