using System.Collections.Generic;

namespace Domain.Entities
{
    public class Machine
    {
        #region Constructors

        public Machine()
        {
            TaskEquipments = new HashSet<TaskEquipment>();
        }

        #endregion
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
        public string Purpose { get; set; }
        public long FarmId { get; set; }

        public Farm Farm { get; set; }
        public ICollection<TaskEquipment> TaskEquipments { get; set; }

        #endregion
    }
}
