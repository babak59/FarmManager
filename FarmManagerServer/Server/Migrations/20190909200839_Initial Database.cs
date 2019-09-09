using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(70)", nullable: false),
                    CommonUses = table.Column<bool>(type: "bit(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "workflow_actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workflow_actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "workflow_statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workflow_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumberOfWrongAttempts = table.Column<int>(type: "int(3)", nullable: false),
                    Username = table.Column<string>(type: "varchar(70)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    ResetPasswordToken = table.Column<string>(type: "varchar(40)", nullable: true),
                    ConfirmationToken = table.Column<string>(type: "varchar(40)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "tinyblob", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "tinyblob", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    ResetPasswordTokenValid = table.Column<DateTime>(type: "datetime", nullable: true),
                    ConfirmationTokenValid = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastWrongLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastSucessfulLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    BlockToDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit(1)", nullable: false, defaultValue: true),
                    CompanyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FKUserCompany",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "workflow_status_actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HasEmailNotification = table.Column<bool>(type: "bit(1)", nullable: false),
                    IsOwnerAction = table.Column<bool>(type: "bit(1)", nullable: false),
                    WorkflowCurrentStatusName = table.Column<string>(type: "varchar(50)", nullable: true),
                    WorkflowTargetStatusName = table.Column<string>(type: "varchar(50)", nullable: true),
                    WorkflowActionName = table.Column<string>(type: "varchar(50)", nullable: true),
                    WorkflowCurrentStatusId = table.Column<int>(type: "int(10)", nullable: false),
                    WorkflowTargetStatusId = table.Column<int>(type: "int(10)", nullable: false),
                    WorkflowActionId = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workflow_status_actions", x => x.Id);
                    table.ForeignKey(
                        name: "FKWflStatusActionWflAction",
                        column: x => x.WorkflowActionId,
                        principalTable: "workflow_actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKWflStatusActionWflCurrentStatus",
                        column: x => x.WorkflowCurrentStatusId,
                        principalTable: "workflow_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKWflStatusActionWflTargetStatus",
                        column: x => x.WorkflowTargetStatusId,
                        principalTable: "workflow_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(type: "varchar(100)", nullable: false),
                    Lastname = table.Column<string>(type: "varchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    UserId = table.Column<long>(type: "bigint(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FKEmployeeUser",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(type: "varchar(50)", nullable: true),
                    TokenValid = table.Column<DateTime>(nullable: true),
                    TargetEmail = table.Column<string>(type: "varchar(150)", nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FKTokenUser",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(type: "bigint(19)", nullable: false),
                    UserId = table.Column<long>(type: "bigint(19)", nullable: false),
                    UpToDate = table.Column<bool>(type: "bit(1)", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => x.Id);
                    table.ForeignKey(
                        name: "FKUserRoleRole",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKUserRoleUser",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "farms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    SerialNumber = table.Column<string>(type: "varchar(80)", nullable: true),
                    OwnerId = table.Column<long>(type: "bigint(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farms", x => x.Id);
                    table.ForeignKey(
                        name: "FKFarmEmployee",
                        column: x => x.OwnerId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fields",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    Exploitation = table.Column<string>(type: "varchar(50)", nullable: false),
                    FarmId = table.Column<long>(type: "bigint(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fields", x => x.Id);
                    table.ForeignKey(
                        name: "FKFieldFarm",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "machines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Brand = table.Column<string>(type: "varchar(100)", nullable: false),
                    SerialNumber = table.Column<string>(type: "varchar(80)", nullable: true),
                    Purpose = table.Column<string>(type: "varchar(50)", nullable: false),
                    FarmId = table.Column<long>(type: "bigint(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_machines", x => x.Id);
                    table.ForeignKey(
                        name: "FKMachineFarm",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    TypeOfResource = table.Column<string>(type: "varchar(50)", nullable: true),
                    FarmId = table.Column<long>(type: "bigint(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resources", x => x.Id);
                    table.ForeignKey(
                        name: "FKResourceFarm",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "farm_tasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime", nullable: true),
                    EmployeeId = table.Column<long>(type: "bigint(19)", nullable: false),
                    FieldId = table.Column<long>(type: "bigint(19)", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farm_tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FKTaskCreator",
                        column: x => x.CreatorId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKTaskEmployee",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKTaskField",
                        column: x => x.FieldId,
                        principalTable: "fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "task_equipments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaskId = table.Column<long>(type: "bigint(19)", nullable: false),
                    MachineId = table.Column<long>(type: "bigint(19)", nullable: false),
                    ResourceId = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task_equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FKTaskEquipTask",
                        column: x => x.TaskId,
                        principalTable: "farm_tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKTaskEquipMachine",
                        column: x => x.MachineId,
                        principalTable: "machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKTaskEquipmResource",
                        column: x => x.ResourceId,
                        principalTable: "resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "workflow_tasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    WorkflowStatusName = table.Column<string>(type: "varchar(50)", nullable: true),
                    WorkflowStatusCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    WorkflowActionName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Symbol = table.Column<string>(type: "varchar(50)", nullable: true),
                    TaskId = table.Column<long>(type: "bigint(19)", nullable: false),
                    WorkflowStatusId = table.Column<int>(type: "int(10)", nullable: false),
                    WorkflowActionId = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workflow_tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FKWflTaskTask",
                        column: x => x.TaskId,
                        principalTable: "farm_tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKWflTaskWflAction",
                        column: x => x.WorkflowActionId,
                        principalTable: "workflow_actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKWflTaskWflStatus",
                        column: x => x.WorkflowStatusId,
                        principalTable: "workflow_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FKEmployeeUser",
                table: "employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_farm_tasks_CreatorId",
                table: "farm_tasks",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "FKTaskCreator",
                table: "farm_tasks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "FKTaskField",
                table: "farm_tasks",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "FKFarmEmployee",
                table: "farms",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "FKFieldFarm",
                table: "fields",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "FKMachineFarm",
                table: "machines",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "FKResourceFarm",
                table: "resources",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "FKTaskEquipTask",
                table: "task_equipments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "FKTaskEquipMachine",
                table: "task_equipments",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "FKTaskEquipmResource",
                table: "task_equipments",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_tokens_UserId",
                table: "tokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "FKUserRoleRole",
                table: "user_roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "FKUserRoleUser",
                table: "user_roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "FKUserCompany",
                table: "users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UsersUniqueEmail",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UsersUniqueUserName",
                table: "users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FKWflStatusActionWflAction",
                table: "workflow_status_actions",
                column: "WorkflowActionId");

            migrationBuilder.CreateIndex(
                name: "FKWflStatusActionWflCurrentStatus",
                table: "workflow_status_actions",
                column: "WorkflowCurrentStatusId");

            migrationBuilder.CreateIndex(
                name: "FKWflStatusActionWflTargetStatus",
                table: "workflow_status_actions",
                column: "WorkflowTargetStatusId");

            migrationBuilder.CreateIndex(
                name: "WflStatusesUniqueCode",
                table: "workflow_statuses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FKWflTaskTask",
                table: "workflow_tasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "FKWflTaskWflAction",
                table: "workflow_tasks",
                column: "WorkflowActionId");

            migrationBuilder.CreateIndex(
                name: "FKWflTaskWflStatus",
                table: "workflow_tasks",
                column: "WorkflowStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task_equipments");

            migrationBuilder.DropTable(
                name: "tokens");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "workflow_status_actions");

            migrationBuilder.DropTable(
                name: "workflow_tasks");

            migrationBuilder.DropTable(
                name: "machines");

            migrationBuilder.DropTable(
                name: "resources");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "farm_tasks");

            migrationBuilder.DropTable(
                name: "workflow_actions");

            migrationBuilder.DropTable(
                name: "workflow_statuses");

            migrationBuilder.DropTable(
                name: "fields");

            migrationBuilder.DropTable(
                name: "farms");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
