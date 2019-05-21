using Microsoft.EntityFrameworkCore;
using StrategyGame.Models;
using StrategyGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Service
{
    public class GameService : IGameService
    {
        private readonly StrategyGameContext _context;

        public GameService(StrategyGameContext context)
        {
            _context = context;
        }

        public async Task ProcessRoundAsync()
        {
            Game game = await _context.Games
                .Include(x => x.Countries)
                    .ThenInclude(x => x.CountryBuildings)
                        .ThenInclude(x => x.Building)
                .Include(x => x.Countries)
                    .ThenInclude(x => x.CountryUnits)
                        .ThenInclude(x => x.Unit)
                .Include(x => x.Countries)
                    .ThenInclude(x => x.CountryBuildingProgresses)
                    .ThenInclude(x => x.Building)
                .Include(x => x.Countries)
                    .ThenInclude(x => x.CountryInnovationProgresses)
                    .ThenInclude(x => x.Innovation)
                .Include(x => x.Countries)
                    .ThenInclude(x => x.CountryInnovations)
                    .ThenInclude(x => x.Innovation)
                .Include(x => x.Battles)
                .FirstOrDefaultAsync();
            game.Turn += 1;
            ProcessTaxCredit(game);
            ProcessPotato(game);
            PayMilitary(game);
            FeedingMilitary(game);
            await ProcessInnovation(game);
            ProcessBuilding(game);
            DoBattle(game);
            CalculateCountryPoint(game);
            CalculateBattlePoints(game);
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }
        public async Task<RoundViewModel> GetRoundAsync()
        {
            Game game = await _context.Games
                .FirstOrDefaultAsync();
            RoundViewModel roundViewModel = new RoundViewModel(game);
            return roundViewModel;
        }
        public void CalculateCountryPoint(Game game)
        {
            int newCountryPoint;
            ICollection<Country> countries = game.Countries;
            foreach (var country in countries)
            {
                newCountryPoint = country.CountryUnits
                    .Aggregate(0, (total, unit) => total + unit.Count * unit.Unit.Point);

                newCountryPoint += country.CountryBuildings
                    .Aggregate(0, (total, building) => building.Count * building.Building.Point + total);

                newCountryPoint += country.CountryInnovations
                    .Aggregate(0, (total, innovation) => total + innovation.Innovation.Point);
                newCountryPoint += country.Population;

                country.Point = newCountryPoint;
            }
        }
        public IEnumerable<Country> ListCountriesByLeaderBoard(Game game)
        {
            IEnumerable<Country> countryListInOrder = game.Countries
                .OrderBy(country => country.Point);

            return countryListInOrder;
        }

        public void ProcessTaxCredit(Game game)
        {
            ICollection<Country> countries = game.Countries;

            foreach (var country in countries)
            {
                country.Gold += country.Population * 25 * TaxUpgradeInnovation(country);
            }
        }

        public void ProcessPotato(Game game)
        {
            ICollection<Country> countries = game.Countries;
            int farmNum = 0;

            foreach (var country in countries)
            {
                farmNum = country.CountryBuildings
                    .Aggregate(0, (total, building) => building.Building.Type == BuildingType.Farm ? total + building.Count : total + 0);

                country.Potato += farmNum * 200 * PotatoUpgradeInnovation(country);
            }
        }

        public void PayMilitary(Game game)
        {
            ICollection<Country> countries = game.Countries;

            foreach (var country in countries)
            {
                int payment = 0;

                payment = country.CountryUnits
                    .Aggregate(0, (total, unit) => total + unit.Unit.Payment * unit.Count);
                country.Gold -= payment;
            }
        }

        public async Task<Game> GetGame()
        {
            return await _context.Games.FirstOrDefaultAsync();
        }

        private void ProcessBuilding(Game game)
        {
            ICollection<Country> countries = game.Countries;
            //refactor flatten

            foreach (var country in countries)
            {
                foreach (var buildingProgress in country.CountryBuildingProgresses)
                {
                    if (buildingProgress.TurnsLeft == 1)
                    {
                        if (buildingProgress.Building.Type == BuildingType.Farm)
                        {
                            country.Population += 50;
                        }

                        foreach (var countryBuilding in country.CountryBuildings)
                        {
                            if (buildingProgress.BuildingId == countryBuilding.BuildingId)
                            {
                                countryBuilding.Count += 1;
                                _context.CountryBuildings.Update(countryBuilding);
                            }
                        }

                        _context.CountryBuildingProgresses.Remove(buildingProgress);
                        _context.Countries.Update(country);
                    }
                    else
                    {
                        buildingProgress.TurnsLeft--;
                    }
                }
            }
        }

        public void FeedingMilitary(Game game)
        {
            ICollection<Country> countries = game.Countries;

            foreach (var country in countries)
            {
                int supply = country.CountryUnits
                    .Aggregate(0, (total, unit) => total + unit.Unit.Supply * unit.Count);
                country.Potato -= supply;
            }
        }

        public async Task ProcessInnovation(Game game)
        {
            ICollection<Country> countries = game.Countries;
            CountryInnovation countryInnovation;
            List<CountryInnovationProgress> countryInnovationProgresses = await _context.CountryInnovationProgresses.ToListAsync();
            foreach (var country in countries)
            {
                foreach (var countryInnovationProgress in countryInnovationProgresses)
                {
                    if (country.Id == countryInnovationProgress.CountryId)
                    {
                        if (countryInnovationProgress.TurnsLeft == 1)
                        {
                            countryInnovation = new CountryInnovation
                            {
                                CountryId = country.Id,
                                Country = country,
                                InnovationId = countryInnovationProgress.InnovationId,
                                Innovation = countryInnovationProgress.Innovation
                            };
                            _context.CountryInnovationProgresses.Remove(countryInnovationProgress);
                            country.CountryInnovations.Add(countryInnovation);
                            country.CountryInnovationProgresses.Remove(countryInnovationProgress);
                            _context.Countries.Update(country);
                            _context.CountryInnovations.Add(countryInnovation);
                        }
                        else
                        {
                            countryInnovationProgress.TurnsLeft--;
                        }
                    }
                }
            }
        }
        public double PotatoUpgradeInnovation(Country country)
        {
            double upgrade = 1;
            foreach (var countryInnovation in country.CountryInnovations)
            {
                if (countryInnovation.Innovation.Type == InnovationType.Truck)
                {
                    upgrade = countryInnovation.Innovation.UpgradeStat;
                }
                else if (countryInnovation.Innovation.Type == InnovationType.Combine)
                {
                    upgrade += countryInnovation.Innovation.UpgradeStat;
                }
            }

            return upgrade;
        }

        public double TaxUpgradeInnovation(Country country)
        {
            double upgrade = 1;
            foreach (var countryInnovation in country.CountryInnovations)
            {
                if (countryInnovation.Innovation.Type == InnovationType.Alchemy)
                {
                    upgrade = countryInnovation.Innovation.UpgradeStat;
                }
            }

            return upgrade;
        }
        public void DoBattle(Game game)
        {
            ICollection<Battle> battles = game.Battles;
            foreach (var battle in battles)
            {
                double actualCountryAttackPoint = CalculateBattleAttackPoint(battle) * UpgradeAttackPoint(battle.AttackingCountry);
                if (actualCountryAttackPoint > battle.DefendingCountry.DefensePoint)
                {
                    CalculateDefendingArmyLoss(battle.DefendingCountry);
                    battle.AttackingCountry.Gold += CalculateGoldLoot(battle.DefendingCountry);
                    battle.AttackingCountry.Potato += CalculatePotatoLoot(battle.DefendingCountry);
                    battle.DefendingCountry.Gold -= CalculateGoldLoot(battle.DefendingCountry);
                    battle.DefendingCountry.Potato -= CalculatePotatoLoot(battle.DefendingCountry);
                }
                else if (battle.DefendingCountry.DefensePoint > actualCountryAttackPoint)
                {
                    CalculateAttackingArmyLoss(battle.AttackingCountryUnits);
                }
                SendUnitHome(battle);
                _context.Battles.Remove(battle);
            }
        }

        public double CalculateBattleAttackPoint(Battle battle)
        {
            double attackPoints = 0;

            foreach (var unit in battle.AttackingCountryUnits)
            {
                attackPoints += unit.Unit.AttackPoint * unit.Count;
            }

            return attackPoints;
        }

        public void SendUnitHome(Battle battle)
        {
            foreach (var attackingUnit in battle.AttackingCountryUnits)
            {
                foreach (var countryUnit in battle.AttackingCountry.CountryUnits.ToList())
                {
                    if (attackingUnit.UnitId == countryUnit.UnitId)
                    {
                        if (attackingUnit.GroupingType == GroupingType.Attacking)
                        {
                            countryUnit.Count += attackingUnit.Count;
                            attackingUnit.Count -= attackingUnit.Count;
                        }
                        if (countryUnit.GroupingType == GroupingType.Attacking)
                        {
                            battle.AttackingCountry.CountryUnits.Remove(countryUnit);
                        }
                    }
                }
            }
            battle.AttackingCountry.AttackingCountryUnits.Clear();
        }
        public void CalculateAttackingArmyLoss(ICollection<AttackingCountryUnit> attackingCountryUnit)
        {
            foreach (var unit in attackingCountryUnit)
            {
                unit.Count = (int)(unit.Count * 0.9);
            }
        }
        public void CalculateDefendingArmyLoss(Country country)
        {
            foreach (var unit in country.CountryUnits)
            {
                if (unit.GroupingType == GroupingType.Defending)
                    unit.Count = (int)(unit.Count * 0.9);
            }
        }

        public double CalculateGoldLoot(Country country)
        {
            double gold = country.Gold / 2;

            return gold;
        }

        public double CalculatePotatoLoot(Country country)
        {
            double potato = country.Potato / 2;

            return potato;
        }

        public void CalculateBattlePoints(Game game)
        {
            ICollection<Country> countries = game.Countries;

            foreach (var country in countries)
            {
                double attackPoint = 0;
                double defensePoint = 0;
                foreach (var unit in country.CountryUnits)
                {
                    if (unit.GroupingType == GroupingType.Attacking)
                    {
                        attackPoint += unit.Count * unit.Unit.AttackPoint;
                    }
                    else
                    {
                        defensePoint += unit.Count * unit.Unit.DefensePoint;
                    }
                }
                country.AttackPoint = attackPoint * UpgradeAttackPoint(country);
                country.DefensePoint = defensePoint * UpgradeDefensePoint(country);
            }
        }

        public double UpgradeAttackPoint(Country country)
        {
            double upgrade = 1;
            foreach (var innovation in country.CountryInnovations)
            {
                if (innovation.Innovation.Type == InnovationType.OperationRebirth)
                {
                    upgrade *= 1.2;
                }
                else if (innovation.Innovation.Type == InnovationType.Tactic)
                {
                    upgrade *= 1.1;
                }
            }
            return upgrade;
        }
        public double UpgradeDefensePoint(Country country)
        {
            double upgrade = 1;
            foreach (var innovation in country.CountryInnovations)
            {
                if (innovation.Innovation.Type == InnovationType.CityWall)
                {
                    upgrade *= 1.2;
                }
                else if (innovation.Innovation.Type == InnovationType.Tactic)
                {
                    upgrade *= 1.1;
                }
            }
            return upgrade;
        }
    }
}
