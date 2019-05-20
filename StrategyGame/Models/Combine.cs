using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class Combine : Innovation
    {
        public Combine()
        {
            UpgradeStat = 1.15;
            Point = 100;
        }

        public override InnovationType Type => InnovationType.Combine;
    }
}
