using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class CityWall : Innovation
    {
        public CityWall()
        {
            UpgradeStat = 1.2;
            Point = 100;
        }
        public override InnovationType Type => InnovationType.CityWall;
    }
}
