using Microsoft.EntityFrameworkCore.Migrations;

namespace TadbirPardazPreTest.Persistance.Migrations
{
    public partial class createSpForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create procedure [dbo].[EditUser]

                                                            @Id UniqueIdentifier,
                                                            @Username Nvarchar(50),
                                                            @FirstName Nvarchar(50),
                                                            @LastName Nvarchar(50),
                                                            @Email Nvarchar(50),
                                                            @PhoneNumber Nvarchar(50)
                                                        as
                                                        begin
                                                        update  Users
                                                        set username = @Username,
                                                        FirstName = @FirstName,
                                                        LastName = @LastName,
                                                        Email = @Email,
                                                        PhoneNumber = @PhoneNumber
                                                        where id = @Id
                                                        end");

            migrationBuilder.Sql(@"create procedure [dbo].[AddUser]
	                                @Id UniqueIdentifier,
	                                @Username Nvarchar(50),
	                                @FirstName Nvarchar(50),
	                                @LastName Nvarchar(50),
	                                @Email Nvarchar(50),
	                                @PhoneNumber Nvarchar(50)
                                as
                                begin
                                insert Into Users(Id,username,FirstName,LastName,Email,PhoneNumber)
	                                values(@Id,@Username,@FirstName,@LastName,@Email,@PhoneNumber)
                                end");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[AddUser]");   
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[EditUser]");
        }
    }
}
