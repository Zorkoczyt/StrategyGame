using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class CountryUnit
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int Count { get; set; }
        public GroupingType GroupingType { get; set; }

        public CountryUnit()
        {
            GroupingType = GroupingType.Defending;
        }
    }
}
