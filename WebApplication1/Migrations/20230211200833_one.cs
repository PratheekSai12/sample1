using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Key = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "HomeStays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(name: "Property_Name", type: "nvarchar(max)", nullable: false),
                    PropertyAddress = table.Column<string>(name: "Property_Address", type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<string>(name: "Property_Type", type: "nvarchar(max)", nullable: false),
                    PropertyContact = table.Column<string>(name: "Property_Contact", type: "nvarchar(max)", nullable: false),
                    NoofRooms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pics = table.Column<byte[][]>(type: "varbinary(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeStays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeStays_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hosts_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "Questionaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passionate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hobbies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accomplishment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Life = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalExpertise = table.Column<string>(name: "Personal_Expertise", type: "nvarchar(max)", nullable: false),
                    ProfessionalExpertise = table.Column<string>(name: "Professional_Expertise", type: "nvarchar(max)", nullable: false),
                    WhatsLife = table.Column<string>(name: "Whats_Life", type: "nvarchar(max)", nullable: false),
                    Travel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Offer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KindofGuests = table.Column<string>(name: "Kindof_Guests", type: "nvarchar(max)", nullable: false),
                    GreatestImpact = table.Column<string>(name: "Greatest_Impact", type: "nvarchar(max)", nullable: false),
                    CherishedMemories = table.Column<string>(name: "Cherished_Memories", type: "nvarchar(max)", nullable: false),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournerDestination = table.Column<string>(name: "Journer_Destination", type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questionaries_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserName",
                table: "Customers",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_HomeStays_UserName",
                table: "HomeStays",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_UserName",
                table: "Hosts",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Questionaries_UserName",
                table: "Questionaries",
                column: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "HomeStays");

            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropTable(
                name: "Questionaries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
