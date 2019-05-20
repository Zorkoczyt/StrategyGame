using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Exceptions;
using StrategyGame.Models;
using StrategyGame.Service;
using StrategyGame.ViewModels;

namespace StrategyGame.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _countryService.ListAllCountryByPointAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryCreateEditViewModel countryViewModel)
        {
            if (ModelState.IsValid)
            {
                await _countryService.CreateAsync(countryViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(countryViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var country = await _countryService.FindCountryByIdAsync(id);
            return View(country);
        }

        public async Task<IActionResult> AddUnit(int id)
        {
            AddUnitViewModel selectedUnitiewModel = new AddUnitViewModel();
            selectedUnitiewModel.Id = id;
            selectedUnitiewModel.Units = await _countryService.ListUnitsAsync();
            return View(selectedUnitiewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUnit(AddUnitViewModel addUnitViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _countryService.AddUnitAsync(addUnitViewModel.Id, addUnitViewModel.Quantity, addUnitViewModel.UnitId);
                    await _countryService.CalculateBattlePointsAsync(addUnitViewModel.Id);
                    return RedirectToAction("Details", new { @id = addUnitViewModel.Id });
                }
                catch (GameException e)
                {
                    ModelState.AddModelError(e.Key, e.Description);
                }
            }
            addUnitViewModel.Units = await _countryService.ListUnitsAsync();
            return View(addUnitViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CountryDetailsViewModel countryDetailsViewModel = await _countryService.FindCountryByIdAsync(id);
            if (countryDetailsViewModel == null)
            {
                return NotFound();
            }

            return View(countryDetailsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _countryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddBuilding(int id)
        {
            SelectedBuildingViewModel selectedBuildingViewModel = new SelectedBuildingViewModel();
            selectedBuildingViewModel.Buildings = await _countryService.ListBuildingsAsync();
            selectedBuildingViewModel.Id = id;
            return View(selectedBuildingViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBuilding(SelectedBuildingViewModel selectedBuildingViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _countryService.AddBuildingAsync(selectedBuildingViewModel.Id, selectedBuildingViewModel.BuildingId);
                    return RedirectToAction("Details", new { @id = selectedBuildingViewModel.Id });
                }
                catch (GameException e)
                {
                    ModelState.AddModelError(e.Key, e.Description);
                }
            }
            selectedBuildingViewModel.Buildings = await _countryService.ListBuildingsAsync();
            return View(selectedBuildingViewModel);

        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _countryService.GetCountryById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CountryCreateEditViewModel countryViewModel)
        {
            await _countryService.EditAsync(id, countryViewModel);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AddInnovation(int id)
        {
            SelectedInnovationViewModel selectedInnovationViewModel = new SelectedInnovationViewModel
            {
                Innovations = await _countryService.ListCountryAvailableInnovationsAsync(id),
                Id = id
            };
            return View(selectedInnovationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInnovation(SelectedInnovationViewModel selectedInnovationViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _countryService.AddInnovationAsync(selectedInnovationViewModel.Id, selectedInnovationViewModel.InnovationId);
                    return RedirectToAction("Details", new { @id = selectedInnovationViewModel.Id });
                }
                catch (GameException e)
                {
                    ModelState.AddModelError(e.Key, e.Description);
                }
            }
            selectedInnovationViewModel.Innovations = await _countryService.ListCountryAvailableInnovationsAsync(selectedInnovationViewModel.Id);
            return View(selectedInnovationViewModel);
        }

        public async Task<IActionResult> GroupingUnit(int id)
        {
            GroupUnitViewModel groupUnitViewModel = new GroupUnitViewModel
            {
                Id = id,
                Units = await _countryService.ListUnitsAsync(),
                CountryUnits = await _countryService.ListCountryUnitsAsync(id)
            };
            return View(groupUnitViewModel);
        }

        public async Task<IActionResult> Attack(int id)
        {
            AttackViewModel attackViewModel = new AttackViewModel();
            attackViewModel.Id = id;
            attackViewModel.Units = await _countryService.ListUnitsAsync();
            attackViewModel.CountryUnits = await _countryService.ListCountryUnitsAsync(id);
            attackViewModel.Countries = await _countryService.ListEnememyCountries(id);
            return View(attackViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Attack(AttackViewModel attackViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _countryService.AttackAsync(attackViewModel.Id,
                        attackViewModel.UnitId,
                        attackViewModel.EnemyCountryId,
                        attackViewModel.Quantity);
                    await _countryService.CalculateBattlePointsAsync(attackViewModel.Id);
                }
                catch (GameException e)
                {
                    ModelState.AddModelError(e.Key, e.Description);
                }
            }
            attackViewModel.CountryUnits = await _countryService.ListCountryUnitsAsync(attackViewModel.Id);
            attackViewModel.Countries = await _countryService.ListEnememyCountries(attackViewModel.Id);
            attackViewModel.Units = await _countryService.ListUnitsAsync();
            return View(attackViewModel);
        }
    }
}