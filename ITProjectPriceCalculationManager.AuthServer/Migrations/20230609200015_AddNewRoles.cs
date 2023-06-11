using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectPriceCalculationManager.AuthServer.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO dbo.AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
                                VALUES (
                                    'e5700a0b-773b-4bc3-a3ab-c945f862f045',
                                    'Evaluator',
                                    'EVALUATOR',
                                    '70d437d0-1515-4671-a517-4879e2509071'
                                );");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
