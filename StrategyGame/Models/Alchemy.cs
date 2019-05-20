using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class Alchemy : Innovation
    {
        public Alchemy()
        {
            UpgradeStat = 1.3;
            Point = 100;
        }

        public override InnovationType Type => InnovationType.Alchemy;
    }
}
