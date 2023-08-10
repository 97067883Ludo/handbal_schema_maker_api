using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HandbalSchemaMaker.Migrations
{
    /// <inheritdoc />
    public partial class addedmatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MatchNumber = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false),
                    HomeTeam = table.Column<string>(type: "text", nullable: false),
                    OutTeam = table.Column<string>(type: "text", nullable: false),
                    Referee1 = table.Column<string>(type: "text", nullable: true),
                    Referee2 = table.Column<string>(type: "text", nullable: true),
                    TableService = table.Column<string>(type: "text", nullable: true),
                    Field = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");
        }
    }
}
