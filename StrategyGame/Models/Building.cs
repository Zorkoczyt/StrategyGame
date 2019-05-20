using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public abstract class Building
    {
        public int Id { get; set; }
        public ICollection<CountryBuilding> CountryBuildings { get; set; }
        public abstract BuildingType Type { get; }
        public int Point { get; set; }
    }
}
