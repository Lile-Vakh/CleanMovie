using CleanMovie.Application;
using CleanMovie.Domain;

namespace CleanMovie.Infrastructure;

public class MovieRepository : IMovieRepository
{
    private readonly MovieDbContext _movieDbContext;
    /*
    public static List<Movie> movies = new List<Movie>()
    {
        new Movie {MovieId = Id = 1, Name = "Passion of Christ", Cost = 2},
        new Movie {Id = 2, Name = "Home Alone", Cost = 1}
     };
    */

    public MovieRepository(MovieDbContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }
    public List<Movie> GetAllMovies()
    {
        return _movieDbContext.Movies.ToList(); 
    }

    public Movie CreateMovie(Movie movie)
    {
        _movieDbContext.Movies.Add(movie);
        _movieDbContext.SaveChanges();
        return movie;
    }
}