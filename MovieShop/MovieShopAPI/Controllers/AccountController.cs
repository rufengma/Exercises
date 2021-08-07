using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase

    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AccountController(IUserService userService,IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
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
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(UserLoginRequestModel model)
        {
            var user = await _userService.Login(model.Email, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            //if user inserted valid un/pw

            var jwt = GenerateJWT(user);
            return Ok(new { token = jwt });

        }
        private string GenerateJWT(UserLoginResponseModel model)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,model.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,model.FirstName),
                new Claim(JwtRegisteredClaimNames.Email,model.Email),
                new Claim(JwtRegisteredClaimNames.FamilyName, model.LastName)
            };
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["MovieShopSecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expires = DateTime.Now.AddDays(_configuration.GetValue<int>("ExpirationDuration"));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenObject = new SecurityTokenDescriptor()
            {
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = _configuration["MovieShopIssuer"],
                Audience = _configuration["MovieShopAudience"]
            };
            var encodedJwt = tokenHandler.CreateToken(tokenObject);
            return tokenHandler.WriteToken(encodedJwt);
        }


    }
}
