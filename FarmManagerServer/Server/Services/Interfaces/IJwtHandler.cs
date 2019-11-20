using System.Security.Claims;
using Server.Models.JWT;

namespace Server.Services.Interfaces
{
    public interface IJwtHandler
    {
        #region Properties

        JsonWebToken CreateToken(string username, Claim[] claims = null);

        #endregion
    }
}
