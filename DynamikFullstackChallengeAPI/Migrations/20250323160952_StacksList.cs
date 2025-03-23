using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamikFullstackChallengeAPI.Migrations
{
    /// <inheritdoc />
    public partial class StacksList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stack_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stack_DeveloperId",
                table: "Stack",
                column: "DeveloperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stack");
        }
    }
}
