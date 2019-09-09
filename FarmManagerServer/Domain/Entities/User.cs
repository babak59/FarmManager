using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        #region Constructors

        public User()
        {
            Employees = new HashSet<Employee>();
            UserRoles = new HashSet<UserRole>();
        }

        #endregion
        #region Properties

        public long Id { get; set; }
        public int NumberOfWrongAttempts { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ResetPasswordToken { get; set; }
        public string ConfirmationToken { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime? ResetPasswordTokenValid { get; set; }
        public DateTime? ConfirmationTokenValid { get; set; }
        public DateTime? LastWrongLogin { get; set; }
        public DateTime? LastSucessfulLogin { get; set; }
        public DateTime? BlockToDate { get; set; }
        public bool Active { get; set; }
        public long CompanyId { get; set; }

        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Token> Tokens { get; set; }

        #endregion
    }
}
