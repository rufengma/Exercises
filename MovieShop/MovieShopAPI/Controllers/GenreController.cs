using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;


namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        [Route("Genres")]
        public async Task<IActionResult> getGenres() {
            var allGenres =await _genreService.GetAllGenres();
            if (!allGenres.Any())
            {
                return NotFound("No ANY GENRES");
            }

            return Ok(allGenres);
        }

    }
}