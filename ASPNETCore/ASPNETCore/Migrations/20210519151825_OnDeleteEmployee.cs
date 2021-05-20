using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNETCore.Migrations
{
    public partial class OnDeleteEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_EmployeeRole_TB_M_Employee_EmployeeId",
                table: "TB_M_EmployeeRole");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_EmployeeRole_TB_M_Employee_EmployeeId",
                table: "TB_M_EmployeeRole",
                column: "EmployeeId",
                principalTable: "TB_M_Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_EmployeeRole_TB_M_Employee_EmployeeId",
                table: "TB_M_EmployeeRole");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_EmployeeRole_TB_M_Employee_EmployeeId",
                table: "TB_M_EmployeeRole",
                column: "EmployeeId",
                principalTable: "TB_M_Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
