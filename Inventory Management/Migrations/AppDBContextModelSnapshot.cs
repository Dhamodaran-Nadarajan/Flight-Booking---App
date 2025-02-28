﻿// <auto-generated />
using System;
using InventoryManagement.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventoryManagement.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InventoryManagement.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineId");

                    b.Property<DateTime>("Arrival");

                    b.Property<int>("BusinessSeats");

                    b.Property<DateTime>("Departure");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Meal");

                    b.Property<int>("NonBusinessSeats");

                    b.Property<string>("ScheduledDays");

                    b.Property<float>("TicketPrice");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Inventories");
                });
#pragma warning restore 612, 618
        }
    }
}
