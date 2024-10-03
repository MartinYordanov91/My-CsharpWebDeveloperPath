namespace CinemaApp.Data.Models;

public class Movie
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; } = string.Empty;
    public int Duration { get; set; }
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<CinemaMovie> MovieCinemas { get; set; } = new HashSet<CinemaMovie>();
}
