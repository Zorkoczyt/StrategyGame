using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class Barrack : Building
    {
        public int Soldiers{ get; set; }

        public override BuildingType Type => BuildingType.Barrack;

        public Barrack()
        {
            Id = 2;
            Soldiers = 200;
        }
    }
}
