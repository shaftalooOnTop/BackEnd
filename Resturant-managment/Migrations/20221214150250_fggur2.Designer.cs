﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resturant_managment;

#nullable disable

namespace Resturant_managment.Migrations
{
    [DbContext(typeof(RmDbContext))]
    [Migration("20221214150250_fggur2")]
    partial class fggur2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodOrder", b =>
                {
                    b.Property<int>("Foodsid")
                        .HasColumnType("int");

                    b.Property<int>("Ordersid")
                        .HasColumnType("int");

                    b.HasKey("Foodsid", "Ordersid");

                    b.HasIndex("Ordersid");

                    b.ToTable("FoodOrder");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Resturant_managment.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Resturant_managment.Models.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Resturant_managment.Models.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ManagerComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("RestaurantUserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Resturant_managment.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("earning")
                        .HasColumnType("int");

                    b.Property<string>("identityid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("jobtype")
                        .HasColumnType("int");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("restaurantid")
                        .HasColumnType("int");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("identityid");

                    b.HasIndex("restaurantid");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Resturant_managment.Models.EntranceMangment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<int?>("employeeid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("enter")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("leave")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("employeeid");

                    b.ToTable("EntranceMangments");
                });

            modelBuilder.Entity("Resturant_managment.Models.Food", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("Categoryid")
                        .HasColumnType("int");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FoodDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

                    b.HasIndex("PhotoId")
                        .IsUnique()
                        .HasFilter("[PhotoId] IS NOT NULL");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Resturant_managment.Models.Images", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ImageB")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Resturant_managment.Models.Inventory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InventoriesId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("InventoriesId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Resturant_managment.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("RestaurantIdentityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("restaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("restuarantId")
                        .HasColumnType("int");

                    b.Property<int>("stat")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("RestaurantIdentityId");

                    b.HasIndex("restuarantId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Resturant_managment.Models.Payment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentState")
                        .HasColumnType("int");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Resturant_managment.Models.Photo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Resturant_managment.Models.ReserveTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpireHours")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("ReserveTimeId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantIdentityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int?>("theme")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("PaymentId")
                        .IsUnique()
                        .HasFilter("[PaymentId] IS NOT NULL");

                    b.HasIndex("ReserveTimeId");

                    b.HasIndex("RestaurantIdentityId");

                    b.HasIndex("TableId");

                    b.ToTable("ReserveTables");
                });

            modelBuilder.Entity("Resturant_managment.Models.resrvetime", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReserveTime")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Resrvetimes");
                });

            modelBuilder.Entity("Resturant_managment.Models.Restaurant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Avg")
                        .HasColumnType("float");

                    b.Property<string>("BackgroundImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndWorkingHour")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InventoriesId")
                        .HasColumnType("int");

                    b.Property<string>("LogoImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartWorkingHour")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("CityId");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("Resturant_managment.Models.RestaurantIdentity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Resturant_managment.Models.RestaurantTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantTables");
                });

            modelBuilder.Entity("Resturant_managment.Models.Tag", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("FoodOrder", b =>
                {
                    b.HasOne("Resturant_managment.Models.Food", null)
                        .WithMany()
                        .HasForeignKey("Foodsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resturant_managment.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("Ordersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Resturant_managment.Models.RestaurantIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Resturant_managment.Models.RestaurantIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Resturant_managment.Models.RestaurantIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Resturant_managment.Models.Category", b =>
                {
                    b.HasOne("Resturant_managment.Models.Restaurant", "Restaurant")
                        .WithMany("Menu")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Resturant_managment.Models.Comment", b =>
                {
                    b.HasOne("Resturant_managment.Models.Restaurant", "Restaurant")
                        .WithMany("Comments")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resturant_managment.Models.RestaurantIdentity", "RestaurantUser")
                        .WithMany()
                        .HasForeignKey("RestaurantUserId");

                    b.Navigation("Restaurant");

                    b.Navigation("RestaurantUser");
                });

            modelBuilder.Entity("Resturant_managment.Models.Employee", b =>
                {
                    b.HasOne("Resturant_managment.Models.RestaurantIdentity", "RestaurantIdentity")
                        .WithMany()
                        .HasForeignKey("identityid");

                    b.HasOne("Resturant_managment.Models.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("restaurantid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("RestaurantIdentity");
                });

            modelBuilder.Entity("Resturant_managment.Models.EntranceMangment", b =>
                {
                    b.HasOne("Resturant_managment.Models.Employee", "employee")
                        .WithMany("entranceMangments")
                        .HasForeignKey("employeeid");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("Resturant_managment.Models.Food", b =>
                {
                    b.HasOne("Resturant_managment.Models.Category", "Category")
                        .WithMany("Foods")
                        .HasForeignKey("Categoryid");

                    b.HasOne("Resturant_managment.Models.Photo", "Photo")
                        .WithOne("Food")
                        .HasForeignKey("Resturant_managment.Models.Food", "PhotoId");

                    b.Navigation("Category");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("Resturant_managment.Models.Inventory", b =>
                {
                    b.HasOne("Resturant_managment.Models.Restaurant", "Restaurant")
                        .WithMany("Inventories")
                        .HasForeignKey("InventoriesId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Resturant_managment.Models.Order", b =>
                {
                    b.HasOne("Resturant_managment.Models.RestaurantIdentity", "RestaurantIdentity")
                        .WithMany()
                        .HasForeignKey("RestaurantIdentityId");

                    b.HasOne("Resturant_managment.Models.Restaurant", "Restaurant")
                        .WithMany("Orders")
                        .HasForeignKey("restuarantId");

                    b.Navigation("Restaurant");

                    b.Navigation("RestaurantIdentity");
                });

            modelBuilder.Entity("Resturant_managment.Models.Payment", b =>
                {
                    b.HasOne("Resturant_managment.Models.RestaurantIdentity", "Identity")
                        .WithMany("Payments")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resturant_managment.Models.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("Resturant_managment.Models.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Identity");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Resturant_managment.Models.ReserveTable", b =>
                {
                    b.HasOne("Resturant_managment.Models.Payment", "Payment")
                        .WithOne("ReserveTable")
                        .HasForeignKey("Resturant_managment.Models.ReserveTable", "PaymentId");

                    b.HasOne("Resturant_managment.Models.resrvetime", "ReserveTime")
                        .WithMany()
                        .HasForeignKey("ReserveTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resturant_managment.Models.RestaurantIdentity", "RestaurantIdentity")
                        .WithMany("restable")
                        .HasForeignKey("RestaurantIdentityId");

                    b.HasOne("Resturant_managment.Models.RestaurantTable", "Table")
                        .WithMany("ReserveTables")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("ReserveTime");

                    b.Navigation("RestaurantIdentity");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Resturant_managment.Models.Restaurant", b =>
                {
                    b.HasOne("Resturant_managment.Models.City", "City")
                        .WithMany("Restaurants")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Resturant_managment.Models.RestaurantIdentity", b =>
                {
                    b.HasOne("Resturant_managment.Models.City", "city")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");
                });

            modelBuilder.Entity("Resturant_managment.Models.RestaurantTable", b =>
                {
                    b.HasOne("Resturant_managment.Models.Restaurant", "Restaurant")
                        .WithMany("tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Resturant_managment.Models.Tag", b =>
                {
                    b.HasOne("Resturant_managment.Models.Restaurant", "Restaurant")
                        .WithMany("Tags")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Resturant_managment.Models.Category", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("Resturant_managment.Models.City", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("Resturant_managment.Models.Employee", b =>
                {
                    b.Navigation("entranceMangments");
                });

            modelBuilder.Entity("Resturant_managment.Models.Order", b =>
                {
                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Resturant_managment.Models.Payment", b =>
                {
                    b.Navigation("ReserveTable");
                });

            modelBuilder.Entity("Resturant_managment.Models.Photo", b =>
                {
                    b.Navigation("Food")
                        .IsRequired();
                });

            modelBuilder.Entity("Resturant_managment.Models.Restaurant", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Employees");

                    b.Navigation("Inventories");

                    b.Navigation("Menu");

                    b.Navigation("Orders");

                    b.Navigation("Tags");

                    b.Navigation("tables");
                });

            modelBuilder.Entity("Resturant_managment.Models.RestaurantIdentity", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("restable");
                });

            modelBuilder.Entity("Resturant_managment.Models.RestaurantTable", b =>
                {
                    b.Navigation("ReserveTables");
                });
#pragma warning restore 612, 618
        }
    }
}
