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
    [Migration("20221113161505_uiu2lkwd")]
    partial class uiu2lkwd
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
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Menuid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Menuid");

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

                    b.Property<int>("Rate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RestaurantUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

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

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Orderid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

                    b.HasIndex("Orderid");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Resturant_managment.Models.Menu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Restaurantid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Restaurantid");

                    b.ToTable("Menus");
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

            modelBuilder.Entity("Resturant_managment.Models.Restaurant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BackgroundImg")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Cityid")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LogoImg")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Cityid");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("Resturant_managment.Models.RestaurantIdentity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Resturant_managment.Models.Tag", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResturantId")
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
                    b.HasOne("Resturant_managment.Models.Menu", null)
                        .WithMany("Categories")
                        .HasForeignKey("Menuid");
                });

            modelBuilder.Entity("Resturant_managment.Models.Comment", b =>
                {
                    b.HasOne("Resturant_managment.Models.RestaurantIdentity", "RestaurantUser")
                        .WithMany()
                        .HasForeignKey("RestaurantUserId");

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

            modelBuilder.Entity("Resturant_managment.Models.Menu", b =>
                {
                    b.HasOne("Resturant_managment.Models.Restaurant", null)
                        .WithMany("Menus")
                        .HasForeignKey("Restaurantid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Resturant_managment.Models.Order", b =>
                {
                    b.HasOne("Resturant_managment.Models.Restaurant", null)
                        .WithMany("Orders")
                        .HasForeignKey("Restaurantid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Resturant_managment.Models.Restaurant", b =>
                {
                    b.HasOne("Resturant_managment.Models.City", "City")
                        .WithMany("Restaurants")
                        .HasForeignKey("Cityid");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Resturant_managment.Models.Tag", b =>
                {
                    b.HasOne("Resturant_managment.Models.Restaurant", "Restaurant")
                        .WithMany("Tags")
                        .HasForeignKey("RestaurantId");

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

            modelBuilder.Entity("Resturant_managment.Models.Menu", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Resturant_managment.Models.Order", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("Resturant_managment.Models.Restaurant", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("Orders");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
