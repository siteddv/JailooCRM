using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JailooCRM.DAL.Migrations
{
    public partial class extendLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Values",
                table: "Logs");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Logs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Logs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExceptionMessage",
                table: "Logs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExceptionSource",
                table: "Logs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExceptionStackTrace",
                table: "Logs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Logs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThreadId",
                table: "Logs",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ExceptionMessage",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ExceptionSource",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ExceptionStackTrace",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ThreadId",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "Values",
                table: "Logs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
