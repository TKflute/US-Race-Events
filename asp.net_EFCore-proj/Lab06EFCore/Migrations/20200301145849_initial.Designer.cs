﻿// <auto-generated />
using System;
using Lab06EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab06EFCore.Migrations
{
    [DbContext(typeof(RaceEventsDbContext))]
    [Migration("20200301145849_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab06EFCore.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cause");

                    b.Property<DateTime>("Date");

                    b.Property<double>("DistanceInMiles");

                    b.Property<string>("Location");

                    b.Property<int>("SponsorId");

                    b.HasKey("RaceId");

                    b.HasIndex("SponsorId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Lab06EFCore.Models.Run", b =>
                {
                    b.Property<int>("RunId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AvgSpeedInMiles");

                    b.Property<int>("RaceId");

                    b.Property<double>("RunTime");

                    b.Property<int>("RunnerId");

                    b.HasKey("RunId");

                    b.HasIndex("RaceId");

                    b.HasIndex("RunnerId");

                    b.ToTable("Runs");
                });

            modelBuilder.Entity("Lab06EFCore.Models.Runner", b =>
                {
                    b.Property<int>("RunnerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.HasKey("RunnerId");

                    b.ToTable("Runners");
                });

            modelBuilder.Entity("Lab06EFCore.Models.Sponsor", b =>
                {
                    b.Property<int>("SponsorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.Property<string>("Zip");

                    b.HasKey("SponsorId");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("Lab06EFCore.Models.Volunteer", b =>
                {
                    b.Property<int>("VolunteerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstName");

                    b.Property<int>("LastName");

                    b.Property<string>("Phone");

                    b.Property<int>("RaceId");

                    b.HasKey("VolunteerId");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("Lab06EFCore.Models.Race", b =>
                {
                    b.HasOne("Lab06EFCore.Models.Sponsor", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Lab06EFCore.Models.Run", b =>
                {
                    b.HasOne("Lab06EFCore.Models.Race", "Race")
                        .WithMany("RunList")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lab06EFCore.Models.Runner", "Runner")
                        .WithMany("RunList")
                        .HasForeignKey("RunnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
