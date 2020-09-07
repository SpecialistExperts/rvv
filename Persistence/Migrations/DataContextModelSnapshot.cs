﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Domain.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("VacationAdress")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ValidInfo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Values");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Adress = "Adres1",
                            Email = "Email1",
                            Name = "naam1",
                            PhoneNumber = "telefoonnummer1",
                            VacationAdress = "Vakantieadres1",
                            ValidInfo = true,
                            created_at = new DateTime(2020, 9, 7, 11, 48, 41, 373, DateTimeKind.Local).AddTicks(2440),
                            updated_at = new DateTime(2020, 9, 7, 11, 48, 41, 375, DateTimeKind.Local).AddTicks(4379)
                        },
                        new
                        {
                            Id = 6,
                            Adress = "Adres2",
                            Email = "Email2",
                            Name = "naam2",
                            PhoneNumber = "telefoonnummer2",
                            VacationAdress = "Vakantieadres2",
                            ValidInfo = true,
                            created_at = new DateTime(2020, 9, 7, 11, 48, 41, 375, DateTimeKind.Local).AddTicks(4814),
                            updated_at = new DateTime(2020, 9, 7, 11, 48, 41, 375, DateTimeKind.Local).AddTicks(4837)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
