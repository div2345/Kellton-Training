using MovieSearchDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSearchDemo.DataSet
{
    public class MovieData
    {
        public static List<Movie> GetMovielists()
        {
            List<Movie> movie = new List<Movie>();
            movie.Add(new Movie
            {
                MovieId = 1,
                MovieName = "Titanic",
                ReleaseYear = 1998,
                Genre = "Romance"
            });
            movie.Add(new Movie
            {
                MovieId = 2,
                MovieName = "Forest Gump",
                ReleaseYear = 1995,
                Genre = "Fiction"
            });
            movie.Add(new Movie
            {
                MovieId = 3,
                MovieName = "Bhaubali",
                ReleaseYear = 2017,
                Genre = "Fiction"
            });
            movie.Add(new Movie
            {
                MovieId = 4,
                MovieName = "The Dark Night",
                ReleaseYear = 2007,
                Genre = "Fiction"
            });
            movie.Add(new Movie
            {
                MovieId = 5,
                MovieName = "The Shashwank Redemption",
                ReleaseYear = 1988,
                Genre = "Fiction"
            });
            return movie;
        }
        public static Movie GetMovieById(int id)
        {
            return GetMovielists().Where(x => x.MovieId == id).FirstOrDefault();
        }
    }
}
