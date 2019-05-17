using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class SelectedBuildingViewModel
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public List<Building> Buildings { get; set; }
    }
}
