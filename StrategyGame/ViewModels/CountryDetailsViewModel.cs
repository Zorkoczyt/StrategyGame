using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class CountryDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Potato { get; set; }
        public double Gold { get; set; }
        public int Population { get; set; }
        public double AttackPoint { get; set; }
        public double DefensePoint { get; set; }
        public virtual ICollection<CountryBuilding> CountryBuildings { get; set; }
        public virtual ICollection<CountryUnit> CountryUnits { get; set; }
        public virtual ICollection<CountryInnovation> CountryInnovations { get; set; }
        public BuildingProgressViewModel BuildingProgressViewModel { get; set; }
        public InnovationProgressViewModel InnovationProgressViewModel { get; set; }
        public BattleViewModel BattleViewModel { get; set; }
        public CountryDetailsViewModel(Country country)
        {
            Id = country.Id;
            Name = country.Name;
            Potato = Math.Round(country.Potato,2);
            Gold = Math.Round(country.Gold,2);
            Population = country.Population;
            AttackPoint = country.AttackPoint;
            DefensePoint = country.DefensePoint;
            CountryBuildings = country.CountryBuildings;
            CountryUnits = country.CountryUnits;
            CountryInnovations = country.CountryInnovations;
        }
    }
}
