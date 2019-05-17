using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public abstract class Unit
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int AttackPoint { get; set; }
        public int DefensePoint { get; set; }
        public int Payment { get; set; }
        public int Supply { get; set; }
        public abstract UnitType Type { get; }
        public ICollection<CountryUnit> CountryUnit { get; set; }
    }
}
