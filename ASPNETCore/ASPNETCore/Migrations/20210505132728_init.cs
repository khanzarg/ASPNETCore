using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNETCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Major",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Counter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Major", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Parameter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Parameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Province",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_University",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Counter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_University", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginModels_TB_M_Employee_Id",
                        column: x => x.Id,
                        principalTable: "TB_M_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Contact_TB_M_Employee_Id",
                        column: x => x.Id,
                        principalTable: "TB_M_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_District",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_District_TB_M_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "TB_M_Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_EmployeeRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_EmployeeRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_EmployeeRole_TB_M_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TB_M_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_EmployeeRole_TB_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Degree = table.Column<string>(nullable: true),
                    MajorId = table.Column<int>(nullable: true),
                    UniversityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Education_TB_M_Employee_Id",
                        column: x => x.Id,
                        principalTable: "TB_M_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Education_TB_M_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "TB_M_Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_Education_TB_M_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "TB_M_University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_SubDistrict",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_SubDistrict", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_SubDistrict_TB_M_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "TB_M_District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "TB_M_Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    StreetAddress1 = table.Column<string>(nullable: true),
                    StreetAddress2 = table.Column<string>(nullable: true),
                    TerritoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Address_TB_M_Employee_Id",
                        column: x => x.Id,
                        principalTable: "TB_M_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Address_TB_M_Territory_TerritoryId",
                        column: x => x.TerritoryId,
                        principalTable: "TB_M_Territory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Address_TerritoryId",
                table: "TB_M_Address",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_District_ProvinceId",
                table: "TB_M_District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Education_MajorId",
                table: "TB_M_Education",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Education_UniversityId",
                table: "TB_M_Education",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_EmployeeRole_EmployeeId",
                table: "TB_M_EmployeeRole",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_EmployeeRole_RoleId",
                table: "TB_M_EmployeeRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Territory_SubDistrictId",
                table: "TB_M_Territory",
                column: "SubDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_SubDistrict_DistrictId",
                table: "TB_T_SubDistrict",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginModels");

            migrationBuilder.DropTable(
                name: "TB_M_Address");

            migrationBuilder.DropTable(
                name: "TB_M_Contact");

            migrationBuilder.DropTable(
                name: "TB_M_Education");

            migrationBuilder.DropTable(
                name: "TB_M_EmployeeRole");

            migrationBuilder.DropTable(
                name: "TB_M_Parameter");

            migrationBuilder.DropTable(
                name: "TB_M_Territory");

            migrationBuilder.DropTable(
                name: "TB_M_Major");

            migrationBuilder.DropTable(
                name: "TB_M_University");

            migrationBuilder.DropTable(
                name: "TB_M_Employee");

            migrationBuilder.DropTable(
                name: "TB_M_Role");

            migrationBuilder.DropTable(
                name: "TB_T_SubDistrict");

            migrationBuilder.DropTable(
                name: "TB_M_District");

            migrationBuilder.DropTable(
                name: "TB_M_Province");
        }
    }
}
