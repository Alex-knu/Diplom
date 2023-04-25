using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Migrations
{
    /// <inheritdoc />
    public partial class AddNewModelsWithGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Estimators_CreatorId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationToEstimators_Estimators_EstimatorId",
                table: "ApplicationToEstimators");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_ParentId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Estimators_Departments_DepartmentId",
                table: "Estimators");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Attributes_AttributeId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Estimators_EstimatorId",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estimators",
                table: "Estimators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "Profile");

            migrationBuilder.RenameTable(
                name: "Estimators",
                newName: "Estimator");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Attributes",
                newName: "Attribute");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_EstimatorId",
                table: "Profile",
                newName: "IX_Profile_EstimatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_AttributeId",
                table: "Profile",
                newName: "IX_Profile_AttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_Estimators_DepartmentId",
                table: "Estimator",
                newName: "IX_Estimator_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_ParentId",
                table: "Department",
                newName: "IX_Department_ParentId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Estimator",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Estimator",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Department",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estimator",
                table: "Estimator",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attribute",
                table: "Attribute",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Estimator_CreatorId",
                table: "Applications",
                column: "CreatorId",
                principalTable: "Estimator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationToEstimators_Estimator_EstimatorId",
                table: "ApplicationToEstimators",
                column: "EstimatorId",
                principalTable: "Estimator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Department_ParentId",
                table: "Department",
                column: "ParentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estimator_Department_DepartmentId",
                table: "Estimator",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Attribute_AttributeId",
                table: "Profile",
                column: "AttributeId",
                principalTable: "Attribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Estimator_EstimatorId",
                table: "Profile",
                column: "EstimatorId",
                principalTable: "Estimator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Estimator_CreatorId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationToEstimators_Estimator_EstimatorId",
                table: "ApplicationToEstimators");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Department_ParentId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Estimator_Department_DepartmentId",
                table: "Estimator");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Attribute_AttributeId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Estimator_EstimatorId",
                table: "Profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estimator",
                table: "Estimator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attribute",
                table: "Attribute");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "Profiles");

            migrationBuilder.RenameTable(
                name: "Estimator",
                newName: "Estimators");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Attribute",
                newName: "Attributes");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_EstimatorId",
                table: "Profiles",
                newName: "IX_Profiles_EstimatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_AttributeId",
                table: "Profiles",
                newName: "IX_Profiles_AttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_Estimator_DepartmentId",
                table: "Estimators",
                newName: "IX_Estimators_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Department_ParentId",
                table: "Departments",
                newName: "IX_Departments_ParentId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Estimators",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Estimators",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Departments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estimators",
                table: "Estimators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Estimators_CreatorId",
                table: "Applications",
                column: "CreatorId",
                principalTable: "Estimators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationToEstimators_Estimators_EstimatorId",
                table: "ApplicationToEstimators",
                column: "EstimatorId",
                principalTable: "Estimators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_ParentId",
                table: "Departments",
                column: "ParentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estimators_Departments_DepartmentId",
                table: "Estimators",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Attributes_AttributeId",
                table: "Profiles",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Estimators_EstimatorId",
                table: "Profiles",
                column: "EstimatorId",
                principalTable: "Estimators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
