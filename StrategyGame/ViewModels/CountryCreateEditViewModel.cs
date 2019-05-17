using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class CountryCreateEditViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        public CountryCreateEditViewModel()
        {

        }
        public CountryCreateEditViewModel(Country country)
        {
            Name = country.Name;
        }
    }
}
