using System.Linq;
using System.Security.Claims;
using Domain.Entities;
using Domain.Services.Abstract;
using Server.Models;
using Server.Models.JWT;
using Server.Services.Interfaces;

namespace Server.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IJwtHandler _jwtHandler;

        public AuthenticationService(IUserService userService, IJwtHandler jwtHandler, IRefreshTokenService refreshTokenService)
        {
            _userService = userService;
            _refreshTokenService = refreshTokenService;
            _jwtHandler = jwtHandler;
        }

        public bool IsAuthenticated(RequestToken request, out JsonWebToken token)
        {
            token = null;
            var validUser = _userService.GetValidUser(request.Username, request.Password);
            if (validUser == null)
            {
                return false;
            }

            token = GetToken(validUser);
            _refreshTokenService.SaveRefreshToken(request.Username, token.RefreshToken);

            return true;
        }

        public JsonWebToken RefreshJsonWebToken(string username, string refreshToken)
        {
            var refreshTokenDb = _refreshTokenService.GetValidRefreshToken(username, refreshToken);

            if (refreshTokenDb != null)
            {
                var user = _userService.GetValidUser(username);
                return GetToken(user);
            }

            return null;
        }

        private JsonWebToken GetToken(User user)
        {
            string roles = string.Empty;

            if (user.UserRoles != null && user.UserRoles.Any())
            {
                roles = string.Join(",", user.UserRoles.Select(x => x.Role.Name));
            }

            var claims = new[]
            {
                new Claim("user_name", user.Username),
                new Claim("email", user.Email),
                new Claim("roles", roles)
            };

            return _jwtHandler.CreateToken(user.Username, claims);
        }
    }
}
