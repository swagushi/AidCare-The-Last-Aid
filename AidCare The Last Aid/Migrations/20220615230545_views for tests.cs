using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AidCare_The_Last_Aid.Migrations
{
    public partial class viewsfortests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "donationtest",
                columns: table => new
                {
                    donationtestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonationAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donationtest", x => x.donationtestId);
                });

            migrationBuilder.CreateTable(
                name: "EventTest",
                columns: table => new
                {
                    EventTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTest", x => x.EventTestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donationtest");

            migrationBuilder.DropTable(
                name: "EventTest");
        }
    }
}
