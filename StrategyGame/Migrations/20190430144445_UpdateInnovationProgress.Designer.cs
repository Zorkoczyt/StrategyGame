﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StrategyGame.Models;

namespace StrategyGame.Migrations
{
    [DbContext(typeof(StrategyGameContext))]
    [Migration("20190430144445_UpdateInnovationProgress")]
    partial class UpdateInnovationProgress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StrategyGame.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("StrategyGame.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryBuildingProgressId");

                    b.Property<int>("CountryInnovationProgressId");

                    b.Property<string>("Name");

                    b.Property<int>("Point");

                    b.HasKey("Id");

                    b.HasIndex("CountryInnovationProgressId")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("StrategyGame.Models.CountryBuilding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingId");

                    b.Property<int>("Count");

                    b.Property<int>("CountryId");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("CountryId");

                    b.ToTable("CountryBuilding");
                });

            modelBuilder.Entity("StrategyGame.Models.CountryBuildingProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingId");

                    b.Property<int>("CountryId");

                    b.Property<int>("TurnsLeft");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("CountryId");

                    b.ToTable("CountryBuildingProgress");
                });

            modelBuilder.Entity("StrategyGame.Models.CountryInnovation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<int?>("InnovationId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("InnovationId");

                    b.ToTable("CountryInnovation");
                });

            modelBuilder.Entity("StrategyGame.Models.CountryInnovationProgress", b =>
                {
                    b.Property<int>("CountryInnovationProgressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CounryId");

                    b.Property<int>("InnovationId");

                    b.Property<int>("TurnsLeft");

                    b.HasKey("CountryInnovationProgressId");

                    b.HasIndex("InnovationId");

                    b.ToTable("CountryInnovationProgress");
                });

            modelBuilder.Entity("StrategyGame.Models.CountryUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<int>("CountryId");

                    b.Property<int>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("UnitId");

                    b.ToTable("CountryUnit");
                });

            modelBuilder.Entity("StrategyGame.Models.Innovation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("UpgradeStat");

                    b.HasKey("Id");

                    b.ToTable("Innovation");
                });

            modelBuilder.Entity("StrategyGame.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttackPoint");

                    b.Property<int>("DefensePoint");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Payment");

                    b.Property<int>("Price");

                    b.Property<int>("Supply");

                    b.HasKey("Id");

                    b.ToTable("Unit");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Unit");
                });

            modelBuilder.Entity("StrategyGame.Models.Archer", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Unit");


                    b.ToTable("Archer");

                    b.HasDiscriminator().HasValue("Archer");
                });

            modelBuilder.Entity("StrategyGame.Models.Elit", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Unit");


                    b.ToTable("Elit");

                    b.HasDiscriminator().HasValue("Elit");
                });

            modelBuilder.Entity("StrategyGame.Models.Horseman", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Unit");


                    b.ToTable("Horseman");

                    b.HasDiscriminator().HasValue("Horseman");
                });

            modelBuilder.Entity("StrategyGame.Models.Country", b =>
                {
                    b.HasOne("StrategyGame.Models.CountryInnovationProgress", "CountryInnovationProgress")
                        .WithOne("Country")
                        .HasForeignKey("StrategyGame.Models.Country", "CountryInnovationProgressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StrategyGame.Models.CountryBuilding", b =>
                {
                    b.HasOne("StrategyGame.Models.Building", "Building")
                        .WithMany("CountryBuildings")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StrategyGame.Models.Country", "Country")
                        .WithMany("CountryBuildings")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StrategyGame.Models.CountryBuildingProgress", b =>
                {
                    b.HasOne("StrategyGame.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StrategyGame.Models.Country", "Country")
                        .WithMany("CountryBuildingProgress")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StrategyGame.Models.CountryInnovation", b =>
                {
                    b.HasOne("StrategyGame.Models.Country", "Country")
                        .WithMany("CountryInnovations")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StrategyGame.Models.Innovation")
                        .WithMany("CountryInnovations")
                        .HasForeignKey("InnovationId");
                });

            modelBuilder.Entity("StrategyGame.Models.CountryInnovationProgress", b =>
                {
                    b.HasOne("StrategyGame.Models.Innovation", "Innovation")
                        .WithMany()
                        .HasForeignKey("InnovationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StrategyGame.Models.CountryUnit", b =>
                {
                    b.HasOne("StrategyGame.Models.Country", "Country")
                        .WithMany("CountryUnits")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StrategyGame.Models.Unit", "Unit")
                        .WithMany("CountryUnit")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
