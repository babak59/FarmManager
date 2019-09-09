
namespace Domain.Entities
{
    public class TaskEquipment
    {
        #region Properties

        public long Id { get; set; }
        public long FarmTaskId { get; set; }
        public long MachineId { get; set; }
        public int ResourceId { get; set; }

        public Machine Machine { get; set; }
        public Resource Resource { get; set; }
        public FarmTask FarmTask { get; set; }

        #endregion
    }
}
