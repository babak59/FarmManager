
namespace Domain.Dtos
{
    public class UserRegistrationDto
    {
        #region Properties

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MatchPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        #endregion
    }
}
