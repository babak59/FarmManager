using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Employee : IBaseEntity
    {
        #region Constructors

        public Employee()
        {
            Farms = new HashSet<Farm>();
            FarmTasks = new HashSet<FarmTask>();
            CreatedFarmTasks = new HashSet<FarmTask>();
        }

        #endregion
        #region Properties

        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public long UserId { get; set; }

        public User User { get; set; }
        public ICollection<Farm> Farms { get; set; }
        public ICollection<FarmTask> FarmTasks { get; set; }
        public ICollection<FarmTask> CreatedFarmTasks { get; set; }

        #endregion
    }
}
