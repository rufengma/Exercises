using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;
        public CastController(ICastService castService) {
            _castService = castService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> CastDetail(int id)
        {
            var cast = await _castService.GetCastDetails(id);
            return View(cast);
        }
    }
}
