using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace StrategyGame.Models

{
    public abstract class Innovation
    {
        public int Id { get; set; }
        public double UpgradeStat { get; set; }
        public ICollection<CountryInnovation> CountryInnovations { get; set; }
        public abstract InnovationType Type { get; }
        public int Point { get; set; }
    }
}
