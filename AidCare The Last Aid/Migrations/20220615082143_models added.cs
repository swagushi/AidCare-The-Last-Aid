using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AidCare_The_Last_Aid.Migrations
{
    public partial class modelsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "donation",
                columns: table => new
                {
                    donationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonationAmount = table.Column<int>(type: "int", nullable: false),
                    memberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donation", x => x.donationId);
                    table.ForeignKey(
                        name: "FK_donation_member_memberId",
                        column: x => x.memberId,
                        principalTable: "member",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "memberevent",
                columns: table => new
                {
                    membereventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    membereventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRegistered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    memberId = table.Column<int>(type: "int", nullable: false),
                    eventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberevent", x => x.membereventId);
                    table.ForeignKey(
                        name: "FK_memberevent_Event_eventId",
                        column: x => x.eventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_memberevent_member_memberId",
                        column: x => x.memberId,
                        principalTable: "member",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donation_memberId",
                table: "donation",
                column: "memberId");

            migrationBuilder.CreateIndex(
                name: "IX_memberevent_eventId",
                table: "memberevent",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_memberevent_memberId",
                table: "memberevent",
                column: "memberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donation");

            migrationBuilder.DropTable(
                name: "memberevent");

            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
