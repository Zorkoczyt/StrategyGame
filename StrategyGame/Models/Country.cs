using StrategyGame.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Point { get; set; }
        public double Potato { get; set; }
        public double Gold { get; set; }
        public int Population { get; set; }
        public double AttackPoint { get; set; }
        public double DefensePoint { get; set; }
        public virtual ICollection<CountryBuilding> CountryBuildings { get; set; }
        public virtual List<CountryBuildingProgress> CountryBuildingProgresses { get; set; }
        public virtual ICollection<CountryInnovation> CountryInnovations { get; set; }
        public virtual ICollection<CountryInnovationProgress> CountryInnovationProgresses { get; set; }
        public virtual ICollection<CountryUnit> CountryUnits  { get; set; }
        public virtual ICollection<AttackingCountryUnit> AttackingCountryUnits { get; set; }

        public Country()
        {
            CountryUnits = new List<CountryUnit>();
            CountryBuildingProgresses = new List<CountryBuildingProgress>();
            CountryBuildings = new List<CountryBuilding>();
            CountryInnovations = new List<CountryInnovation>();
            CountryInnovationProgresses = new List<CountryInnovationProgress>();
            AttackingCountryUnits = new List<AttackingCountryUnit>();
        }
        public Country(CountryCreateEditViewModel countryView)
        {
            Name = countryView.Name;
            CountryUnits = new List<CountryUnit>();
            CountryBuildingProgresses = new List<CountryBuildingProgress>();
            CountryBuildings = new List<CountryBuilding>();
            CountryInnovations = new List<CountryInnovation>();
            CountryInnovationProgresses = new List<CountryInnovationProgress>();
            AttackingCountryUnits = new List<AttackingCountryUnit>();
        }
    }
}
