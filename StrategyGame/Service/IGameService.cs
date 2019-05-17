using StrategyGame.Models;
using StrategyGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Service
{
    public interface IGameService
    {
        Task ProcessRound();
        Task<Game> GetGame();
        Task<RoundViewModel> GetRound();
        IEnumerable<Country> ListCountriesByLeaderBoard(Game game);
    }
}
