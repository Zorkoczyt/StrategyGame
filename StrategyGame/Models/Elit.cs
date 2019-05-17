using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class Elit : Unit
    {
        public Elit()
        {
            Price = 100;
            AttackPoint = 5;
            DefensePoint = 5;
            Payment = 3;
            Supply = 2;
        }

        public override UnitType Type => UnitType.Elit;
    }
}
