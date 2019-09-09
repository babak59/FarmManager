using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class FarmTask
    {
        #region Constructors

        public FarmTask()
        {
            TaskEquipments = new HashSet<TaskEquipment>();
            WorkflowTasks = new HashSet<WorkflowTask>();
        }

        #endregion
        #region Properties

        public long Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public long EmployeeId { get; set; }
        public long FieldId { get; set; }
        public long CreatorId { get; set; }

        public Employee Employee { get; set; }
        public Employee Creator { get; set; }
        public Field Field { get; set; }
        public ICollection<TaskEquipment> TaskEquipments { get; set; }
        public ICollection<WorkflowTask> WorkflowTasks { get; set; }

        #endregion
    }
}
