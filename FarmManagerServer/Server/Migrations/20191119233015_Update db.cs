using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WorkflowStatusId",
                table: "workflow_tasks",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint(19)");

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowActionId",
                table: "workflow_tasks",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint(19)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "workflow_statuses",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint(19)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowTargetStatusId",
                table: "workflow_status_actions",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint(19)");

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowCurrentStatusId",
                table: "workflow_status_actions",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint(19)");

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowActionId",
                table: "workflow_status_actions",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint(19)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "workflow_status_actions",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint(19)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "workflow_actions",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint(19)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ResourceId",
                table: "task_equipments",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint(19)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "resources",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint(19)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "WorkflowStatusId",
                table: "workflow_tasks",
                type: "bigint(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AlterColumn<long>(
                name: "WorkflowActionId",
                table: "workflow_tasks",
                type: "bigint(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "workflow_statuses",
                type: "bigint(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "WorkflowTargetStatusId",
                table: "workflow_status_actions",
                type: "bigint(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AlterColumn<long>(
                name: "WorkflowCurrentStatusId",
                table: "workflow_status_actions",
                type: "bigint(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AlterColumn<long>(
                name: "WorkflowActionId",
                table: "workflow_status_actions",
                type: "bigint(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "workflow_status_actions",
                type: "bigint(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "workflow_actions",
                type: "bigint(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "ResourceId",
                table: "task_equipments",
                type: "bigint(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "resources",
                type: "bigint(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
