
namespace Domain.Entities
{
    public class WorkflowStatusAction
    {
        #region Constructors

        public WorkflowStatusAction()
        {

        }

        #endregion
        #region Properties

        public int Id { get; set; }
        public bool HasEmailNotification { get; set; }
        public bool IsOwnerAction { get; set; }
        public string WorkflowCurrentStatusName { get; set; }
        public string WorkflowTargetStatusName { get; set; }
        public string WorkflowActionName { get; set; }
        public int WorkflowCurrentStatusId { get; set; }
        public int WorkflowTargetStatusId { get; set; }
        public int WorkflowActionId { get; set; }

        public WorkflowStatus WorkflowCurrentStatus { get; set; }
        public WorkflowStatus WorkflowTargetStatus { get; set; }
        public WorkflowAction WorkflowAction { get; set; }

        #endregion
    }
}
