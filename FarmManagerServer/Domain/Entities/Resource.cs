using System.Collections.Generic;

namespace Domain.Entities
{
    public class Resource
    {
        #region Properties

        public Resource()
        {
            TaskEquipments = new HashSet<TaskEquipment>();
        }

        #endregion
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeOfResource { get; set; }
        public long FarmId { get; set; }

        public Farm Farm { get; set; }
        public ICollection<TaskEquipment> TaskEquipments { get; set; }

        #endregion
    }
}
