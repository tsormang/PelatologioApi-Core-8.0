﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PelatologioApi.Data;

#nullable disable

namespace PelatologioApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PelatologioApi.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelephoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TelephoneId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PelatologioApi.Entities.Telephone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long?>("House")
                        .HasColumnType("bigint");

                    b.Property<long?>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<long?>("Work")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Telephone");
                });

            modelBuilder.Entity("PelatologioApi.Entities.Customer", b =>
                {
                    b.HasOne("PelatologioApi.Entities.Telephone", "Telephones")
                        .WithMany()
                        .HasForeignKey("TelephoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Telephones");
                });
#pragma warning restore 612, 618
        }
    }
}
