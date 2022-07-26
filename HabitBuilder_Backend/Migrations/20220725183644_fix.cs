using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitBuilder_Backend.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitReward_Habits_RewardId",
                table: "HabitReward");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitReward_Rewards_HabitId",
                table: "HabitReward");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HabitReward",
                table: "HabitReward");

            migrationBuilder.RenameTable(
                name: "HabitReward",
                newName: "HabitRewards");

            migrationBuilder.RenameIndex(
                name: "IX_HabitReward_RewardId",
                table: "HabitRewards",
                newName: "IX_HabitRewards_RewardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HabitRewards",
                table: "HabitRewards",
                columns: new[] { "HabitId", "RewardId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HabitRewards_Habits_RewardId",
                table: "HabitRewards",
                column: "RewardId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HabitRewards_Rewards_HabitId",
                table: "HabitRewards",
                column: "HabitId",
                principalTable: "Rewards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitRewards_Habits_RewardId",
                table: "HabitRewards");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitRewards_Rewards_HabitId",
                table: "HabitRewards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HabitRewards",
                table: "HabitRewards");

            migrationBuilder.RenameTable(
                name: "HabitRewards",
                newName: "HabitReward");

            migrationBuilder.RenameIndex(
                name: "IX_HabitRewards_RewardId",
                table: "HabitReward",
                newName: "IX_HabitReward_RewardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HabitReward",
                table: "HabitReward",
                columns: new[] { "HabitId", "RewardId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HabitReward_Habits_RewardId",
                table: "HabitReward",
                column: "RewardId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HabitReward_Rewards_HabitId",
                table: "HabitReward",
                column: "HabitId",
                principalTable: "Rewards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
