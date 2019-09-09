using System.Collections.Generic;

namespace Domain.Entities
{
    public class Company
    {
        #region Constructors

        public Company()
        {
            Users = new HashSet<User>();
        }

        #endregion
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<User> Users { get; set; }

        #endregion
    }
}
