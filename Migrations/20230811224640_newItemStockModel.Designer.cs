﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TyTManagmentSystem.DataAccess;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(TyTContext))]
    [Migration("20230811224640_newItemStockModel")]
    partial class newItemStockModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api.Models.SuppliersItems", b =>
                {
                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("SupplierId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("SuppliersItems");
                });

            modelBuilder.Entity("Api.Models.TypeOfItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("ItemSupplier", b =>
                {
                    b.Property<int>("ItemsId")
                        .HasColumnType("int");

                    b.Property<int>("SuppliersId")
                        .HasColumnType("int");

                    b.HasKey("ItemsId", "SuppliersId");

                    b.HasIndex("SuppliersId");

                    b.ToTable("ItemSupplier");
                });

            modelBuilder.Entity("TyTManagmentSystem.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TyTManagmentSystem.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TypeId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("TyTManagmentSystem.Models.StockMovements", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfAction")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Dollar_at_Date")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("RealAmountUsed")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("StockMovements");
                });

            modelBuilder.Entity("TyTManagmentSystem.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CUIT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Api.Models.SuppliersItems", b =>
                {
                    b.HasOne("TyTManagmentSystem.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TyTManagmentSystem.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ItemSupplier", b =>
                {
                    b.HasOne("TyTManagmentSystem.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TyTManagmentSystem.Models.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuppliersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TyTManagmentSystem.Models.Item", b =>
                {
                    b.HasOne("TyTManagmentSystem.Models.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.TypeOfItem", "Type")
                        .WithMany("Items")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("TyTManagmentSystem.Models.StockMovements", b =>
                {
                    b.HasOne("TyTManagmentSystem.Models.Item", "Item")
                        .WithMany("StockHistory")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("TyTManagmentSystem.Models.Supplier", b =>
                {
                    b.OwnsOne("TyTManagmentSystem.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("SupplierId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("StreetNumber")
                                .HasColumnType("int");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Suppliers");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("TyTManagmentSystem.Models.Contact", "Contact", b1 =>
                        {
                            b1.Property<int>("SupplierId")
                                .HasColumnType("int");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Suppliers");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Contact")
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.TypeOfItem", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("TyTManagmentSystem.Models.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("TyTManagmentSystem.Models.Item", b =>
                {
                    b.Navigation("StockHistory");
                });
#pragma warning restore 612, 618
        }
    }
}