﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resturant_managment;

#nullable disable

namespace Resturant_managment.Migrations
{
    [DbContext(typeof(RmDbContext))]
    partial class RmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

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

            modelBuilder.Entity("Resturant_managment.Models.Food", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Categoryid")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

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

            modelBuilder.Entity("Resturant_managment.Models.Restaurant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("Resturant_managment.Models.Category", b =>
                {
                    b.HasOne("Resturant_managment.Models.Menu", null)
                        .WithMany("Categories")
                        .HasForeignKey("Menuid");
                });

            modelBuilder.Entity("Resturant_managment.Models.Food", b =>
                {
                    b.HasOne("Resturant_managment.Models.Category", null)
                        .WithMany("Foods")
                        .HasForeignKey("Categoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Resturant_managment.Models.Menu", b =>
                {
                    b.HasOne("Resturant_managment.Models.Restaurant", null)
                        .WithMany("Menus")
                        .HasForeignKey("Restaurantid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Resturant_managment.Models.Category", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("Resturant_managment.Models.Menu", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Resturant_managment.Models.Restaurant", b =>
                {
                    b.Navigation("Menus");
                });
#pragma warning restore 612, 618
        }
    }
}
