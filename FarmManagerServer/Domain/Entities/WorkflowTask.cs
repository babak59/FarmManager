using Domain.Abstract;
using System;

namespace Domain.Entities
{
    public class WorkflowTask : IBaseEntity
    {
        #region Constructors

        public WorkflowTask()
        {

        }

        #endregion
        #region Properties

        public long Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string WorkflowStatusName { get; set; }
        public string WorkflowStatusCode { get; set; }
        public string WorkflowActionName { get; set; }
        public string Symbol { get; set; }
        public long FarmTaskId { get; set; }
        public long WorkflowStatusId { get; set; }
        public long WorkflowActionId { get; set; }

        public FarmTask FarmTask { get; set; }
        public WorkflowStatus WorkflowStatus { get; set; }
        public WorkflowAction WorkflowAction { get; set; }

        #endregion
    }
}
