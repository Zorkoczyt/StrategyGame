using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class AttackingCountryUnit : CountryUnit
    {
        public AttackingCountryUnit()
        {

        }

        public AttackingCountryUnit(CountryUnit countryUnit)
        {
            CountryId = countryUnit.CountryId;
            Country = countryUnit.Country;
            UnitId = countryUnit.UnitId;
            Unit = countryUnit.Unit;
            GroupingType = GroupingType.Attacking;
            Count = countryUnit.Count;
        }
    }

}
