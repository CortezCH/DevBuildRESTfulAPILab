using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildRESTfulAPILab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieDAL MovieDAL = new MovieDAL();

        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return MovieDAL.GetAllMovies();
        }

        [HttpGet("SearchGenre/{genre}")]
        public IEnumerable<Movie> SearchByGenre(string genre)
        {
            Movie movieToSearch = new Movie();
            movieToSearch.Genre = genre;
            return MovieDAL.SearchMovies(movieToSearch);
        }

        [HttpGet("RandMovie")]
        public Movie RandomMovie()
        {
            Random rand = new Random();
            List<int> indices = MovieDAL.DBSize();
            int movieID = rand.Next(0, indices.Count);

            return MovieDAL.SearchMovie(indices[movieID]);
        }

        [HttpGet("RandMovie/{genre}")]
        public Movie RandomMovie(string genre)
        {
            Movie movieGenreToSearch = new Movie();
            movieGenreToSearch.Genre = genre;
            List<Movie> selectedMovies = MovieDAL.SearchMovies(movieGenreToSearch);

            Random rand = new Random();
            int movieID = rand.Next(0, selectedMovies.Count);

            return selectedMovies[movieID];
        }

        [HttpGet("RandMovieList/{quantity}")]
        public List<Movie> RandomMovieList(int quantity)
        {
            List<Movie> selectedMovies = new List<Movie>();
            Random rand = new Random();
            List<int> randIndeces = new List<int>();
            int placeholder = 0;
            List<int> movieIDs = MovieDAL.DBSize();

            while (randIndeces.Count < quantity)
            {
                placeholder = rand.Next(0, movieIDs.Count);
                if (!randIndeces.Contains(placeholder))
                {
                    randIndeces.Add(placeholder);
                    selectedMovies.Add(MovieDAL.SearchMovie(movieIDs[placeholder]));
                }
            }
            

            return selectedMovies;
        }

        [HttpGet("Categories")]
        public List<string> GetCategories()
        {
            List<string> categories = MovieDAL
                .GetAllMovies()
                .Select(movie => movie.Genre )
                .Distinct()
                .ToList();

            return categories;
        }
    }
}
