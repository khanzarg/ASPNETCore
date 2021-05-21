﻿// <auto-generated />
using System;
using ASPNETCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASPNETCore.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210520042510_onDeleteCascade")]
    partial class onDeleteCascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASPNETCore.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Account");
                });

            modelBuilder.Entity("ASPNETCore.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("StreetAddress1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TerritoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TerritoryId");

                    b.ToTable("TB_M_Address");
                });

            modelBuilder.Entity("ASPNETCore.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Linkedin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Contact");
                });

            modelBuilder.Entity("ASPNETCore.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("TB_M_District");
                });

            modelBuilder.Entity("ASPNETCore.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MajorId")
                        .HasColumnType("int");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.HasIndex("UniversityId");

                    b.ToTable("TB_M_Education");
                });

            modelBuilder.Entity("ASPNETCore.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Employee");
                });

            modelBuilder.Entity("ASPNETCore.Models.EmployeeRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("TB_M_EmployeeRole");
                });

            modelBuilder.Entity("ASPNETCore.Models.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Major");
                });

            modelBuilder.Entity("ASPNETCore.Models.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Parameter");
                });

            modelBuilder.Entity("ASPNETCore.Models.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Province");
                });

            modelBuilder.Entity("ASPNETCore.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Role");
                });

            modelBuilder.Entity("ASPNETCore.Models.SubDistrict", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("TB_T_SubDistrict");
                });

            modelBuilder.Entity("ASPNETCore.Models.Territory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubDistrictId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubDistrictId");

                    b.ToTable("TB_M_Territory");
                });

            modelBuilder.Entity("ASPNETCore.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_University");
                });

            modelBuilder.Entity("ASPNETCore.Models.Account", b =>
                {
                    b.HasOne("ASPNETCore.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("ASPNETCore.Models.Account", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASPNETCore.Models.Address", b =>
                {
                    b.HasOne("ASPNETCore.Models.Employee", "Employee")
                        .WithOne("Address")
                        .HasForeignKey("ASPNETCore.Models.Address", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPNETCore.Models.Territory", "Territory")
                        .WithMany("Addresses")
                        .HasForeignKey("TerritoryId");
                });

            modelBuilder.Entity("ASPNETCore.Models.Contact", b =>
                {
                    b.HasOne("ASPNETCore.Models.Employee", "Employee")
                        .WithOne("Contact")
                        .HasForeignKey("ASPNETCore.Models.Contact", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASPNETCore.Models.District", b =>
                {
                    b.HasOne("ASPNETCore.Models.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("ASPNETCore.Models.Education", b =>
                {
                    b.HasOne("ASPNETCore.Models.Employee", "Employee")
                        .WithOne("Education")
                        .HasForeignKey("ASPNETCore.Models.Education", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPNETCore.Models.Major", "Major")
                        .WithMany("Educations")
                        .HasForeignKey("MajorId");

                    b.HasOne("ASPNETCore.Models.University", "University")
                        .WithMany("Educations")
                        .HasForeignKey("UniversityId");
                });

            modelBuilder.Entity("ASPNETCore.Models.EmployeeRole", b =>
                {
                    b.HasOne("ASPNETCore.Models.Employee", "Employee")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ASPNETCore.Models.Role", "Role")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("ASPNETCore.Models.SubDistrict", b =>
                {
                    b.HasOne("ASPNETCore.Models.District", "District")
                        .WithMany("SubDistrict")
                        .HasForeignKey("DistrictId");
                });

            modelBuilder.Entity("ASPNETCore.Models.Territory", b =>
                {
                    b.HasOne("ASPNETCore.Models.SubDistrict", "SubDistrict")
                        .WithMany("Territory")
                        .HasForeignKey("SubDistrictId");
                });
#pragma warning restore 612, 618
        }
    }
}
