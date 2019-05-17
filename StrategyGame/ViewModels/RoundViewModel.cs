using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class RoundViewModel
    {
        public int Turn { get; set; }

        public RoundViewModel(Game game)
        {
            Turn = game.Turn;
        }
    }
}
