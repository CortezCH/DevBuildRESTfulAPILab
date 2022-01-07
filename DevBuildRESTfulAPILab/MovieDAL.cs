using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildRESTfulAPILab
{
    public class MovieDAL
    {
        public void CreateMovie(Movie newMovie)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = $"INSERT INTO Movies " +
                    $"VALUES movieid={newMovie.MovieID}, " +
                    $"title=\"{newMovie.Title}\", " +
                    $"genre=\"{newMovie.Genre}\", " +
                    $"ReleaseDate={newMovie.ReleaseDate}";

                connect.Open();
                connect.Query(sql);
                connect.Close();
            }
        }

        public List<Movie> GetAllMovies()
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = $"SELECT * FROM Movies";

                connect.Open();
                List<Movie> returnedMovie = connect.Query<Movie>(sql).ToList();
                connect.Close();
                return returnedMovie;
            }
        }

        public List<int> DBSize()
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = $"SELECT movieID FROM Movies";

                connect.Open();
                List<int> movieIndices = connect.Query<int>(sql).ToList();
                connect.Close();
                return movieIndices;
            }
        }

        public List<Movie> SearchMovies(Movie movieToSearch)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = $"SELECT * " +
                    $"FROM Movies " +
                    $"WHERE ReleaseDate={movieToSearch.ReleaseDate} ";

                if (movieToSearch.Genre != null && movieToSearch.Genre != string.Empty)
                {
                    sql += $"OR genre LIKE \"%{movieToSearch.Genre}%\" ";
                }
                if (movieToSearch.Title != null && movieToSearch.Title != string.Empty)
                {
                    sql += $"OR title LIKE \"%{movieToSearch.Title}%\"";
                }


                connect.Open();
                List<Movie> returnedMovies = connect.Query<Movie>(sql).ToList();
                connect.Close();
                return returnedMovies;
            }
        }

        public Movie SearchMovie(int movieID)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = $"SELECT * " +
                    $"FROM Movies " +
                    $"WHERE movieid={movieID}";

                connect.Open();
                Movie returnedMovie = connect.Query<Movie>(sql).ToList().First();
                connect.Close();
                return returnedMovie;
            }
        }

        public void UpdateMovies(Movie movieToUpdate)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = $"UPDATE movies " +
                    $"SET movieid={movieToUpdate.MovieID}, " +
                    $"title=\"{movieToUpdate.Title}\", " +
                    $"genre=\"{movieToUpdate.Genre}\", " +
                    $"ReleaseDate={movieToUpdate.ReleaseDate} " +
                    $"WHERE movieID={movieToUpdate.MovieID}";

                connect.Open();
                List<Movie> returnedMovies = connect.Query<Movie>(sql).ToList();
                connect.Close();
            }
        }

        public void DeleteMovie(int movieID)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = $"DELETE " +
                    $"FROM Movies " +
                    $"WHERE movieid={movieID}";

                connect.Open();
                connect.Query(sql);
                connect.Close();
            }
        }
    }
}
