using System.Collections.Generic;

namespace Domain.Entities
{
    public class Role
    {
        #region Constructors

        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        #endregion
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public bool CommonUses { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        #endregion
    }
}
