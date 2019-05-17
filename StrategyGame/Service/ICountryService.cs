using StrategyGame.Models;
using StrategyGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Service
{
    public interface ICountryService
    {
        Task CreateAsync(CountryCreateEditViewModel countryView);
        Task DeleteAsync(int id);
        Task<IEnumerable<CountryListViewModel>> ListAllCountryByPointAsync();
        Task<CountryDetailsViewModel> FindCountryByIdAsync(int? Id);
        Task<List<Unit>> ListUnitsAsync();
        Task AddUnitAsync(int id, int quantity, int unitId);
        Task<List<CountryBuilding>> ListBuildingsAsync(int id);
        Task<List<CountryUnit>> ListCountryUnitsAsync(int id);
        Task<List<CountryInnovation>> ListCountryInnovationsAsync(int id);
        Task<List<Innovation>> ListCountryAvailableInnovationsAsync(int id);
        Task AddBuildingAsync(int countryId, int buildingId);
        Task<List<Building>> ListBuildingsAsync();
        Task <CountryCreateEditViewModel> GetCountryById(int id);
        Task EditAsync(int id, CountryCreateEditViewModel countryViewModel);
        Task<List<Innovation>> ListInnovationssAsync();
        Task AddInnovationAsync(int id, int innovationId);
        Task GroupingUnitsAsync(int id, int unitId, int quantity, bool isAttacking);
        Task AttackAsync(int id, int enemyCountryId);
        Task<List<Country>> ListEnememyCountries(int id);
        Task CalculateBattlePointsAsync(int id);
    }
}
