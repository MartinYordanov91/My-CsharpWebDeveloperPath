using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static CinemaApp.Common.EntityValidationConstants.Movie;
namespace CinemaApp.Web.Controllers;

public class MovieController : Controller
{
    private readonly CinemaDbContext dbContext;

    public MovieController(CinemaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<Movie> movies = this.dbContext
            .Movies
            .ToList();

        return View(movies);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(AddMovieInputModel model)
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

        this.dbContext.Movies.Add(movie);
        this.dbContext.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Details(string id)
    {
        bool isIdValid = Guid.TryParse(id, out Guid guidId);

        if (!isIdValid)
        {
            return RedirectToAction(nameof(Index));
        }

        Movie? movie = this.dbContext.Movies.FirstOrDefault(m => m.Id == guidId);

        if (movie == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }
}
