
namespace Domain.Entities
{
    public class UserRole
    {
        #region Properties

        public long Id { get; set; }
        public long RoleId { get; set; }
        public long UserId { get; set; }
        public bool? UpToDate { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }

        #endregion
    }
}
