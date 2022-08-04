using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitBuilder_Backend.Migrations
{
    public partial class GetAlluserHabitIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE getAlluserHabitIds
                                        AS
                                        BEGIN

                                        SELECT ID,UserID,HabitId from UserHabit
                                        INSERT INTO UserHabit( UserId )
                                           SELECT  Id
                                            FROM    AspNetUsers


                                        END";
            migrationBuilder.Sql(procedure);

        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

            string procedure = @"DROP PROCEDURE getAlluserHabitIds"; 
            migrationBuilder.Sql(procedure);
        }
    }
}
