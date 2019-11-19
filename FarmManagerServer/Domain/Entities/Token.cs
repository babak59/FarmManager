using Domain.Abstract;
using System;

namespace Domain.Entities
{
    public class Token : IBaseEntity
    {
        #region Properties

        public long Id { get; set; }
        public string Value { get; set; }
        public DateTime? TokenValid { get; set; }
        public string TargetEmail { get; set; }
        public long UserId { get; set; }

        public User User { get; set; }

        #endregion
    }
}
