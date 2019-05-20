using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class InnovationProgressViewModel
    {
        public Innovation Innovation{ get; set; }
        public int TurnsLeft { get; set; }

        public InnovationProgressViewModel(CountryInnovationProgress countryInnovationProgress)
        {
            Innovation = countryInnovationProgress.Innovation;
            TurnsLeft = countryInnovationProgress.TurnsLeft;
        }
    }
}
