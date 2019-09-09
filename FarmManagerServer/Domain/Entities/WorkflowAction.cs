
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WorkflowAction
    {
        #region Constructors

        public WorkflowAction()
        {
            WorkflowTasks = new HashSet<WorkflowTask>();
            WorkflowStatusActions = new HashSet<WorkflowStatusAction>();
        }

        #endregion
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<WorkflowTask> WorkflowTasks { get; set; }
        public ICollection<WorkflowStatusAction> WorkflowStatusActions { get; set; }

        #endregion
    }
}
