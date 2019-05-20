using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class BattleViewModel
    {
        public int Id { get; set; }
        public List<Battle> Battles { get; set; }
        public BattleViewModel()
        {
            Battles = new List<Battle>();
        }
    }
}
