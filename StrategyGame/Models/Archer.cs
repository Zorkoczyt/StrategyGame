using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class Archer : Unit
    {
        public Archer()
        {
            Price = 50;
            AttackPoint = 2;
            DefensePoint = 6;
            Payment = 1;
            Supply = 1;
        }

        public override UnitType Type => UnitType.Archer;
    }
}
