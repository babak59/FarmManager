using System.Collections.Generic;

namespace Domain.Entities
{
    public class Farm
    {
        #region Constructors

        public Farm()
        {
            Fields = new HashSet<Field>();
            Machines = new HashSet<Machine>();
            Resources = new HashSet<Resource>();
        }

        #endregion
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public long OwnerId { get; set; }

        public Employee Owner { get; set; }
        public ICollection<Field> Fields { get; set; }
        public ICollection<Machine> Machines { get; set; }
        public ICollection<Resource> Resources { get; set; }

        #endregion
    }
}
