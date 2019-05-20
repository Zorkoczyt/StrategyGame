using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class Battle
    {
        public int Id { get; set; }
        public int AttackingCountryId { get; set; }
        public virtual Country AttackingCountry { get; set; }
        public virtual ICollection<AttackingCountryUnit> AttackingCountryUnits { get; set; }
        public double AttackPoints { get; set; }
        public int DefendingCountryId { get; set; }
        public virtual Country DefendingCountry { get; set; }
        public virtual ICollection<CountryUnit> DefendingCountryUnits { get; set; }
        public Battle()
        {
        }

        public Battle(Country attackingCountry, Country defendingCountry)
        {
            AttackingCountryId = attackingCountry.Id;
            AttackingCountry = attackingCountry;
            AttackingCountryUnits = new List<AttackingCountryUnit>();
            DefendingCountryId = defendingCountry.Id;
            DefendingCountry = defendingCountry;
        }
    }
}
