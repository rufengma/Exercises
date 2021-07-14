using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller

    {
        // Each and every request in MVC controller
        // localhost/home/index
        //1. Constructor Injection 99%
        //2. Method Injection
        //3. Property Injection
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetTopRevenueMovies();
            var myType = movies.GetType();
            // 3 ways to send the data from Controller/action to View
            // 1. Models (strongly typed models)
            // 2. ViewBag
            // 3. ViewData

            ViewBag.MoviesCount = movies.Count();
            return View(movies);
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
