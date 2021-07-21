using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase

    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        //==> localhost:55043/api/Account/api/Account
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequestModel model)
        {
            var createdUser = await _userService.RegisterUser(model);

            //send the url for newly created user also

            return Ok(createdUser);
        }
        //==> localhost:55043/api/Account/api/Account/{id}
        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound($"user does not exists for {id}");
            }
            return Ok(user);
        }
        //==> localhost:55043/api/Account/api/Account/login
        //[HttpPost]
        //public async Task<IActionResult> login([FromBody] UserLoginRequestModel model)
        //{
        //    var loginRequest = await _userService.Login(model)

        //}
    }
}
