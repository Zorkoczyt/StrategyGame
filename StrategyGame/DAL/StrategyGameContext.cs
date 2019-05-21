using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class StrategyGameContext : DbContext
    {
        public StrategyGameContext(DbContextOptions<StrategyGameContext> options)
            : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Building> Buildings{ get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Innovation> Innovations { get; set; }
        public DbSet<CountryBuilding> CountryBuildings { get; set; }
        public DbSet<CountryBuildingProgress> CountryBuildingProgresses { get; set; }
        public DbSet<CountryInnovation> CountryInnovations { get; set; }
        public DbSet<CountryInnovationProgress> CountryInnovationProgresses { get; set; }
        public DbSet<CountryUnit> CountryUnits { get; set; }
        public DbSet<Game> Games { get; set; }

        public DbSet<Battle> Battles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archer>()
                .HasBaseType<Unit>();
            modelBuilder.Entity<Horseman>()
                .HasBaseType<Unit>();
            modelBuilder.Entity<Elit>()
                .HasBaseType<Unit>();
            modelBuilder.Entity<Farm>().
                HasBaseType<Building>();
            modelBuilder.Entity<Barrack>()
                .HasBaseType<Building>();
            modelBuilder.Entity<Truck>()
                .HasBaseType<Innovation>();
            modelBuilder.Entity<Combine>()
                .HasBaseType<Innovation>();
            modelBuilder.Entity<CityWall>()
                .HasBaseType<Innovation>();
            modelBuilder.Entity<OperationRebirth>()
                .HasBaseType<Innovation>();
            modelBuilder.Entity<Tactic>()
                .HasBaseType<Innovation>();
            modelBuilder.Entity<Alchemy>()
                .HasBaseType<Innovation>();
            modelBuilder.Entity<AttackingCountryUnit>()
                .HasBaseType<CountryUnit>();

            modelBuilder.Entity<CountryUnit>()
                .HasDiscriminator<string>("Grouping type")
                .HasValue<CountryUnit>("Defending")
                .HasValue<AttackingCountryUnit>("Attacking");

            modelBuilder.Entity<CountryUnit>()
                .HasOne(x => x.Country)
                .WithMany(x => x.CountryUnits)
                .HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<CountryBuilding>()
                .HasOne(x => x.Country)
                .WithMany(x => x.CountryBuildings)
                .HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<CountryInnovation>()
                .HasOne(x => x.Country)
                .WithMany(x => x.CountryInnovations)
                .HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<CountryInnovationProgress>()
                .HasOne(x => x.Country)
                .WithMany(x => x.CountryInnovationProgresses)
                .HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<CountryBuildingProgress>()
                .HasOne(x => x.Country)
                .WithMany(x => x.CountryBuildingProgresses)
                .HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<Archer>().HasData(new Archer { Id = 1});
            modelBuilder.Entity<Horseman>().HasData(new Horseman { Id = 2});
            modelBuilder.Entity<Elit>().HasData(new Elit { Id = 3});
            modelBuilder.Entity<Farm>().HasData(new Farm { Id = 1 });
            modelBuilder.Entity<Barrack>().HasData(new Barrack { Id = 2 });
            modelBuilder.Entity<Game>().HasData(new Game { Id = 1});
            modelBuilder.Entity<Truck>().HasData(new Truck { Id = 1});
            modelBuilder.Entity<Combine>().HasData(new Combine { Id = 2});
            modelBuilder.Entity<CityWall>().HasData(new CityWall { Id = 3});
            modelBuilder.Entity<OperationRebirth>().HasData(new OperationRebirth { Id = 4});
            modelBuilder.Entity<Tactic>().HasData(new Tactic { Id = 5});
            modelBuilder.Entity<Alchemy>().HasData(new Alchemy { Id = 6});
        }
    }
}
