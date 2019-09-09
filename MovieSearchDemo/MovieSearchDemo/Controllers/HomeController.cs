using Microsoft.AspNetCore.Mvc;
using MovieSearchDemo.DataSet;
using MovieSearchDemo.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace MovieSearchDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var list = MovieData.GetMovielists();
            return View(list);
        }
        [HttpPost]
        public IActionResult Index(int movieId)
        { 
            var movie = MovieData.GetMovieById(movieId);

            if (movie != null)
            {
                return View("/Views/Partial/_SearchPartial.cshtml", movie);
            }
            else
            {
                return Content("Not Found");
            }
           
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
