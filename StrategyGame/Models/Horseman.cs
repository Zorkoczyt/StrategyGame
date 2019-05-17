using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class Horseman : Unit
    {
        public Horseman()
        {
            Price = 50;
            AttackPoint = 6;
            DefensePoint = 2;
            Payment = 1;
            Supply = 1;
        }

        public override UnitType Type => UnitType.Horseman;
    }
}
