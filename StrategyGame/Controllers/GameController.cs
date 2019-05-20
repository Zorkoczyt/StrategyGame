using Microsoft.AspNetCore.Mvc;
using StrategyGame.Models;
using StrategyGame.Service;
using StrategyGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _gameService.GetRoundAsync());
        }

        public async Task<IActionResult> TriggerRound(int? id)
        {
            Game game = await _gameService.GetGame();
            RoundViewModel roundViewModel = new RoundViewModel(game);
            return View(roundViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> TriggerRound()
        {
            await _gameService.ProcessRoundAsync();
            return RedirectToAction(nameof(TriggerRound));
        }
    }
}
