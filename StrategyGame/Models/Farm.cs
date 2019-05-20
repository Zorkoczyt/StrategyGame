using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class Farm : Building
    {
        public int Population { get; set; }
        public int Potato { get; set; }

        public override BuildingType Type => BuildingType.Farm;

        public Farm()
        {
            Id = 1;
            Population = 50;
            Potato = 200;
            Point = 50;
        }
    }
}
