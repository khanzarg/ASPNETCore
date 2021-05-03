using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNETCore.Migrations
{
    public partial class AlterTableAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Table_M_Account",
                table: "Table_M_Account");

            migrationBuilder.RenameTable(
                name: "Table_M_Account",
                newName: "TB_M_Account");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "TB_M_Account",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TB_M_Account",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TB_M_Account",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_M_Account",
                table: "TB_M_Account",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_M_Account",
                table: "TB_M_Account");

            migrationBuilder.RenameTable(
                name: "TB_M_Account",
                newName: "Table_M_Account");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Table_M_Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Table_M_Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Table_M_Account",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table_M_Account",
                table: "Table_M_Account",
                column: "Id");
        }
    }
}
