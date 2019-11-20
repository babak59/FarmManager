using Server.Models;
using Server.Models.JWT;
using Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }       

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Authenticate([FromBody] RequestToken request)
        {
            if (request.GrantType == GrantType.Password)
            {
                if (_authenticationService.IsAuthenticated(request, out JsonWebToken token))
                {
                    return Ok(token);
                }
            }
            else if (request.GrantType == GrantType.RefreshToken)
            {
                var token = _authenticationService.RefreshJsonWebToken(request.Username, request.RefreshToken);
                if (token == null)
                {
                    return Unauthorized("Time has expired. Please log in again!");
                }

                return Ok(token);
            }


            return BadRequest("User does not exist.");
        }
    }
}
