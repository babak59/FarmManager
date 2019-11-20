using Domain.Entities;

namespace Server.Services.Interfaces
{
    public interface IRefreshTokenService
    {
        void SaveRefreshToken(string username, string refreshToken);
        void CancelRefreshToken(string refreshToken);
        RefreshToken GetValidRefreshToken(string username, string refreshToken);
    }
}
