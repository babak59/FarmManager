using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.DAL
{
    public class FarmManagerDbContext : DbContext
    {
        #region Properties

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Farm> Farms { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TaskEquipment> TaskEquipments { get; set; }
        public virtual DbSet<FarmTask> FarmTasks { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkflowTask> WorkflowTasks { get; set; }
        public virtual DbSet<WorkflowStatusAction> WorkflowStatusActions { get; set; }
        public virtual DbSet<WorkflowAction> WorkflowActions { get; set; }
        public virtual DbSet<WorkflowStatus> WorkflowStatuses { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        #endregion
        #region Constructors

        public FarmManagerDbContext(DbContextOptions<FarmManagerDbContext> options) : base(options) { }

        #endregion
        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.UserId)
                    .HasName("FKEmployeeUser");

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.UserId).HasColumnType("bigint(19)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKEmployeeUser");

            });

            modelBuilder.Entity<Farm>(entity =>
            {
                entity.ToTable("farms");
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.OwnerId)
                    .HasName("FKFarmEmployee");

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.OwnerId).HasColumnType("bigint(19)");

                entity.Property(e => e.SerialNumber).HasColumnType("varchar(80)");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Farms)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKFarmEmployee");
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.ToTable("fields");

                entity.HasIndex(e => e.FarmId)
                    .HasName("FKFieldFarm");

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.Property(e => e.Area).HasColumnType("decimal(10,4)");

                entity.Property(e => e.Exploitation)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FarmId).HasColumnType("bigint(19)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Fields)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKFieldFarm");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.ToTable("machines");

                entity.HasIndex(e => e.FarmId)
                    .HasName("FKMachineFarm");

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.FarmId).HasColumnType("bigint(19)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Purpose)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SerialNumber).HasColumnType("varchar(80)");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKMachineFarm");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("companies");

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasIndex(e => e.FarmId)
                    .HasName("FKResourceFarm");

                entity.ToTable("resources");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Description).HasColumnType("varchar(500)");

                entity.Property(e => e.FarmId).HasColumnType("bigint(19)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKResourceFarm");

                entity.Property(e => e.TypeOfResource).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(70)");

                entity.Property(e => e.CommonUses)
                    .HasColumnType("bit(1)")
                    .HasDefaultValue(true);
            });

            modelBuilder.Entity<TaskEquipment>(entity =>
            {
                entity.ToTable("task_equipments");

                entity.HasIndex(e => e.MachineId)
                    .HasName("FKTaskEquipMachine");

                entity.HasIndex(e => e.ResourceId)
                    .HasName("FKTaskEquipmResource");

                entity.HasIndex(e => e.FarmTaskId)
                    .HasName("FKTaskEquipTask");

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.Property(e => e.MachineId).HasColumnType("bigint(19)");

                entity.Property(e => e.ResourceId).HasColumnType("int(10)");

                entity.Property(e => e.FarmTaskId).HasColumnName("TaskId").HasColumnType("bigint(19)");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.TaskEquipments)
                    .HasForeignKey(d => d.MachineId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKTaskEquipMachine");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.TaskEquipments)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKTaskEquipmResource");

                entity.HasOne(d => d.FarmTask)
                    .WithMany(p => p.TaskEquipments)
                    .HasForeignKey(d => d.FarmTaskId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKTaskEquipTask");
            });

            modelBuilder.Entity<FarmTask>(entity =>
            {
                entity.ToTable("farm_tasks");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FKTaskEmployee");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FKTaskCreator");

                entity.HasIndex(e => e.FieldId)
                    .HasName("FKTaskField");

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("varchar(2000)");

                entity.Property(e => e.EmployeeId).HasColumnType("bigint(19)");

                entity.Property(e => e.CreatorId).HasColumnType("bigint(19)");

                entity.Property(e => e.FieldId).HasColumnType("bigint(19)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.FarmTasks)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKTaskEmployee");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.CreatedFarmTasks)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKTaskCreator");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.FarmTasks)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKTaskField");
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("tokens");

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.HasOne(t => t.User)
                    .WithMany(p => p.Tokens)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKTokenUser");

                entity.Property(e => e.Value)
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TargetEmail)
                    .HasColumnType("varchar(150)");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_roles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("FKUserRoleRole");

                entity.HasIndex(e => e.UserId)
                    .HasName("FKUserRoleUser");

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.Property(e => e.RoleId).HasColumnType("bigint(19)");

                entity.Property(e => e.UpToDate)
                    .HasColumnType("bit(1)")
                    .HasDefaultValue(true);

                entity.Property(e => e.UserId).HasColumnType("bigint(19)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUserRoleRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUserRoleUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("FKUserCompany");

                entity.HasIndex(e => e.Username)
                    .HasName("UsersUniqueUserName")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UsersUniqueEmail")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.Property(e => e.DateRegistration)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnType("tinyblob");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnType("tinyblob");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(70)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.ResetPasswordToken)
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.ConfirmationToken)
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.NumberOfWrongAttempts)
                    .HasColumnType("int(3)");

                entity.Property(e => e.LastWrongLogin)
                    .HasColumnType("datetime");

                entity.Property(e => e.LastSucessfulLogin)
                    .HasColumnType("datetime");

                entity.Property(e => e.BlockToDate)
                    .HasColumnType("datetime");

                entity.Property(e => e.ResetPasswordTokenValid)
                    .HasColumnType("datetime");

                entity.Property(e => e.ConfirmationTokenValid)
                    .HasColumnType("datetime");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasDefaultValue(true);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKUserCompany");
            });

            modelBuilder.Entity<WorkflowTask>(entity =>
            {
                entity.ToTable("workflow_tasks");

                entity.HasIndex(e => e.FarmTaskId)
                    .HasName("FKWflTaskTask");

                entity.HasIndex(e => e.WorkflowStatusId)
                    .HasName("FKWflTaskWflStatus");

                entity.HasIndex(e => e.WorkflowActionId)
                    .HasName("FKWflTaskWflAction");

                entity.Property(e => e.Id).HasColumnType("bigint(19)");

                entity.Property(e => e.FarmTaskId).HasColumnName("TaskId").HasColumnType("bigint(19)");

                entity.Property(e => e.WorkflowStatusId).HasColumnType("int(10)");

                entity.Property(e => e.WorkflowActionId).HasColumnType("int(10)");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.WorkflowStatusCode).HasColumnType("varchar(50)");

                entity.Property(e => e.Symbol).HasColumnType("varchar(50)");

                entity.Property(e => e.WorkflowStatusName).HasColumnType("varchar(50)");

                entity.Property(e => e.WorkflowActionName).HasColumnType("varchar(50)");

                entity.HasOne(d => d.FarmTask)
                    .WithMany(p => p.WorkflowTasks)
                    .HasForeignKey(d => d.FarmTaskId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKWflTaskTask");

                entity.HasOne(d => d.WorkflowAction)
                    .WithMany(p => p.WorkflowTasks)
                    .HasForeignKey(d => d.WorkflowActionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKWflTaskWflAction");

                entity.HasOne(d => d.WorkflowStatus)
                    .WithMany(p => p.WorkflowTask)
                    .HasForeignKey(d => d.WorkflowStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKWflTaskWflStatus");
            });

            modelBuilder.Entity<WorkflowStatusAction>(entity =>
            {
                entity.ToTable("workflow_status_actions");

                entity.HasIndex(e => e.WorkflowCurrentStatusId)
                    .HasName("FKWflStatusActionWflCurrentStatus");

                entity.HasIndex(e => e.WorkflowTargetStatusId)
                    .HasName("FKWflStatusActionWflTargetStatus");

                entity.HasIndex(e => e.WorkflowActionId)
                    .HasName("FKWflStatusActionWflAction");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.WorkflowCurrentStatusId).HasColumnType("int(10)");

                entity.Property(e => e.WorkflowTargetStatusId).HasColumnType("int(10)");

                entity.Property(e => e.WorkflowActionId).HasColumnType("int(10)");

                entity.Property(e => e.WorkflowCurrentStatusName).HasColumnType("varchar(50)");

                entity.Property(e => e.WorkflowTargetStatusName).HasColumnType("varchar(50)");

                entity.Property(e => e.WorkflowActionName).HasColumnType("varchar(50)");

                entity.Property(e => e.HasEmailNotification)
                    .IsRequired()
                    .HasColumnType("bit(1)");

                entity.Property(e => e.HasEmailNotification)
                    .IsRequired()
                    .HasColumnType("bit(1)");

                entity.Property(e => e.IsOwnerAction).HasColumnType("bit(1)");

                entity.HasOne(d => d.WorkflowAction)
                    .WithMany(p => p.WorkflowStatusActions)
                    .HasForeignKey(d => d.WorkflowActionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKWflStatusActionWflAction");

                entity.HasOne(d => d.WorkflowCurrentStatus)
                    .WithMany(p => p.WorkflowCurrentStateActions)
                    .HasForeignKey(d => d.WorkflowCurrentStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKWflStatusActionWflCurrentStatus");

                entity.HasOne(d => d.WorkflowTargetStatus)
                    .WithMany(p => p.WorkflowTargetStateActions)
                    .HasForeignKey(d => d.WorkflowTargetStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FKWflStatusActionWflTargetStatus");
            });

            modelBuilder.Entity<WorkflowAction>(entity =>
            {
                entity.ToTable("workflow_actions");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Description).HasColumnType("varchar(500)");

            });

            modelBuilder.Entity<WorkflowStatus>(entity =>
            {
                entity.ToTable("workflow_statuses");

                entity.HasIndex(e => e.Code)
                    .HasName("WflStatusesUniqueCode")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Description).HasColumnType("varchar(500)");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshTokens");
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Token)
                    .HasName("IDXRefreshTokenToken");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(19)");

                entity.Property(e => e.ValidTime)
                    .IsRequired()
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(70)");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
            });
        }

        #endregion
    }
}
