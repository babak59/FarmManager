using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Addrefreshtokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "workflow_statuses",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "workflow_status_actions",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "workflow_actions",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "resources",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(19)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(70)", nullable: false),
                    Token = table.Column<string>(type: "varchar(32)", nullable: false),
                    ValidTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IpAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IDXRefreshTokenToken",
                table: "RefreshTokens",
                column: "Token");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "workflow_statuses",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "workflow_status_actions",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "workflow_actions",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "resources",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
