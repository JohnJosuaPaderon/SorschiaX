using Microsoft.EntityFrameworkCore.Migrations;

namespace Sorschia.Migrations
{
    public partial class ApplicationPlatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RoleUser",
                newName: "RoleUser",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ModuleUser",
                newName: "ModuleUser",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Platform",
                schema: "dbo",
                table: "Application",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RoleUser",
                schema: "dbo",
                newName: "RoleUser");

            migrationBuilder.RenameTable(
                name: "ModuleUser",
                schema: "dbo",
                newName: "ModuleUser");

            migrationBuilder.AlterColumn<int>(
                name: "Platform",
                schema: "dbo",
                table: "Application",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
