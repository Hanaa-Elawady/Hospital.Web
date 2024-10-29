using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingDrugStoreTablesAndEditMedicalFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examination_Doctors_DoctorId",
                table: "Examination");

            migrationBuilder.DropForeignKey(
                name: "FK_Examination_MedicalFile_MedicalFileId",
                table: "Examination");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalFile_Doctors_DoctorId",
                table: "MedicalFile");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalFile_Patient_PatientId",
                table: "MedicalFile");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Addresses_AddressId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Departments_DepartmentId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlan_Doctors_DoctorId",
                table: "TreatmentPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlan_MedicalFile_MedicalFileId",
                table: "TreatmentPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlan_Report_ReportId",
                table: "TreatmentPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_VitalSigns_MedicalFile_MedicalFileId",
                table: "VitalSigns");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "XRay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreatmentPlan",
                table: "TreatmentPlan");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentPlan_ReportId",
                table: "TreatmentPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalFile",
                table: "MedicalFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Examination",
                table: "Examination");

            migrationBuilder.RenameTable(
                name: "TreatmentPlan",
                newName: "TreatmentPlans");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "MedicalFile",
                newName: "MedicalFiles");

            migrationBuilder.RenameTable(
                name: "Examination",
                newName: "Examinations");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentPlan_MedicalFileId",
                table: "TreatmentPlans",
                newName: "IX_TreatmentPlans_MedicalFileId");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentPlan_DoctorId",
                table: "TreatmentPlans",
                newName: "IX_TreatmentPlans_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_DepartmentId",
                table: "Patients",
                newName: "IX_Patients_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_AddressId",
                table: "Patients",
                newName: "IX_Patients_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalFile_PatientId",
                table: "MedicalFiles",
                newName: "IX_MedicalFiles_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalFile_DoctorId",
                table: "MedicalFiles",
                newName: "IX_MedicalFiles_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Examination_MedicalFileId",
                table: "Examinations",
                newName: "IX_Examinations_MedicalFileId");

            migrationBuilder.RenameIndex(
                name: "IX_Examination_DoctorId",
                table: "Examinations",
                newName: "IX_Examinations_DoctorId");

            migrationBuilder.AlterColumn<int>(
                name: "ExaminationType",
                table: "Examinations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreatmentPlans",
                table: "TreatmentPlans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalFiles",
                table: "MedicalFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examinations",
                table: "Examinations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DrugTypes",
                columns: table => new
                {
                    DrugTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugTypes", x => x.DrugTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DrugTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.DrugID);
                    table.ForeignKey(
                        name: "FK_Drugs_DrugTypes_DrugTypeID",
                        column: x => x.DrugTypeID,
                        principalTable: "DrugTypes",
                        principalColumn: "DrugTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    ReorderLevel = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventories_Drugs_DrugID",
                        column: x => x.DrugID,
                        principalTable: "Drugs",
                        principalColumn: "DrugID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    DrugID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Drugs_DrugID",
                        column: x => x.DrugID,
                        principalTable: "Drugs",
                        principalColumn: "DrugID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_DrugTypeID",
                table: "Drugs",
                column: "DrugTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_DrugID",
                table: "Inventories",
                column: "DrugID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DrugID",
                table: "OrderDetails",
                column: "DrugID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SupplierID",
                table: "Orders",
                column: "SupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Doctors_DoctorId",
                table: "Examinations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_MedicalFiles_MedicalFileId",
                table: "Examinations",
                column: "MedicalFileId",
                principalTable: "MedicalFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalFiles_Doctors_DoctorId",
                table: "MedicalFiles",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalFiles_Patients_PatientId",
                table: "MedicalFiles",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Addresses_AddressId",
                table: "Patients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Departments_DepartmentId",
                table: "Patients",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlans_Doctors_DoctorId",
                table: "TreatmentPlans",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlans_MedicalFiles_MedicalFileId",
                table: "TreatmentPlans",
                column: "MedicalFileId",
                principalTable: "MedicalFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VitalSigns_MedicalFiles_MedicalFileId",
                table: "VitalSigns",
                column: "MedicalFileId",
                principalTable: "MedicalFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Doctors_DoctorId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_MedicalFiles_MedicalFileId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalFiles_Doctors_DoctorId",
                table: "MedicalFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalFiles_Patients_PatientId",
                table: "MedicalFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Addresses_AddressId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Departments_DepartmentId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlans_Doctors_DoctorId",
                table: "TreatmentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlans_MedicalFiles_MedicalFileId",
                table: "TreatmentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_VitalSigns_MedicalFiles_MedicalFileId",
                table: "VitalSigns");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DrugTypes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreatmentPlans",
                table: "TreatmentPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalFiles",
                table: "MedicalFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Examinations",
                table: "Examinations");

            migrationBuilder.RenameTable(
                name: "TreatmentPlans",
                newName: "TreatmentPlan");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameTable(
                name: "MedicalFiles",
                newName: "MedicalFile");

            migrationBuilder.RenameTable(
                name: "Examinations",
                newName: "Examination");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentPlans_MedicalFileId",
                table: "TreatmentPlan",
                newName: "IX_TreatmentPlan_MedicalFileId");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentPlans_DoctorId",
                table: "TreatmentPlan",
                newName: "IX_TreatmentPlan_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_DepartmentId",
                table: "Patient",
                newName: "IX_Patient_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_AddressId",
                table: "Patient",
                newName: "IX_Patient_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalFiles_PatientId",
                table: "MedicalFile",
                newName: "IX_MedicalFile_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalFiles_DoctorId",
                table: "MedicalFile",
                newName: "IX_MedicalFile_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Examinations_MedicalFileId",
                table: "Examination",
                newName: "IX_Examination_MedicalFileId");

            migrationBuilder.RenameIndex(
                name: "IX_Examinations_DoctorId",
                table: "Examination",
                newName: "IX_Examination_DoctorId");

            migrationBuilder.AlterColumn<string>(
                name: "ExaminationType",
                table: "Examination",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreatmentPlan",
                table: "TreatmentPlan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalFile",
                table: "MedicalFile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examination",
                table: "Examination",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId1 = table.Column<long>(type: "bigint", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    MedicalFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Report_Doctors_DoctorId1",
                        column: x => x.DoctorId1,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_MedicalFile_MedicalFileId",
                        column: x => x.MedicalFileId,
                        principalTable: "MedicalFile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_MedicalFile_MedicalFileId",
                        column: x => x.MedicalFileId,
                        principalTable: "MedicalFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XRay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XRay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XRay_MedicalFile_MedicalFileId",
                        column: x => x.MedicalFileId,
                        principalTable: "MedicalFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlan_ReportId",
                table: "TreatmentPlan",
                column: "ReportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Report_DoctorId1",
                table: "Report",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Report_MedicalFileId",
                table: "Report",
                column: "MedicalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_MedicalFileId",
                table: "Test",
                column: "MedicalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_XRay_MedicalFileId",
                table: "XRay",
                column: "MedicalFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_Doctors_DoctorId",
                table: "Examination",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_MedicalFile_MedicalFileId",
                table: "Examination",
                column: "MedicalFileId",
                principalTable: "MedicalFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalFile_Doctors_DoctorId",
                table: "MedicalFile",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalFile_Patient_PatientId",
                table: "MedicalFile",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Addresses_AddressId",
                table: "Patient",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Departments_DepartmentId",
                table: "Patient",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlan_Doctors_DoctorId",
                table: "TreatmentPlan",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlan_MedicalFile_MedicalFileId",
                table: "TreatmentPlan",
                column: "MedicalFileId",
                principalTable: "MedicalFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlan_Report_ReportId",
                table: "TreatmentPlan",
                column: "ReportId",
                principalTable: "Report",
                principalColumn: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_VitalSigns_MedicalFile_MedicalFileId",
                table: "VitalSigns",
                column: "MedicalFileId",
                principalTable: "MedicalFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
