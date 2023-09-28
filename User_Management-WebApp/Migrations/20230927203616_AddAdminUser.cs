using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User_Management_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Identity].[Users] ([Id] ,[First_Name] ,[Last_Name] ,[Bio] ,[Image] ,[Gender] ,[DateOfBirth] ,[Active] ,[CreatedBy] ,[CreatedAt] ,[UpdatedAt] ,[DeletedAt] ,[UserName] ,[NormalizedUserName] ,[Email] ,[NormalizedEmail] ,[EmailConfirmed] ,[PasswordHash] ,[SecurityStamp] ,[ConcurrencyStamp] ,[PhoneNumber] ,[TwoFactorEnabled] ,[LockoutEnd] ,[LockoutEnabled] ,[AccessFailedCount]) VALUES (N'8e6bbc52-45ee-4063-9271-523b57c75680' ,N'Mohamed' ,N'Sheheta' ,null ,null ,1 ,'1990-01-01' ,1 ,null ,GETDATE() ,null ,null ,N'admin' ,N'ADMIN' ,N'admin@domin.com' ,N'ADMIN@DOMIN.COM' ,1 ,N'AQAAAAIAAYagAAAAEPj/ZZfhi+F0Zdp7YD6N91U17GDOyUGY29QWiuet9xkn3vzIoo/kUPdybEhmMDohKw==' ,N'ZKHQLKZMOM3JJXOJ2ELXDLOPYBPLXGI5' ,N'4b72312a-29db-40a9-9eb6-58f5e39c9a84' ,NULL ,0 ,NULL ,1 ,0)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Identity].[Users] WHERE Id = '8e6bbc52-45ee-4063-9271-523b57c75680'");

        }
    }
}
