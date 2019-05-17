using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class AttackCountryViewModel
    {
        public int Id { get; set; }
        public int EnemyCountryId { get; set; }
        public List<Country> Countries { get; set; }
    }
}
