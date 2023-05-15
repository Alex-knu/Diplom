using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationToFactors_Attributes_FactorId",
                table: "ApplicationToFactors");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationToFactors_DifficultyLevelsTypes_DifficultyLevelId",
                table: "ApplicationToFactors");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationToFactors_FactorTypes_FactorTypeId",
                table: "ApplicationToFactors");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationToFactors_DifficultyLevelId",
                table: "ApplicationToFactors");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationToFactors_FactorId",
                table: "ApplicationToFactors");

            migrationBuilder.DropColumn(
                name: "DifficultyLevelId",
                table: "ApplicationToFactors");

            migrationBuilder.DropColumn(
                name: "FactorId",
                table: "ApplicationToFactors");

            migrationBuilder.RenameColumn(
                name: "FactorTypeId",
                table: "ApplicationToFactors",
                newName: "DifficultyLevelsTypeToFactorTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationToFactors_FactorTypeId",
                table: "ApplicationToFactors",
                newName: "IX_ApplicationToFactors_DifficultyLevelsTypeToFactorTypeId");

            migrationBuilder.AddColumn<int>(
                name: "FactorId",
                table: "DifficultyLevelsTypeToFactorTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Qualifications(PERS)" },
                    { 2, "Experience(PREX)" },
                    { 3, "Technical support(FCIL)" },
                    { 4, "Schedule restrictions(SCED)" },
                    { 5, "Complexity of the program environment(PDIF)" },
                    { 6, "Complexity and reliability(RCPX)" },
                    { 7, "Reuse requested(RUSE)" },
                    { 8, "Product novelty for the developer's company(PREC)" },
                    { 9, "Development flexibility(FLEX)" },
                    { 10, "Level of risk/architecture management (%)(RESL)" },
                    { 11, "Cohesion of the development team(TEAM)" },
                    { 12, "Technology maturity maturity process development(PMAT)" },
                    { 13, "Internal logical object" },
                    { 14, "External interface object" },
                    { 15, "External input" },
                    { 16, "External output" },
                    { 17, "External request" }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevelsTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Super low" },
                    { 2, "Very low" },
                    { 3, "Low" },
                    { 4, "Normal" },
                    { 5, "Medium" },
                    { 6, "High" },
                    { 7, "Very high" },
                    { 8, "Super high" }
                });

            migrationBuilder.InsertData(
                table: "FactorTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Influence factor" },
                    { 2, "Scale factor" },
                    { 3, "Information object" },
                    { 4, "Function" }
                });

            migrationBuilder.InsertData(
                table: "ProgramLanguages",
                columns: new[] { "Id", "Name", "SLOC" },
                values: new object[,]
                {
                    { 1, "ABAP (SAP)", 28 },
                    { 2, "ASP", 51 },
                    { 3, "Assembler", 119 },
                    { 4, "Brio +", 14 },
                    { 5, "C", 97 },
                    { 6, "C++", 50 },
                    { 7, "C#", 54 },
                    { 8, "COBOL", 61 },
                    { 9, "Cognos Impromptu Scripts +", 47 },
                    { 10, "Cross System Products (CSP) +", 20 },
                    { 11, "Cool:Gen/IEF", 32 },
                    { 12, "Datastage", 71 },
                    { 13, "Excel", 209 },
                    { 14, "Focus", 43 },
                    { 15, "FoxPro", 36 },
                    { 16, "HTML", 34 },
                    { 17, "J2EE", 46 },
                    { 18, "Java", 53 },
                    { 19, "JavaScript", 47 },
                    { 20, "JCL", 62 },
                    { 21, "LINC II", 29 },
                    { 22, "Lotus Notes", 23 },
                    { 23, "Natural", 40 },
                    { 24, ".NET", 57 },
                    { 25, "Oracle", 37 }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevelsTypeToFactorTypes",
                columns: new[] { "Id", "DifficultyLevelId", "FactorId", "FactorTypeId", "Value" },
                values: new object[,]
                {
                    { 1, 3, 13, 3, 7.0 },
                    { 2, 5, 13, 3, 10.0 },
                    { 3, 6, 13, 3, 15.0 },
                    { 4, 3, 14, 3, 5.0 },
                    { 5, 5, 14, 3, 7.0 },
                    { 6, 6, 14, 3, 10.0 },
                    { 7, 1, 1, 1, 2.1200000000000001 },
                    { 8, 2, 1, 1, 1.6200000000000001 },
                    { 9, 3, 1, 1, 1.26 },
                    { 10, 4, 1, 1, 1.0 },
                    { 11, 6, 1, 1, 0.82999999999999996 },
                    { 12, 7, 1, 1, 0.63 },
                    { 13, 8, 1, 1, 0.5 },
                    { 14, 1, 2, 1, 1.5900000000000001 },
                    { 15, 2, 2, 1, 1.3300000000000001 },
                    { 16, 3, 2, 1, 1.1200000000000001 },
                    { 17, 4, 2, 1, 1.0 },
                    { 18, 6, 2, 1, 0.87 },
                    { 19, 7, 2, 1, 0.70999999999999996 },
                    { 20, 8, 2, 1, 0.62 },
                    { 21, 1, 3, 1, 1.4299999999999999 },
                    { 22, 2, 3, 1, 1.3 },
                    { 23, 3, 3, 1, 1.1000000000000001 },
                    { 24, 4, 3, 1, 1.0 },
                    { 25, 6, 3, 1, 0.87 },
                    { 26, 7, 3, 1, 0.72999999999999998 },
                    { 27, 8, 3, 1, 0.62 },
                    { 28, 1, 4, 1, 0.0 },
                    { 29, 2, 4, 1, 1.4299999999999999 },
                    { 30, 3, 4, 1, 1.1399999999999999 },
                    { 31, 4, 4, 1, 1.0 },
                    { 32, 6, 4, 1, 1.0 },
                    { 33, 7, 4, 1, 1.0 },
                    { 34, 8, 4, 1, 0.0 },
                    { 35, 1, 5, 1, 0.0 },
                    { 36, 2, 5, 1, 0.0 },
                    { 37, 3, 5, 1, 0.87 },
                    { 38, 4, 5, 1, 1.0 },
                    { 39, 6, 5, 1, 1.29 },
                    { 40, 7, 5, 1, 1.8100000000000001 },
                    { 41, 8, 5, 1, 2.6099999999999999 },
                    { 42, 1, 6, 1, 0.48999999999999999 },
                    { 43, 2, 6, 1, 0.59999999999999998 },
                    { 44, 3, 6, 1, 0.82999999999999996 },
                    { 45, 4, 6, 1, 1.0 },
                    { 46, 6, 6, 1, 1.3300000000000001 },
                    { 47, 7, 6, 1, 1.97 },
                    { 48, 8, 6, 1, 2.7200000000000002 },
                    { 49, 1, 7, 1, 0.0 },
                    { 50, 2, 7, 1, 0.0 },
                    { 51, 3, 7, 1, 0.94999999999999996 },
                    { 52, 4, 7, 1, 1.0 },
                    { 53, 6, 7, 1, 1.0700000000000001 },
                    { 54, 7, 7, 1, 1.1499999999999999 },
                    { 55, 8, 7, 1, 1.24 },
                    { 56, 2, 8, 2, 6.2000000000000002 },
                    { 57, 3, 8, 2, 4.96 },
                    { 58, 4, 8, 2, 3.7200000000000002 },
                    { 59, 6, 8, 2, 2.48 },
                    { 60, 7, 8, 2, 1.24 },
                    { 61, 8, 8, 2, 0.0 },
                    { 62, 2, 9, 2, 5.0700000000000003 },
                    { 63, 3, 9, 2, 4.0499999999999998 },
                    { 64, 4, 9, 2, 3.04 },
                    { 65, 6, 9, 2, 2.0299999999999998 },
                    { 66, 7, 9, 2, 1.01 },
                    { 67, 8, 9, 2, 0.0 },
                    { 68, 2, 10, 2, 7.0700000000000003 },
                    { 69, 3, 10, 2, 5.6500000000000004 },
                    { 70, 4, 10, 2, 4.2400000000000002 },
                    { 71, 6, 10, 2, 2.8300000000000001 },
                    { 72, 7, 10, 2, 1.4099999999999999 },
                    { 73, 8, 10, 2, 0.0 },
                    { 74, 2, 11, 2, 5.4800000000000004 },
                    { 75, 3, 11, 2, 4.3799999999999999 },
                    { 76, 4, 11, 2, 3.29 },
                    { 77, 6, 11, 2, 2.1899999999999999 },
                    { 78, 7, 11, 2, 1.1000000000000001 },
                    { 79, 8, 11, 2, 0.0 },
                    { 80, 2, 12, 2, 7.7999999999999998 },
                    { 81, 3, 12, 2, 6.2400000000000002 },
                    { 82, 4, 12, 2, 4.6799999999999997 },
                    { 83, 6, 12, 2, 3.1200000000000001 },
                    { 84, 7, 12, 2, 1.5600000000000001 },
                    { 85, 8, 12, 2, 0.0 },
                    { 86, 3, 15, 4, 3.0 },
                    { 87, 5, 15, 4, 4.0 },
                    { 88, 6, 15, 4, 6.0 },
                    { 89, 3, 16, 4, 4.0 },
                    { 90, 5, 16, 4, 5.0 },
                    { 91, 6, 16, 4, 7.0 },
                    { 92, 3, 17, 4, 3.0 },
                    { 93, 3, 17, 4, 4.0 },
                    { 94, 3, 17, 4, 6.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyLevelsTypeToFactorTypes_FactorId",
                table: "DifficultyLevelsTypeToFactorTypes",
                column: "FactorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationToFactors_DifficultyLevelsTypeToFactorTypes_Diff~",
                table: "ApplicationToFactors",
                column: "DifficultyLevelsTypeToFactorTypeId",
                principalTable: "DifficultyLevelsTypeToFactorTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DifficultyLevelsTypeToFactorTypes_Attributes_FactorId",
                table: "DifficultyLevelsTypeToFactorTypes",
                column: "FactorId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationToFactors_DifficultyLevelsTypeToFactorTypes_Diff~",
                table: "ApplicationToFactors");

            migrationBuilder.DropForeignKey(
                name: "FK_DifficultyLevelsTypeToFactorTypes_Attributes_FactorId",
                table: "DifficultyLevelsTypeToFactorTypes");

            migrationBuilder.DropIndex(
                name: "IX_DifficultyLevelsTypeToFactorTypes_FactorId",
                table: "DifficultyLevelsTypeToFactorTypes");

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypeToFactorTypes",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProgramLanguages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DifficultyLevelsTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FactorTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FactorTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FactorTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FactorTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "FactorId",
                table: "DifficultyLevelsTypeToFactorTypes");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelsTypeToFactorTypeId",
                table: "ApplicationToFactors",
                newName: "FactorTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationToFactors_DifficultyLevelsTypeToFactorTypeId",
                table: "ApplicationToFactors",
                newName: "IX_ApplicationToFactors_FactorTypeId");

            migrationBuilder.AddColumn<int>(
                name: "DifficultyLevelId",
                table: "ApplicationToFactors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FactorId",
                table: "ApplicationToFactors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationToFactors_DifficultyLevelId",
                table: "ApplicationToFactors",
                column: "DifficultyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationToFactors_FactorId",
                table: "ApplicationToFactors",
                column: "FactorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationToFactors_Attributes_FactorId",
                table: "ApplicationToFactors",
                column: "FactorId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationToFactors_DifficultyLevelsTypes_DifficultyLevelId",
                table: "ApplicationToFactors",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevelsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationToFactors_FactorTypes_FactorTypeId",
                table: "ApplicationToFactors",
                column: "FactorTypeId",
                principalTable: "FactorTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
