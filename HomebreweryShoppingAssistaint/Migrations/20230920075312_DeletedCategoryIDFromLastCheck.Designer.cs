﻿// <auto-generated />
using System;
using HomebreweryShoppingAssistaint.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomebreweryShoppingAssistaint.Migrations
{
    [DbContext(typeof(HomebreweryShoppingAssistaintContext))]
    [Migration("20230920075312_DeletedCategoryIDFromLastCheck")]
    partial class DeletedCategoryIDFromLastCheck
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HomebreweryShoppingAssistaint.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<int>("CategoryName")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("HomebreweryShoppingAssistaint.Models.LastCheck", b =>
                {
                    b.Property<int>("LastCheckID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LastCheckID"));

                    b.Property<DateTime>("CheckDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("ShopID")
                        .HasColumnType("int");

                    b.HasKey("LastCheckID");

                    b.ToTable("LastCheck");
                });

            modelBuilder.Entity("HomebreweryShoppingAssistaint.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Product30DaysPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShopID")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ShopID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("HomebreweryShoppingAssistaint.Models.Shop", b =>
                {
                    b.Property<int>("ShopID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShopID"));

                    b.Property<int?>("LastCheckID")
                        .HasColumnType("int");

                    b.Property<string>("ShopLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShopName")
                        .HasColumnType("int");

                    b.HasKey("ShopID");

                    b.HasIndex("LastCheckID");

                    b.ToTable("Shop");
                });

            modelBuilder.Entity("HomebreweryShoppingAssistaint.Models.Product", b =>
                {
                    b.HasOne("HomebreweryShoppingAssistaint.Models.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomebreweryShoppingAssistaint.Models.Shop", "Shop")
                        .WithMany("Product")
                        .HasForeignKey("ShopID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("HomebreweryShoppingAssistaint.Models.Shop", b =>
                {
                    b.HasOne("HomebreweryShoppingAssistaint.Models.LastCheck", null)
                        .WithMany("Shop")
                        .HasForeignKey("LastCheckID");
                });

            modelBuilder.Entity("HomebreweryShoppingAssistaint.Models.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("HomebreweryShoppingAssistaint.Models.LastCheck", b =>
                {
                    b.Navigation("Shop");
                });

            modelBuilder.Entity("HomebreweryShoppingAssistaint.Models.Shop", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
