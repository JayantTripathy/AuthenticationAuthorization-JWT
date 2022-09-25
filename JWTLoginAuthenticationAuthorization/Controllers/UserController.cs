using JWTLoginAuthenticationAuthorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWTLoginAuthenticationAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //For admin Only
        [HttpGet]
        [Route("getAdminUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi, wWelcome you are a {currentUser.Role}");
        }
        //For EndUser Only
        [HttpGet]
        [Route("getEndUser")]
        [Authorize(Roles = "EndUser")]
        public IActionResult UserEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi, wWelcome you are a {currentUser.Role}");
        }
        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;

        }
    }
}
