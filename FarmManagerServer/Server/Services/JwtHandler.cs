using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Server.Models.JWT;
using Server.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Server.Services
{
    public class JwtHandler : IJwtHandler
    {
        #region Variables

        private readonly JwtSettings _jwtSettings;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly SigningCredentials _signingCredentials;
        
        #endregion
        #region Constructors

        public JwtHandler(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha512);
        }

        #endregion
        #region Methods

        public JsonWebToken CreateToken(string username, Claim[] claims = null)
        {
            var expires = DateTime.Now.AddSeconds(_jwtSettings.AccessExpiration);
            Debug.WriteLine(expires);

            claims = claims ?? new[] {new Claim("user_name", username)};

            var jwtToken = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims,
                expires: expires, signingCredentials: _signingCredentials);
            var token = _jwtSecurityTokenHandler.WriteToken(jwtToken);

            return new JsonWebToken()
            {
                AccessToken = token,
                RefreshToken = Guid.NewGuid().ToString("N"),
                Expires = (long)(expires - DateTime.Now).TotalSeconds
            };
        }

        #endregion
    }
}
