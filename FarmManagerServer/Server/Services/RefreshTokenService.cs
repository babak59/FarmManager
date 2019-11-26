using System;
using System.Linq;
using Domain.Entities;
using Server.Models.JWT;
using Server.Services.Interfaces;
using Microsoft.Extensions.Options;
using Domain.Services;
using Domain.Abstract;

namespace Server.Services
{
    public class RefreshTokenService : BaseService<RefreshToken>, IRefreshTokenService
    {
        #region Members

        private readonly JwtSettings _jwtSettings;

        #endregion
        #region Constructors

        public RefreshTokenService(IOptions<JwtSettings> jwtSettings, IBaseRepository<RefreshToken> mainRepository) : base(mainRepository)
        {
            _jwtSettings = jwtSettings.Value;
        }

        #endregion
        public void SaveRefreshToken(string username, string refreshToken)
        {
            var refreshTokenDb = new RefreshToken
            {
                Username = username,
                Token = refreshToken,
                ValidTime = DateTime.Now.AddSeconds(_jwtSettings.RefreshExpiration)
            };

            MainRepository.Add(refreshTokenDb);
            MainRepository.Save();
        }

        public void CancelRefreshToken(string refreshToken)
        {
            var refreshTokenDb = MainRepository.FindFirstOrDefault(x => x.Token == refreshToken);

            if (refreshTokenDb != null)
            {
                MainRepository.Delete(refreshTokenDb);
                MainRepository.Save();
            }
        }

        public RefreshToken GetValidRefreshToken(string username, string refreshToken)
        {
            return MainRepository.FindFirstOrDefault(x => x.Username == username && x.Token == refreshToken && x.ValidTime > DateTime.Now);
        }
    }
}
