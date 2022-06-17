﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(RentaCarContext))]
    [Migration("20220608093907_fixedCarList")]
    partial class fixedCarList
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("WebApplication1.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("CarModalId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassificationId")
                        .HasColumnType("int");

                    b.Property<int?>("FuelTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("OfficiesId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("TransmissionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CarModalId");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("OfficiesId");

                    b.HasIndex("TransmissionTypeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("WebApplication1.Entities.CarModal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("ImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgURL2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("CarModals");
                });

            modelBuilder.Entity("WebApplication1.Entities.Classification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classifications");
                });

            modelBuilder.Entity("WebApplication1.Entities.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("WebApplication1.Entities.Officies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Officies");
                });

            modelBuilder.Entity("WebApplication1.Entities.RentedCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("RentedCars");
                });

            modelBuilder.Entity("WebApplication1.Entities.TransmissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransmissionTypes");
                });

            modelBuilder.Entity("WebApplication1.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.Entities.Car", b =>
                {
                    b.HasOne("WebApplication1.Entities.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId");

                    b.HasOne("WebApplication1.Entities.CarModal", "CarModal")
                        .WithMany("Cars")
                        .HasForeignKey("CarModalId");

                    b.HasOne("WebApplication1.Entities.Classification", "Classification")
                        .WithMany("Cars")
                        .HasForeignKey("ClassificationId");

                    b.HasOne("WebApplication1.Entities.FuelType", "FuelType")
                        .WithMany("Cars")
                        .HasForeignKey("FuelTypeId");

                    b.HasOne("WebApplication1.Entities.Officies", "Officies")
                        .WithMany("Cars")
                        .HasForeignKey("OfficiesId");

                    b.HasOne("WebApplication1.Entities.TransmissionType", "TransmissionType")
                        .WithMany("Cars")
                        .HasForeignKey("TransmissionTypeId");

                    b.Navigation("Brand");

                    b.Navigation("CarModal");

                    b.Navigation("Classification");

                    b.Navigation("FuelType");

                    b.Navigation("Officies");

                    b.Navigation("TransmissionType");
                });

            modelBuilder.Entity("WebApplication1.Entities.CarModal", b =>
                {
                    b.HasOne("WebApplication1.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("WebApplication1.Entities.RentedCar", b =>
                {
                    b.HasOne("WebApplication1.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("WebApplication1.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.Entities.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WebApplication1.Entities.CarModal", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WebApplication1.Entities.Classification", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WebApplication1.Entities.FuelType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WebApplication1.Entities.Officies", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WebApplication1.Entities.TransmissionType", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
