using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamikFullstackChallengeAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovedStack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stack",
                table: "Developers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Stack",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
