using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers;

public class CinemaController(CinemaDbContext dbContext) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<CinemaIndexViewModel> cinemas = await dbContext
            .Cinemas
            .Select(c => new CinemaIndexViewModel()
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                Location = c.Location,
            })
            .OrderBy(x => x.Location)
            .ToArrayAsync();

        return View(cinemas);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(CinemaCreateViewModel model)
    {
        if (!this.ModelState.IsValid)
        {
            return this.View(model);
        }

        Cinema cinema = new Cinema()
        {
            Name = model.Name,
            Location = model.Location,
        };

        await dbContext.Cinemas.AddAsync(cinema);
        await dbContext.SaveChangesAsync();

        return this.RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(string? id)
    {
        if (String.IsNullOrWhiteSpace(id))
        {
            return RedirectToAction(nameof(Index));
        }

        bool isValid = Guid.TryParse(id, out Guid cinemaGuid);

        if (!isValid)
        {
            return RedirectToAction(nameof(Index));
        }

        Cinema? cinema =
           await dbContext
           .Cinemas
           .Include(c => c.CinemaMovies)
           .ThenInclude(cm => cm.Movie)
           .FirstOrDefaultAsync(c => c.Id == cinemaGuid);

        if (cinema == null)
        {
            return RedirectToAction(nameof(Index));
        }

        CinemaDetailsViewModel cinemaDetailsViewModel = new CinemaDetailsViewModel()
        {
            Name = cinema.Name,
            Location = cinema.Location,
            Movies = cinema.CinemaMovies
                    .Select(cm => new CinemaMovieViewModel()
                    {
                         Title = cm.Movie.Title,
                         Duration = cm.Movie.Duration,
                    })
                    .ToArray()
        };

        return View(cinemaDetailsViewModel);
    }

}
