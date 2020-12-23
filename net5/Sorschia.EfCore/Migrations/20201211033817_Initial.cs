using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sorschia.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Module",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedById = table.Column<int>(type: "int", nullable: true),
                    InsertedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailAddressVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsPasswordChangeRequired = table.Column<bool>(type: "bit", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedById = table.Column<int>(type: "int", nullable: true),
                    InsertedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "dbo",
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_DeletedById",
                        column: x => x.DeletedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_InsertedById",
                        column: x => x.InsertedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedById = table.Column<int>(type: "int", nullable: true),
                    InsertedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application_User_DeletedById",
                        column: x => x.DeletedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_User_InsertedById",
                        column: x => x.InsertedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedById = table.Column<int>(type: "int", nullable: true),
                    InsertedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_User_DeletedById",
                        column: x => x.DeletedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_User_InsertedById",
                        column: x => x.InsertedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_DeletedById",
                schema: "dbo",
                table: "Application",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Application_InsertedById",
                schema: "dbo",
                table: "Application",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Application_UpdatedById",
                schema: "dbo",
                table: "Application",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Module_ApplicationId",
                schema: "dbo",
                table: "Module",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_DeletedById",
                schema: "dbo",
                table: "Module",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Module_InsertedById",
                schema: "dbo",
                table: "Module",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Module_UpdatedById",
                schema: "dbo",
                table: "Module",
                column: "UpdatedById");

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

            migrationBuilder.CreateIndex(
                name: "IX_Role_DeletedById",
                schema: "dbo",
                table: "Role",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Role_InsertedById",
                schema: "dbo",
                table: "Role",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UpdatedById",
                schema: "dbo",
                table: "Role",
                column: "UpdatedById");

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
                name: "IX_User_DeletedById",
                schema: "dbo",
                table: "User",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_User_InsertedById",
                schema: "dbo",
                table: "User",
                column: "InsertedById");

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
                name: "IX_User_UpdatedById",
                schema: "dbo",
                table: "User",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Application_ApplicationId",
                schema: "dbo",
                table: "Module",
                column: "ApplicationId",
                principalSchema: "dbo",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Module_User_DeletedById",
                schema: "dbo",
                table: "Module",
                column: "DeletedById",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Module_User_InsertedById",
                schema: "dbo",
                table: "Module",
                column: "InsertedById",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Module_User_UpdatedById",
                schema: "dbo",
                table: "Module",
                column: "UpdatedById",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_User_Role_RoleId",
                schema: "dbo",
                table: "User",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_User_DeletedById",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_User_InsertedById",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_User_UpdatedById",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_User_DeletedById",
                schema: "dbo",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_User_InsertedById",
                schema: "dbo",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_User_UpdatedById",
                schema: "dbo",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_User_UserId",
                schema: "dbo",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_User_UserId1",
                schema: "dbo",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_DeletedById",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_InsertedById",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UpdatedById",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UserId",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UserId1",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Application",
                schema: "dbo");
        }
    }
}
