using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Field : IBaseEntity
    {
        #region Constructors

        public Field()
        {
            FarmTasks = new HashSet<FarmTask>();
        }

        #endregion
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Area { get; set; }
        public string Exploitation { get; set; }
        public long FarmId { get; set; }

        public Farm Farm { get; set; }
        public ICollection<FarmTask> FarmTasks { get; set; }

        #endregion
    }
}
