﻿// <auto-generated />
using System;
using Code360_Management.Models.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Code360_Management.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200219152639_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Code360_Management.Models.Students.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddmissionType")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("BVN")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nationality")
                        .HasColumnType("int");

                    b.Property<string>("NextOfKinDocumentUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NextOfKinEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NextOfKinName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NextOfKinPhone")
                        .HasColumnType("bigint");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            ID = 5,
                            AddmissionType = 1,
                            BVN = 0L,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "cokar@gmail.com",
                            Gender = 0,
                            MaritalStatus = 0,
                            Name = "Cokar",
                            Nationality = 0,
                            NextOfKinPhone = 0L,
                            Phone = 9074778383L
                        },
                        new
                        {
                            ID = 6,
                            AddmissionType = 0,
                            BVN = 0L,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "georgeebisike@gmail.com",
                            Gender = 0,
                            MaritalStatus = 0,
                            Name = "Ebisike George",
                            Nationality = 0,
                            NextOfKinPhone = 0L,
                            Phone = 9074778383L
                        },
                        new
                        {
                            ID = 7,
                            AddmissionType = 1,
                            BVN = 0L,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "pelumi@gmail.com",
                            Gender = 1,
                            MaritalStatus = 0,
                            Name = "Pelumi Richard",
                            Nationality = 0,
                            NextOfKinPhone = 0L,
                            Phone = 9074778383L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
