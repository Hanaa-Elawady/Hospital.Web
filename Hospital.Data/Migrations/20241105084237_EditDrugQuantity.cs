using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
	/// <inheritdoc />
	public partial class EditDrugQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Medications",
                table: "TreatmentPlans");

            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantityInStock",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TreatmentPlanId",
                table: "Drugs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_TreatmentPlanId",
                table: "Drugs",
                column: "TreatmentPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_TreatmentPlans_TreatmentPlanId",
                table: "Drugs",
                column: "TreatmentPlanId",
                principalTable: "TreatmentPlans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_TreatmentPlans_TreatmentPlanId",
                table: "Drugs");

            migrationBuilder.DropIndex(
                name: "IX_Drugs_TreatmentPlanId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "AvailableQuantityInStock",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "TreatmentPlanId",
                table: "Drugs");

            migrationBuilder.AddColumn<string>(
                name: "Medications",
                table: "TreatmentPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
