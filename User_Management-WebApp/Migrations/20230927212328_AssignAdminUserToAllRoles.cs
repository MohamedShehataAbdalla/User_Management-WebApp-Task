using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User_Management_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AssignAdminUserToAllRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Identity].[UserRoles] (UserId, RoleId) SELECT '8e6bbc52-45ee-4063-9271-523b57c75680', Id FROM [Identity].[Roles]");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Identity].[UserRoles] WHERE UserId = '8e6bbc52-45ee-4063-9271-523b57c75680'");

        }
    }
}
