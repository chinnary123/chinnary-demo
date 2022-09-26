﻿// <auto-generated />
using System;
using EGroceryStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EGroceryStore.Migrations
{
    [DbContext(typeof(EGroceryStoreDbContext))]
    [Migration("20220921071022_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EGroceryStore.Models.BuyModel", b =>
                {
                    b.Property<int>("BuyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BuyerId");

                    b.ToTable("BuyModel");
                });

            modelBuilder.Entity("EGroceryStore.Models.CartModel", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ItemPrice")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("UserId");

                    b.ToTable("CartModels");
                });

            modelBuilder.Entity("EGroceryStore.Models.GroceryModel", b =>
                {
                    b.Property<int>("GroceryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroceryId");

                    b.ToTable("GroceryModels");
                });

            modelBuilder.Entity("EGroceryStore.Models.LoginModel", b =>
                {
                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailId");

                    b.ToTable("LoginModels");
                });

            modelBuilder.Entity("EGroceryStore.Models.RatingModel", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RatingScalevalue")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("userModelUserId")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("userModelUserId");

                    b.ToTable("RatingModels");
                });

            modelBuilder.Entity("EGroceryStore.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserModels");
                });

            modelBuilder.Entity("EGroceryStore.Models.VegetableModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CostPerKg")
                        .HasColumnType("bigint");

                    b.Property<string>("HybridOrNatural")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("QuantityInKg")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("VegetableModels");
                });

            modelBuilder.Entity("EGroceryStore.Models.CartModel", b =>
                {
                    b.HasOne("EGroceryStore.Models.UserModel", "userModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EGroceryStore.Models.RatingModel", b =>
                {
                    b.HasOne("EGroceryStore.Models.UserModel", "userModel")
                        .WithMany()
                        .HasForeignKey("userModelUserId");
                });
#pragma warning restore 612, 618
        }
    }
}