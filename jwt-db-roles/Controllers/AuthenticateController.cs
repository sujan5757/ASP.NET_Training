using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AspCoreJwtDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCoreJwtDb.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private ProductManagementDbContext productManagementDbContext;
        public AuthenticateController(IConfiguration configuration, ProductManagementDbContext productManagementDbContext)
        {
            Configuration = configuration;
            this.productManagementDbContext = productManagementDbContext;
        }

        public IConfiguration Configuration { get; }

        #region sending credentials in request headers
        //public IActionResult Post()
        //{
        //    var authorizationHeader = Request.Headers["Authorization"].First();
        //    var key = authorizationHeader.Split(' ')[1];
        //    var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(key)).Split(':');
        //    var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:ServerSecret"]));

        //    User userFound = this.productManagementDbContext.Users.Where(u => u.Email == credentials[0].ToString() && u.Password == credentials[1].ToString()).FirstOrDefault();

        //    if (userFound != null)
        //    {
        //        var result = new
        //        {
        //            token = GenerateToken(serverSecret, userFound)
        //        };
        //        return Ok(result);//status code
        //    }
        //    return BadRequest("Invalid Email/Password");//status code
        //}
        #endregion

        #region sending credentials in body
        public IActionResult Post([FromBody] User user)
        {
            var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:ServerSecret"]));

            User userFound = this.productManagementDbContext.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if (userFound != null)
            {
                var result = new
                {
                    token = GenerateToken(serverSecret, userFound)
                };
                return Ok(result);//status code
            }
            return BadRequest("Invalid Email/Password");//status code
        }
        #endregion

        private string GenerateToken(SecurityKey key, User user)
        {
                var now = DateTime.UtcNow;
                var issuer = Configuration["JWT:Issuer"];
                var audience = Configuration["JWT:Audience"];
                var identity = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim(ClaimTypes.Name, user.Id.ToString())
                    });
                var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var handler = new JwtSecurityTokenHandler();
                var token = handler.CreateJwtSecurityToken(issuer, audience, identity,
                now, now.Add(TimeSpan.FromHours(1)), now, signingCredentials);
                var encodedJwt = handler.WriteToken(token);
                return encodedJwt;
        }
    }
}

