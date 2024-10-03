using CinemaApp.Web.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Cinema;

public class CinemaDetailsViewModel
{
    public string Name { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public IEnumerable<CinemaMovieViewModel> Movies { get; set; }
    = new HashSet<CinemaMovieViewModel>();
}
