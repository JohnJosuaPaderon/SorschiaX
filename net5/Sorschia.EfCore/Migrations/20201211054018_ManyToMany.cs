using Microsoft.EntityFrameworkCore.Migrations;

namespace Sorschia.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Module_User_UserId",
                schema: "dbo",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_User_UserId1",
                schema: "dbo",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UserId",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UserId1",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Module_ModuleId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ModuleId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserId",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserId1",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Module_UserId",
                schema: "dbo",
                table: "Module");

            migrationBuilder.DropIndex(
                name: "IX_Module_UserId1",
                schema: "dbo",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "dbo",
                table: "Module");

            migrationBuilder.CreateTable(
                name: "ModuleUser",
                schema: "dbo",
                columns: table => new
                {
                    ModulesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleUser", x => new { x.ModulesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ModuleUser_Module_ModulesId",
                        column: x => x.ModulesId,
                        principalSchema: "dbo",
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleUser_User_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                schema: "dbo",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Role_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_User_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleUser_UsersId",
                schema: "dbo",
                table: "ModuleUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                schema: "dbo",
                table: "RoleUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleUser",
                schema: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                schema: "dbo",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                schema: "dbo",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                schema: "dbo",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Module",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                schema: "dbo",
                table: "Module",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ModuleId",
                schema: "dbo",
                table: "User",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                schema: "dbo",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId",
                schema: "dbo",
                table: "Role",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId1",
                schema: "dbo",
                table: "Role",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Module_UserId",
                schema: "dbo",
                table: "Module",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_UserId1",
                schema: "dbo",
                table: "Module",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_User_UserId",
                schema: "dbo",
                table: "Module",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Module_User_UserId1",
                schema: "dbo",
                table: "Module",
                column: "UserId1",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_User_UserId",
                schema: "dbo",
                table: "Role",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_User_UserId1",
                schema: "dbo",
                table: "Role",
                column: "UserId1",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Module_ModuleId",
                schema: "dbo",
                table: "User",
                column: "ModuleId",
                principalSchema: "dbo",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                schema: "dbo",
                table: "User",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
