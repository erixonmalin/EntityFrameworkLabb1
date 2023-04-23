﻿// <auto-generated />
using System;
using EntityFrameworkLabb1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkLabb1.Migrations
{
    [DbContext(typeof(VacationDbContext))]
    partial class VacationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityFrameworkLabb1.Models.Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EntityFrameworkLabb1.Models.Domain.Vacation", b =>
                {
                    b.Property<int>("VacationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacationId"));

                    b.Property<string>("VacationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VacationId");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("EntityFrameworkLabb1.Models.Domain.VacationList", b =>
                {
                    b.Property<int>("VacationListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacationListId"));

                    b.Property<DateTime>("AskDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FK_Id")
                        .HasColumnType("int");

                    b.Property<int>("FK_VacationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VacationListId");

                    b.HasIndex("FK_Id");

                    b.HasIndex("FK_VacationId");

                    b.ToTable("VacationLists");
                });

            modelBuilder.Entity("EntityFrameworkLabb1.Models.Domain.VacationList", b =>
                {
                    b.HasOne("EntityFrameworkLabb1.Models.Domain.Employee", "Employees")
                        .WithMany("VacationLists")
                        .HasForeignKey("FK_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkLabb1.Models.Domain.Vacation", "Vacations")
                        .WithMany("VacationLists")
                        .HasForeignKey("FK_VacationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Vacations");
                });

            modelBuilder.Entity("EntityFrameworkLabb1.Models.Domain.Employee", b =>
                {
                    b.Navigation("VacationLists");
                });

            modelBuilder.Entity("EntityFrameworkLabb1.Models.Domain.Vacation", b =>
                {
                    b.Navigation("VacationLists");
                });
#pragma warning restore 612, 618
        }
    }
}
