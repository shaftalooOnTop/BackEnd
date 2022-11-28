﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resturant_managment;

#nullable disable

namespace Resturant_managment.Migrations
{
    [DbContext(typeof(RmDbContext))]
    [Migration("20221127195148_1lld")]
    partial class _1lld
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Resturant_managment.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Resturant_managment.Models.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdentityId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Resturant_managment.Models.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("ManagerComment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Rate")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RestaurantUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("RestaurantUserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Resturant_managment.Models.Food", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Categoryid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("FoodDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Orderid")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

                    b.HasIndex("Orderid");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Resturant_managment.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("Restaurantid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Restaurantid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Resturant_managment.Models.Payment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentType")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Resturant_managment.Models.Restaurant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Avg")
                        .HasColumnType("REAL");

                    b.Property<string>("BackgroundImg")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndWorkingHour")
                        .HasColumnType("TEXT");

                    b.Property<string>("LogoImg")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartWorkingHour")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("CityId");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("Resturant_managment.Models.RestaurantIdentity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdentityId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Resturant_managment.Models.RestaurantTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("number")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantTables");
                });

            modelBuilder.Entity("Resturant_managment.Models.Tag", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tags");
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

            modelBuilder.Entity("Resturant_managment.Models.Food", b =>
                {
                    b.HasOne("Resturant_managment.Models.Category", "Category")
                        .WithMany("Foods")
                        .HasForeignKey("Categoryid");

                    b.HasOne("Resturant_managment.Models.Order", null)
                        .WithMany("Foods")
                        .HasForeignKey("Orderid");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Resturant_managment.Models.Order", b =>
                {
                    b.HasOne("Resturant_managment.Models.Restaurant", null)
                        .WithMany("Orders")
                        .HasForeignKey("Restaurantid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Resturant_managment.Models.Payment", b =>
                {
                    b.HasOne("Resturant_managment.Models.RestaurantIdentity", "Identity")
                        .WithMany("Payments")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resturant_managment.Models.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Identity");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Resturant_managment.Models.Restaurant", b =>
                {
                    b.HasOne("Resturant_managment.Models.City", "City")
                        .WithMany("Restaurants")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Resturant_managment.Models.RestaurantIdentity", b =>
                {
                    b.HasOne("Resturant_managment.Models.City", "city")
                        .WithMany("Identity")
                        .HasForeignKey("IdentityId");

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
                    b.Navigation("Identity");

                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("Resturant_managment.Models.Order", b =>
                {
                    b.Navigation("Foods");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Resturant_managment.Models.Restaurant", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Menu");

                    b.Navigation("Orders");

                    b.Navigation("Tags");

                    b.Navigation("tables");
                });

            modelBuilder.Entity("Resturant_managment.Models.RestaurantIdentity", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
