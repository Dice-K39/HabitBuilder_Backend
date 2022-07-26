using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitBuilder_Backend.Migrations
{
    public partial class include_stored_procedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitRewards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HabitRewards",
                columns: table => new
                {
                    HabitId = table.Column<int>(type: "int", nullable: false),
                    RewardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitRewards", x => new { x.HabitId, x.RewardId });
                    table.ForeignKey(
                        name: "FK_HabitRewards_Habits_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabitRewards_Rewards_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Rewards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitRewards_RewardId",
                table: "HabitRewards",
                column: "RewardId");
        }
    }
}
