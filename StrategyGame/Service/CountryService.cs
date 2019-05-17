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

            country.CountryBuildings.Add(farm);
            country.CountryBuildings.Add(barrack);

            _context.CountryBuildings.Update(farm);
            _context.CountryBuildings.Update(barrack);

            Game game = _context.Games.FirstOrDefault();
            game.Countries.Add(country);
            _context.Games.Update(game);

            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CountryListViewModel>> ListAllCountryByPointAsync()
        {
            List<CountryListViewModel> countryListViewModels = new List<CountryListViewModel>();
            List<Country> countries = await _context.Countries.ToListAsync();
            countries.ForEach(country => countryListViewModels.Add(new CountryListViewModel(country)));
            IEnumerable<CountryListViewModel> countriesOrderByPoint = countryListViewModels.OrderByDescending(c => c.Point);

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
                .FirstOrDefaultAsync(m => m.Id == id);

            return new CountryDetailsViewModel(country);
        }

        public Task<List<Unit>> ListUnitsAsync()
        {
            return _context.Units.ToListAsync();
        }

        public async Task AddUnitAsync(int id, int quantity, int unitId)
        {
            int unitQuantity = 0;
            Country country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);
            Unit unit = await _context.Units.FirstOrDefaultAsync(u => u.Id == unitId);
            var units = await _context.CountryUnits.Where(c => c.CountryId == id)
                .Where(u => u.UnitId == unitId).FirstOrDefaultAsync();

            if (quantity >= 0)
            {
                if (IsFreeBarrackCapacity(id, quantity))
                {
                    if (units == null)
                    {
                        if (unit != null)
                        {
                            if (unit.Price * quantity < country.Gold)
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
                                throw new GameException("Quantity", "Not enough Gold!");
                            }
                        }
                        else
                        {
                            throw new GameException("UnitId", "You must choose a unit!");
                        }
                    }
                    else
                    {
                        if (unit.Price * quantity < country.Gold)
                        {
                            units.Count += quantity;
                            country.Gold -= unit.Price * quantity;
                            _context.Countries.Update(country);
                            _context.CountryUnits.Update(units);
                        }
                        else
                        {
                            throw new GameException("Quantity", "Not enough Gold!");
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new GameException("Quantity", "Not enough capacity in barracks!");
                }
            }
            else
            {
                throw new GameException("Quantity", "Quantity cannot be null or negative");
            }
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
            Country country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
        }

        public Task<List<CountryUnit>> ListCountryUnitsAsync(int id)
        {
            var countryUnits = _context.CountryUnits.Where(c => c.CountryId == id).ToListAsync();

            return countryUnits;
        }
        public int CalculateUnitPoint(int unitId)
        {
            int result;
            Unit unit = _context.Units.FirstOrDefault(u => u.Id == unitId);

            if (unit.Type == UnitType.Elit)
            {
                result = 10;
            }
            else
            {
                result = 5;
            }
            return result;
        }
        public bool IsFreeBarrackCapacity(int countryId, int quantity)
        {
            bool isFree = true;
            var barracks = _context.CountryBuildings
                                        .Where(c => c.CountryId == countryId)
                                        .Where(b => b.BuildingId == 2)
                                        .FirstOrDefault();

            int barracksCapacity = barracks.Count * 200;
            var units = _context.CountryUnits
                .Where(c => c.CountryId == countryId);
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


        public async Task AddBuildingAsync(int countryId, int buildingId)
        {
            Country country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == countryId);

            var buildingProgress = await _context.CountryBuildingProgresses
                                        .Where(c => c.CountryId == countryId)
                                        .FirstOrDefaultAsync();


            Building building = await _context.Buildings.FirstOrDefaultAsync(b => b.Id == buildingId);

            if (buildingProgress == null)
            {
                CountryBuildingProgress countryBuildingProgress = new CountryBuildingProgress
                {
                    CountryId = country.Id,
                    Country = country,
                    BuildingId = building.Id,
                    Building = building,
                    TurnsLeft = 4
                };

                country.CountryBuildingProgresses.Add(countryBuildingProgress);
                _context.CountryBuildingProgresses.Add(countryBuildingProgress);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new GameException("BuildingId", "Another construction is in progress");
            }
        }

        public Task<List<Building>> ListBuildingsAsync()
        {
            return _context.Buildings.ToListAsync();
        }

        public async Task<CountryCreateEditViewModel> GetCountryById(int id)
        {
            Country country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            CountryCreateEditViewModel countryViewModel = new CountryCreateEditViewModel(country);
            return countryViewModel;
        }

        public async Task EditAsync(int id, CountryCreateEditViewModel countryViewModel)
        {
            Country country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            country.Name = countryViewModel.Name;
            _context.Update(country);

            await _context.SaveChangesAsync();
        }

        public Task<List<Innovation>> ListInnovationssAsync()
        {
            return _context.Innovations.ToListAsync();
        }

        public async Task AddInnovationAsync(int id, int innovationId)
        {
            Country country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            Innovation innovation = await _context.Innovations.FirstOrDefaultAsync(i => i.Id == innovationId);
            var countryInnovations = await _context.CountryInnovations
                                                    .Where(c => c.CountryId == id)
                                                    .Where(i => i.InnovationId == innovationId)
                                                    .FirstOrDefaultAsync();
            var countryInnovationProgress = await _context.CountryInnovationProgresses.FirstOrDefaultAsync(c => c.CountryId == id);

            if (countryInnovations == null)
            {
                if (countryInnovationProgress == null)
                {
                    CountryInnovationProgress newCountryInnovationProgress = new CountryInnovationProgress
                    {
                        CountryId = country.Id,
                        Country = country,
                        InnovationId = innovation.Id,
                        Innovation = innovation,
                        TurnsLeft = 14
                    };
                    country.CountryInnovationProgresses.Add(newCountryInnovationProgress);
                    _context.CountryInnovationProgresses.Add(newCountryInnovationProgress);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new GameException("InnovationId", "Another innovation is under progress!");
                }
            }
            else
            {
                throw new GameException("InnovationId", "Already owned this innovation!");
            }
        }

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
            List<CountryInnovation> countryInnovations = await _context.CountryInnovations
                                                                .Include(x => x.Innovation)
                                                                .Where(c => c.CountryId == id)
                                                                .ToListAsync();

            List<Innovation> availableInnovations = await _context.Innovations.ToListAsync();
            foreach (var countryInnovation in countryInnovations)
            {
                foreach (var innovation in availableInnovations)
                {
                    if (countryInnovation.InnovationId == innovation.Id)
                    {
                        availableInnovations.Remove(innovation);
                        break;
                    }
                }
            }
            return availableInnovations;
        }

        public double UpgradeDefensePoint(Country country)
        {
            double upgrade = 1;
            foreach (var countryInnovation in country.CountryInnovations)
            {
                if (countryInnovation.Innovation.Type == InnovationType.CityWall)
                {
                    upgrade *= 1.2;

                }
                else if (countryInnovation.Innovation.Type == InnovationType.Tactic)
                {
                    upgrade *= 1.1;
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
                    upgrade *= 1.2;
                }
                else if (countryInnovation.Innovation.Type == InnovationType.Tactic)
                {
                    upgrade *= 1.1;
                }
            }

            return upgrade;
        }

        public async Task GroupingUnitsAsync(int id, int unitId, int quantity, bool isAttacking)
        {
            if (quantity > 0)
            {

                Country country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                CountryUnit countryUnit = await _context.CountryUnits.Where(c => c.CountryId == id)
                    .Where(u => u.UnitId == unitId)
                    .FirstOrDefaultAsync();
                CountryUnit findAttackingCountryUnit = await _context.CountryUnits.Where(c => c.CountryId == id)
                    .Where(u => u.UnitId == unitId)
                    .Where(type => type.GroupingType == GroupingType.Attacking)
                    .FirstOrDefaultAsync();
                AttackingCountryUnit attackingCountryUnit;

                if (countryUnit != null)
                {
                    if (isAttacking)
                    {
                        if (countryUnit.Count - quantity >= 0)
                        {
                            if (findAttackingCountryUnit == null)
                            {
                                countryUnit.Count -= quantity;
                                attackingCountryUnit = new AttackingCountryUnit(countryUnit);
                                attackingCountryUnit.Count = quantity;
                                country.AttackingCountryUnits.Add(attackingCountryUnit);
                                _context.Countries.Update(country);
                                _context.CountryUnits.Update(countryUnit);
                                _context.CountryUnits.Update(attackingCountryUnit);
                            }
                            else
                            {
                                attackingCountryUnit = (AttackingCountryUnit)findAttackingCountryUnit;
                                attackingCountryUnit.Count += quantity;
                                countryUnit.Count -= quantity;
                                _context.Countries.Update(country);
                                _context.CountryUnits.Update(countryUnit);
                                _context.CountryUnits.Update(attackingCountryUnit);
                            }
                        }
                        else
                        {
                            throw new GameException("Quantity", "Not enough unit for grouping");
                        }
                    }
                    else
                    {
                        attackingCountryUnit = (AttackingCountryUnit)findAttackingCountryUnit;
                        if (attackingCountryUnit != null && attackingCountryUnit.Count - quantity >= 0)
                        {
                            attackingCountryUnit = (AttackingCountryUnit)findAttackingCountryUnit;
                            attackingCountryUnit.Count -= quantity;
                            countryUnit.Count += quantity;
                            _context.Countries.Update(country);
                            _context.CountryUnits.Update(countryUnit);
                            _context.CountryUnits.Update(attackingCountryUnit);
                        }
                        else
                        {
                            throw new GameException("UnitId", "No attacking unit out there!");
                        }
                    }
                }
                else
                {
                    throw new GameException("UnitId", "There is no such unit!");
                }
            }
            else
            {
                throw new GameException("Quantity", "Quantity cannot be null or negative");
            }

            await _context.SaveChangesAsync();
        }

        public async Task AttackAsync(int id, int enemyCountryId)
        {
            Battle battle = await _context.Battles.FirstOrDefaultAsync(c => c.AttackingCountryId == id);

            if (battle == null)
            {
                List<CountryUnit> attackingCountryunits = await _context.CountryUnits
                    .Where(country => country.CountryId == id)
                    .Where(countryUnit => countryUnit.GroupingType == GroupingType.Attacking)
                    .ToListAsync();

                List<CountryUnit> enemyCountryUnits = await _context.CountryUnits
                    .Where(country => country.CountryId == enemyCountryId)
                    .Where(countryUnit => countryUnit.GroupingType == GroupingType.Defending)
                    .ToListAsync();

                Game game = await _context.Games.FirstOrDefaultAsync();

                if (attackingCountryunits.Count != 0)
                {
                    Battle newBattle = new Battle();
                    newBattle.AttackingCountryId = id;
                    newBattle.DefendingCountryId = enemyCountryId;
                    newBattle.AttackingCountryUnits = attackingCountryunits.Cast<AttackingCountryUnit>().ToList();
                    newBattle.DefendingCountryUnits = enemyCountryUnits;
                    _context.Battles.Add(newBattle);
                    game.Battles.Add(newBattle);
                    _context.Games.Update(game);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new GameException("EnemyCountryId", "You don't have available attacking units!");
                }
            }
            else
            {
                throw new GameException("EnemyCountryId", "You've already started an attack!");
            }
        }

        public async Task<List<Country>> ListEnememyCountries(int id)
        {
            List<Country> countries = await _context.Countries.ToListAsync();
            foreach (var country in countries)
            {
                if (country.Id == id)
                {
                    countries.Remove(country);
                    break;
                }
            }
            return countries;
        }

        public async Task CalculateBattlePointsAsync(int id)
        {
            Country country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
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
    }
}
