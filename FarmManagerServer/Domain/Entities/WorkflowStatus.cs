using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WorkflowStatus : IBaseEntity
    {
        #region Constructors

        public WorkflowStatus()
        {
            WorkflowTask = new HashSet<WorkflowTask>();
            WorkflowCurrentStateActions = new HashSet<WorkflowStatusAction>();
            WorkflowTargetStateActions = new HashSet<WorkflowStatusAction>();
        }

        #endregion
        #region Properties

        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<WorkflowTask> WorkflowTask { get; set; }
        public ICollection<WorkflowStatusAction> WorkflowCurrentStateActions { get; set; }
        public ICollection<WorkflowStatusAction> WorkflowTargetStateActions { get; set; }

        #endregion
    }
}
