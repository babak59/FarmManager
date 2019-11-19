using Domain.Abstract;

namespace Domain.Entities
{
    public class WorkflowStatusAction : IBaseEntity
    {
        #region Constructors

        public WorkflowStatusAction()
        {

        }

        #endregion
        #region Properties

        public long Id { get; set; }
        public bool HasEmailNotification { get; set; }
        public bool IsOwnerAction { get; set; }
        public string WorkflowCurrentStatusName { get; set; }
        public string WorkflowTargetStatusName { get; set; }
        public string WorkflowActionName { get; set; }
        public long WorkflowCurrentStatusId { get; set; }
        public long WorkflowTargetStatusId { get; set; }
        public long WorkflowActionId { get; set; }

        public WorkflowStatus WorkflowCurrentStatus { get; set; }
        public WorkflowStatus WorkflowTargetStatus { get; set; }
        public WorkflowAction WorkflowAction { get; set; }

        #endregion
    }
}
