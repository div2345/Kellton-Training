using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDisplay.DataStore;
using MovieDisplay.Models;
using X.PagedList;
using System.Diagnostics;
using System.Linq;


namespace MovieDisplay.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? page, string sortBy)
        {
            ViewBag.MovieIdSort = string.IsNullOrEmpty(sortBy) ? "MovieId desc" : " ";
            ViewBag.MovieSort = sortBy == "MovieName" ? "MovieName desc" : "MovieName";
            ViewBag.ReleaseYearSort = sortBy == "ReleaseYear" ? "ReleaseYear desc" : "ReleaseYear";
            ViewBag.GenreSort = sortBy == "Genre" ? "Genre desc" : "Genre";

            var movies = Movies.GetMovielists().AsQueryable();

           
            switch (sortBy)
            {
                case "MovieId desc":
                    movies = movies.OrderByDescending(x => x.MovieId);
                    break;

                case "MovieName desc":
                    movies = movies.OrderByDescending(x => x.MovieName);
                    break;
                case "MovieName":
                    movies = movies.OrderBy(x => x.MovieName);
                    break;

                case "ReleaseYear desc":
                    movies = movies.OrderByDescending(x => x.ReleaseYear);
                    break;
                case "ReleaseYear":
                    movies = movies.OrderBy(x => x.ReleaseYear);
                    break;

                case "Genre desc":
                    movies = movies.OrderByDescending(x => x.Genre);
                    break;
                case "Genre":
                    movies = movies.OrderBy(x => x.Genre);
                    break;
               
                default:
                    movies = movies.OrderBy(x => x.MovieId);
                    break;
            }
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //return View(movies.ToPagedList(pageNumber, pageSize));
            return View(movies.ToList().ToPagedList(page ?? 1, 10));
            //return View(movies.ToList().l(page ?? 1, 10));
        }



          
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
