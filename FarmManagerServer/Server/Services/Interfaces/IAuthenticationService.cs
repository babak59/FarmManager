using Server.Models;
using Server.Models.JWT;

namespace Server.Services.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated(RequestToken request, out JsonWebToken token);
        JsonWebToken RefreshJsonWebToken(string username, string refreshToken);
    }
}
