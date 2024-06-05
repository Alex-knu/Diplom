using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Migrations
{
    /// <inheritdoc />
    public partial class FixInitRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "EvaluateParameter");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "Parameters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Parameters");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "EvaluateParameter",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
