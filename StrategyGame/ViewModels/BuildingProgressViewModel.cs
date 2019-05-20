using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class BuildingProgressViewModel
    {
        public Building Building { get; set; }
        public int TurnsLeft { get; set; }

        public BuildingProgressViewModel(CountryBuildingProgress countryBuildingProgress)
        {
            Building = countryBuildingProgress.Building;
            TurnsLeft = countryBuildingProgress.TurnsLeft;
        }
    }
}
