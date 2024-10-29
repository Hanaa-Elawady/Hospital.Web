using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditNullableValuesForSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_DrugTypes_DrugTypeID",
                table: "Drugs");

            migrationBuilder.AlterColumn<int>(
                name: "DrugTypeID",
                table: "Drugs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_DrugTypes_DrugTypeID",
                table: "Drugs",
                column: "DrugTypeID",
                principalTable: "DrugTypes",
                principalColumn: "DrugTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_DrugTypes_DrugTypeID",
                table: "Drugs");

            migrationBuilder.AlterColumn<int>(
                name: "DrugTypeID",
                table: "Drugs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_DrugTypes_DrugTypeID",
                table: "Drugs",
                column: "DrugTypeID",
                principalTable: "DrugTypes",
                principalColumn: "DrugTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
