using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNETCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_T_SubDistrict",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    District_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_SubDistrict", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Territory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    SubDistrictId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Territory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Territory_TB_T_SubDistrict_SubDistrictId",
                        column: x => x.SubDistrictId,
                        principalTable: "TB_T_SubDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Territory_SubDistrictId",
                table: "TB_M_Territory",
                column: "SubDistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Territory");

            migrationBuilder.DropTable(
                name: "TB_T_SubDistrict");
        }
    }
}
