using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitBuilder_Backend.Migrations
{
    public partial class add_habitrewardtableforreallyreal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HabitRewards_HabitId",
                table: "HabitRewards",
                column: "HabitId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitRewards_RewardId",
                table: "HabitRewards",
                column: "RewardId");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitRewards_Habits_HabitId",
                table: "HabitRewards",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HabitRewards_Rewards_RewardId",
                table: "HabitRewards",
                column: "RewardId",
                principalTable: "Rewards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitRewards_Habits_HabitId",
                table: "HabitRewards");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitRewards_Rewards_RewardId",
                table: "HabitRewards");

            migrationBuilder.DropIndex(
                name: "IX_HabitRewards_HabitId",
                table: "HabitRewards");

            migrationBuilder.DropIndex(
                name: "IX_HabitRewards_RewardId",
                table: "HabitRewards");
        }
    }
}
