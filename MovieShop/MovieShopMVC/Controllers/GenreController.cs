using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{

    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        //GET
        public async Task<IActionResult> genre(int id)
        {
            var movie = await _genreService.GetMoviesInGenre(id);
            return View(movie);
        }

    }

}