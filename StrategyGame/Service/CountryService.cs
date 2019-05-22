using StrategyGame.Models;
using StrategyGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Exceptions;

namespace StrategyGame.Service
{
    public class CountryService : ICountryService
    {
        private readonly StrategyGameContext _context;

        public CountryService(StrategyGameContext context)
        {
            _context = context;
        }

        public Task CreateAsync(CountryCreateEditViewModel countryView)
        {
            Country country = new Country(countryView);
            _context.Countries.Add(country);

            CountryBuilding farm = new CountryBuilding
            {
                CountryId = country.Id,
                Country = country,
                BuildingId = 1,
                Count = 0
            };
            CountryBuilding barrack = new CountryBuilding
            {
                CountryId = country.Id,
                Country = country,
                BuildingId = 2,
                Count = 0
            };

            _context.CountryBuildings.Add(farm);
            _context.CountryBuildings.Add(barrack);

            Game game = _context.Games.FirstOrDefault();
            game.Countries.Add(country);
            _context.Games.Update(game);

            return _context.SaveChangesAsync();
        }

        public async Task<List<CountryListViewModel>> ListAllCountryByPointAsync()
        {
            List<CountryListViewModel> countryListViewModels = new List<CountryListViewModel>();
            List<Country> countries = await _context.Countries.ToListAsync();
            countries.ForEach(country => countryListViewModels.Add(new CountryListViewModel(country)));
            List<CountryListViewModel> countriesOrderByPoint = countryListViewModels
                .OrderByDescending(c => c.Point).ToList();

            return countriesOrderByPoint;
        }

        public async Task<CountryDetailsViewModel> FindCountryByIdAsync(int? id)
        {
            Country country = await _context.Countries
                .Include(x => x.CountryBuildings)
                    .ThenInclude(x => x.Building)
                .Include(x => x.CountryUnits)
                    .ThenInclude(x => x.Unit)
                .Include(x => x.CountryInnovations)
                    .ThenInclude(x => x.Innovation)
                .Include(x => x.CountryBuildingProgresses)
                    .ThenInclude(x => x.Building)
                .Include(x => x.CountryInnovationProgresses)
                    .ThenInclude(x => x.Innovation)
                .FirstOrDefaultAsync(m => m.Id == id);

            BattleViewModel battleViewModel = await DisplayBattleDetails(id);
            CountryDetailsViewModel countryDetailsViewModel = new CountryDetailsViewModel(country);

            if (battleViewModel != null)
            {
                countryDetailsViewModel.BattleViewModel = battleViewModel;
            }

            return countryDetailsViewModel;
        }

        public Task<List<Unit>> ListUnitsAsync()
        {
            return _context.Units.ToListAsync();
        }

        public async Task AddUnitAsync(int id, int quantity, int unitId)
        {
            int unitQuantity = 0;
            Country country = await _context.Countries
                .SingleAsync(m => m.Id == id);
            Unit unit = await _context.Units
                .SingleAsync(u => u.Id == unitId);
            var units = await _context.CountryUnits
                .Where(c => c.CountryId == id)
                .Where(u => u.UnitId == unitId)
                .FirstOrDefaultAsync();

            if (quantity <= 0)
            {
                throw new GameException("Quantity", "Quantity cannot be null or negative");
            }

            if (!IsFreeBarrackCapacity(country, quantity))
            {
                throw new GameException("Quantity", "Not enough capacity in barracks!");
            }

            if (unit.Price * quantity > country.Gold)
            {
                throw new GameException("Quantity", "Not enough Gold!");
            }

            if (units == null)
            {
                CountryUnit countryUnit = new CountryUnit
                {
                    CountryId = country.Id,
                    Country = country,
                    UnitId = unit.Id,
                    Unit = unit,
                    Count = quantity
                };
                country.CountryUnits.Add(countryUnit);
                unitQuantity += quantity;
                country.Gold -= unit.Price * quantity;
                _context.Countries.Update(country);
                _context.CountryUnits.Add(countryUnit);
            }
            else
            {
                units.Count += quantity;
                country.Gold -= unit.Price * quantity;
                _context.Countries.Update(country);
                _context.CountryUnits.Update(units);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<CountryBuilding>> ListBuildingsAsync(int id)
        {
            List<CountryBuilding> countryBuildings = await _context.CountryBuildings
                                                                .Where(c => c.CountryId == id)
                                                                .ToListAsync();
            return countryBuildings;
        }

        public async Task DeleteAsync(int id)
        {
            var battles = await _context.Battles
                .Where(c => c.AttackingCountryId == id)
                .FirstOrDefaultAsync();
            var country = await _context.Countries
                .SingleAsync(m => m.Id == id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
        }

        public Task<List<CountryUnit>> ListCountryUnitsAsync(int id)
        {
            var countryUnits = _context.CountryUnits
                .Where(c => c.CountryId == id).ToListAsync();

            return countryUnits;
        }

        public bool IsFreeBarrackCapacity(Country country, int quantity)
        {
            bool isFree = true;
            var barracks = _context.CountryBuildings
                                        .Where(c => c.CountryId == country.Id)
                                        .Where(b => b.Building.Type == BuildingType.Barrack)
                                        .FirstOrDefault();

            int barracksCapacity = barracks.Count * 200;
            var units = _context.CountryUnits
                .Where(c => c.CountryId == country.Id);
            int numOfUnits = 0;
            foreach (var unit in units)
            {
                numOfUnits += unit.Count;
            }
            if (barracksCapacity >= numOfUnits + quantity)
            {
                isFree = true;
            }
            else
            {
                isFree = false;
            }
            return isFree;
        }

        //Egy épület hozzáadás

        //public async Task AddBuildingAsync(int countryId, int buildingId)
        //{
        //    Country country = await _context.Countries
        //        .SingleAsync(c => c.Id == countryId);

        //    var buildingProgress = await _context.CountryBuildingProgresses
        //                                .Where(c => c.CountryId == countryId)
        //                                .FirstOrDefaultAsync();

        //    if (buildingProgress != null)
        //    {
        //        throw new GameException("BuildingId", "Another construction is in progress!");
        //    }
        //    Building building = await _context.Buildings
        //        .FirstOrDefaultAsync(b => b.Id == buildingId);

        //    CountryBuildingProgress countryBuildingProgress = new CountryBuildingProgress
        //    {
        //        CountryId = country.Id,
        //        Country = country,
        //        BuildingId = building.Id,
        //        Building = building,
        //        TurnsLeft = 5
        //    };
        //    _context.CountryBuildingProgresses.Add(countryBuildingProgress);
        //    await _context.SaveChangesAsync();
        //}

        //Több épület hozzáaddás
        public async Task AddBuildingAsync(int countryId, int buildingId)
        {
            Country country = await _context.Countries
                .Include(x => x.CountryBuildingProgresses)
                .SingleAsync(c => c.Id == countryId);

            Building building = await _context.Buildings
                .SingleAsync(b => b.Id == buildingId);

            CountryBuildingProgress countryBuildingProgress = new CountryBuildingProgress
            {
                CountryId = country.Id,
                Country = country,
                BuildingId = building.Id,
                Building = building,
                TurnsLeft = 5
            };

            _context.CountryBuildingProgresses.Add(countryBuildingProgress);
            await _context.SaveChangesAsync();

        }

        public Task<List<Building>> ListBuildingsAsync()
        {
            return _context.Buildings.ToListAsync();
        }

        public async Task<CountryCreateEditViewModel> GetCountryById(int id)
        {
            Country country = await _context.Countries.SingleAsync(c => c.Id == id);
            CountryCreateEditViewModel countryViewModel = new CountryCreateEditViewModel(country);
            return countryViewModel;
        }

        public async Task EditAsync(int id, CountryCreateEditViewModel countryViewModel)
        {
            Country country = await _context.Countries.SingleAsync(c => c.Id == id);
            country.Name = countryViewModel.Name;
            _context.Update(country);

            await _context.SaveChangesAsync();
        }

        public Task<List<Innovation>> ListInnovationssAsync()
        {
            return _context.Innovations.ToListAsync();
        }

        //Egy fejlesztés hozzáadása

        public async Task AddInnovationAsync(int id, int innovationId)
        {
            Country country = await _context.Countries.SingleAsync(c => c.Id == id);
            Innovation innovation = await _context.Innovations.SingleAsync(i => i.Id == innovationId);
            var countryInnovations = await _context.CountryInnovations
                                                    .Where(c => c.CountryId == id)
                                                    .Where(i => i.InnovationId == innovationId)
                                                    .FirstOrDefaultAsync();
            var countryInnovationProgress = await _context.CountryInnovationProgresses
                .SingleOrDefaultAsync(c => c.CountryId == id);

            if (countryInnovationProgress != null)
            {
                throw new GameException("InnovationId", "Another innovation is under progress!");
            }
            CountryInnovationProgress newCountryInnovationProgress = new CountryInnovationProgress
            {
                CountryId = country.Id,
                Country = country,
                InnovationId = innovation.Id,
                Innovation = innovation,
                TurnsLeft = 15
            };
            _context.CountryInnovationProgresses.Add(newCountryInnovationProgress);
            await _context.SaveChangesAsync();
        }

        //Több fejlesztés hozzáadása

        //public async Task AddInnovationAsync(int id, int innovationId)
        //{
        //    Country country = await _context.Countries
        //        .Include(x => x.CountryInnovationProgresses)
        //        .SingleAsync(c => c.Id == id);
        //    Innovation innovation = await _context.Innovations
        //        .SingleAsync(i => i.Id == innovationId);
        //    var countryInnovations = await _context.CountryInnovationProgresses
        //        .Where(c => c.CountryId == id)
        //        .Where(i => i.InnovationId == innovationId)
        //        .FirstOrDefaultAsync();

        //    if (countryInnovations != null)
        //    {
        //        throw new GameException("InnovationId", "You've already owned this innovation!");
        //    }

        //    CountryInnovationProgress countryInnovationProgress = new CountryInnovationProgress
        //    {
        //        CountryId = country.Id,
        //        Country = country,
        //        InnovationId = innovation.Id,
        //        Innovation = innovation,
        //        TurnsLeft = 15
        //    };
        //    _context.CountryInnovationProgresses.Add(countryInnovationProgress);
        //    await _context.SaveChangesAsync();
        //}

        public async Task<List<CountryInnovation>> ListCountryInnovationsAsync(int id)
        {
            List<CountryInnovation> countryInnovations = await _context.CountryInnovations
                .Include(x => x.Innovation)
                .Where(c => c.CountryId == id)
                .ToListAsync();

            return countryInnovations;
        }

        public async Task<List<Innovation>> ListCountryAvailableInnovationsAsync(int id)
        {
            var countryInnovations = _context.CountryInnovations
               .Where(c => c.CountryId == id)
               .Select(c => c.InnovationId);

            var availableInnovations = await _context.Innovations
                .Where(x => !countryInnovations.Contains(x.Id))
                .ToListAsync();

            return availableInnovations;
        }

        public double UpgradeDefensePoint(Country country)
        {
            double upgrade = 1;
            foreach (var countryInnovation in country.CountryInnovations)
            {
                if (countryInnovation.Innovation.Type == InnovationType.CityWall)
                {
                    upgrade *= countryInnovation.Innovation.UpgradeStat;
                }
                else if (countryInnovation.Innovation.Type == InnovationType.Tactic)
                {
                    upgrade *= countryInnovation.Innovation.UpgradeStat;
                }
            }
            return upgrade;
        }

        public double UpgradeAttackPoint(Country country)
        {
            double upgrade = 1;
            foreach (var countryInnovation in country.CountryInnovations)
            {
                if (countryInnovation.Innovation.Type == InnovationType.OperationRebirth)
                {
                    upgrade *= countryInnovation.Innovation.UpgradeStat;
                }
                else if (countryInnovation.Innovation.Type == InnovationType.Tactic)
                {
                    upgrade *= countryInnovation.Innovation.UpgradeStat;
                }
            }
            return upgrade;
        }

        public Task<List<Country>> ListEnememyCountries(int id)
        {
            return _context.Countries
                .Where(c => c.Id != id)
                .ToListAsync();
        }

        public async Task CalculateBattlePointsAsync(int id)
        {
            var country = await _context.Countries.SingleAsync(c => c.Id == id);
            double attackPoint = 0;
            double defensePoint = 0;
            foreach (var countryUnit in country.CountryUnits)
            {
                if (countryUnit.GroupingType == GroupingType.Attacking)
                {
                    attackPoint += countryUnit.Count * countryUnit.Unit.AttackPoint;
                }
                else
                {
                    defensePoint += countryUnit.Count * countryUnit.Unit.DefensePoint;
                }
            }
            country.AttackPoint = attackPoint * UpgradeAttackPoint(country);
            country.DefensePoint = defensePoint * UpgradeDefensePoint(country);
        }

        public async Task AttackAsync(int id, int unitId, int enemyCountryId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new GameException("Quantity", "Quantity cannot be null or negative");
            }

            var countryUnit = await _context.CountryUnits
                .Where(c => c.CountryId == id)
                .Where(u => u.UnitId == unitId)
                .FirstOrDefaultAsync();

            if (countryUnit == null || countryUnit.Count - quantity < 0)
            {
                throw new GameException("UnitId", "There is no available unit!");
            }

            var country = await _context.Countries
                .FirstOrDefaultAsync(c => c.Id == id);

            var enemyCountry = await _context.Countries
                .FirstOrDefaultAsync(c => c.Id == enemyCountryId);

            var game = await _context.Games.FirstOrDefaultAsync();

            var battle = await _context.Battles
                .Where(c => c.AttackingCountryId == id)
                .Where(c => c.DefendingCountryId == enemyCountryId)
                .FirstOrDefaultAsync();

            if (battle != null)
            {
                var attackingCountryUnit = battle.AttackingCountryUnits
                    .Where(unit => unit.UnitId == unitId)
                    .FirstOrDefault();

                if (attackingCountryUnit != null)
                {
                    attackingCountryUnit.Count += quantity;
                    countryUnit.Count -= quantity;
                    battle.AttackPoints += attackingCountryUnit.Unit.AttackPoint * quantity * UpgradeAttackPoint(country);
                }
                else
                {
                    var newAttackingCountryUnit = new AttackingCountryUnit(countryUnit)
                    {
                        Count = quantity
                    };
                    countryUnit.Count -= quantity;
                    battle.AttackingCountryUnits.Add(newAttackingCountryUnit);
                    battle.AttackPoints += newAttackingCountryUnit.Unit.AttackPoint * quantity * UpgradeAttackPoint(country);
                    country.AttackingCountryUnits.Add(newAttackingCountryUnit);
                }
                _context.Battles.Update(battle);
            }
            else
            {
                var newAttackingCountryUnit = new AttackingCountryUnit(countryUnit)
                {
                    Count = quantity
                };
                countryUnit.Count -= quantity;
                battle = new Battle(country, enemyCountry)
                {
                    AttackPoints = newAttackingCountryUnit.Unit.AttackPoint * quantity * UpgradeAttackPoint(country)
                };
                battle.AttackingCountryUnits.Add(newAttackingCountryUnit);
                _context.Battles.Add(battle);
                country.AttackingCountryUnits.Add(newAttackingCountryUnit);
                game.Battles.Add(battle);
            }
            await CalculateBattlePointsAsync(country.Id);
            _context.CountryUnits.Update(countryUnit);
            await _context.SaveChangesAsync();
        }

        private async Task<BattleViewModel> DisplayBattleDetails(int? id)
        {
            List<Battle> battles = await _context.Battles
                .Include(x => x.AttackingCountryUnits)
                .Include(x => x.DefendingCountry)
                .Where(c => c.AttackingCountryId == id)
                .ToListAsync();

            if (battles != null)
            {
                return new BattleViewModel()
                {
                    Battles = battles
                };
            }
            return null;
        }
    }
}
