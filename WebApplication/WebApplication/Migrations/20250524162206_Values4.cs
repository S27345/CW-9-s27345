using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class Values4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrescriptionIdPrescription",
                table: "Prescription_Medicament",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 },
                column: "PrescriptionIdPrescription",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_PrescriptionIdPrescription",
                table: "Prescription_Medicament",
                column: "PrescriptionIdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicament_Prescriptions_PrescriptionIdPrescription",
                table: "Prescription_Medicament",
                column: "PrescriptionIdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicament_Prescriptions_PrescriptionIdPrescription",
                table: "Prescription_Medicament");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicament_PrescriptionIdPrescription",
                table: "Prescription_Medicament");

            migrationBuilder.DropColumn(
                name: "PrescriptionIdPrescription",
                table: "Prescription_Medicament");
        }
    }
}
