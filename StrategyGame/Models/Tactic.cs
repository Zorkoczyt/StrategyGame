using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class Tactic : Innovation
    {
        public Tactic()
        {
            UpgradeStat = 1.1;
        }
        public override InnovationType Type => InnovationType.Tactic;
    }
}
