
namespace Domain.Dtos
{
    public class UserChangePassword
    {
        public string Password { get; set; }
        public string MatchPassword { get; set; }
        public string Token { get; set; }
    }
}
