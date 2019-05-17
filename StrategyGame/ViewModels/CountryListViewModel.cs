using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class CountryListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Point { get; set; }

        public CountryListViewModel(Country country)
        {
            Id = country.Id;
            Name = country.Name;
            Point = country.Point;
        }
    }
}
