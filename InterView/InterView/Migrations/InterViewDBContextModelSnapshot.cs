﻿// <auto-generated />
using System;
using DataAcsess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InterView.Migrations
{
    [DbContext(typeof(InterViewDBContext))]
    partial class InterViewDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAcsess.models.InvoiceDetails", b =>
                {
                    b.Property<int>("LineNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LineNo"));

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitNo")
                        .HasColumnType("int");

                    b.Property<int>("UnitNo1")
                        .HasColumnType("int");

                    b.HasKey("LineNo");

                    b.HasIndex("UnitNo1");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("DataAcsess.models.Unit", b =>
                {
                    b.Property<int>("UnitNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitNo"));

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UnitNo");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("DataAcsess.models.InvoiceDetails", b =>
                {
                    b.HasOne("DataAcsess.models.Unit", "Unit")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("UnitNo1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("DataAcsess.models.Unit", b =>
                {
                    b.Navigation("InvoiceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
