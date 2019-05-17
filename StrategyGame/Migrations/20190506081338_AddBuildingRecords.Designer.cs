﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StrategyGame.Models;

namespace StrategyGame.Migrations
{
    [DbContext(typeof(StrategyGameContext))]
    [Migration("20190506081338_AddBuildingRecords")]
    partial class AddBuildingRecords
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

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Buildings");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Building");
                });

            modelBuilder.Entity("StrategyGame.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryBuildingProgressId");

                    b.Property<int>("CountryInnovationProgressId");

                    b.Property<double>("Gold");

                    b.Property<string>("Name");

                    b.Property<double>("Point");

                    b.Property<double>("Potato");

                    b.HasKey("Id");

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

                    b.ToTable("CountryBuildings");
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

                    b.ToTable("CountryBuildingProgresses");
                });

            modelBuilder.Entity("StrategyGame.Models.CountryInnovation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<int>("InnovationId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("InnovationId");

                    b.ToTable("CountryInnovations");
                });

            modelBuilder.Entity("StrategyGame.Models.CountryInnovationProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<int>("InnovationId");

                    b.Property<int>("TurnsLeft");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("InnovationId");

                    b.ToTable("CountryInnovationProgresses");
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

                    b.ToTable("CountryUnits");
                });

            modelBuilder.Entity("StrategyGame.Models.Innovation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<double>("UpgradeStat");

                    b.HasKey("Id");

                    b.ToTable("Innovations");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Innovation");
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

                    b.ToTable("Units");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Unit");
                });

            modelBuilder.Entity("StrategyGame.Models.Barrack", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Building");

                    b.Property<int>("Soldiers");

                    b.ToTable("Barrack");

                    b.HasDiscriminator().HasValue("Barrack");

                    b.HasData(
                        new { Id = 2, Soldiers = 0 }
                    );
                });

            modelBuilder.Entity("StrategyGame.Models.Farm", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Building");

                    b.Property<int>("Population");

                    b.Property<int>("Potato");

                    b.ToTable("Farm");

                    b.HasDiscriminator().HasValue("Farm");

                    b.HasData(
                        new { Id = 1, Population = 0, Potato = 0 }
                    );
                });

            modelBuilder.Entity("StrategyGame.Models.Alchemy", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Innovation");


                    b.ToTable("Alchemy");

                    b.HasDiscriminator().HasValue("Alchemy");
                });

            modelBuilder.Entity("StrategyGame.Models.CityWall", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Innovation");


                    b.ToTable("CityWall");

                    b.HasDiscriminator().HasValue("CityWall");
                });

            modelBuilder.Entity("StrategyGame.Models.Combine", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Innovation");


                    b.ToTable("Combine");

                    b.HasDiscriminator().HasValue("Combine");
                });

            modelBuilder.Entity("StrategyGame.Models.OperationRebirth", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Innovation");


                    b.ToTable("OperationRebirth");

                    b.HasDiscriminator().HasValue("OperationRebirth");
                });

            modelBuilder.Entity("StrategyGame.Models.Tactic", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Innovation");


                    b.ToTable("Tactic");

                    b.HasDiscriminator().HasValue("Tactic");
                });

            modelBuilder.Entity("StrategyGame.Models.Truck", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Innovation");


                    b.ToTable("Truck");

                    b.HasDiscriminator().HasValue("Truck");
                });

            modelBuilder.Entity("StrategyGame.Models.Archer", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Unit");


                    b.ToTable("Archer");

                    b.HasDiscriminator().HasValue("Archer");

                    b.HasData(
                        new { Id = 1, AttackPoint = 2, DefensePoint = 6, Payment = 1, Price = 50, Supply = 1 }
                    );
                });

            modelBuilder.Entity("StrategyGame.Models.Elit", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Unit");


                    b.ToTable("Elit");

                    b.HasDiscriminator().HasValue("Elit");

                    b.HasData(
                        new { Id = 3, AttackPoint = 5, DefensePoint = 5, Payment = 3, Price = 100, Supply = 2 }
                    );
                });

            modelBuilder.Entity("StrategyGame.Models.Horseman", b =>
                {
                    b.HasBaseType("StrategyGame.Models.Unit");


                    b.ToTable("Horseman");

                    b.HasDiscriminator().HasValue("Horseman");

                    b.HasData(
                        new { Id = 2, AttackPoint = 6, DefensePoint = 2, Payment = 1, Price = 50, Supply = 1 }
                    );
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

                    b.HasOne("StrategyGame.Models.Innovation", "Innovation")
                        .WithMany("CountryInnovations")
                        .HasForeignKey("InnovationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StrategyGame.Models.CountryInnovationProgress", b =>
                {
                    b.HasOne("StrategyGame.Models.Country", "Country")
                        .WithMany("CountryInnovationProgress")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

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
