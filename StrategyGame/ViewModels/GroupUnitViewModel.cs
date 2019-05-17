using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class GroupUnitViewModel
    {
        public int Id { get; set; }

        [Required]
        public int UnitId { get; set; }
        public List<Unit> Units { get; set; }
        public List<CountryUnit> CountryUnits{ get; set; }

        [Required]
        public int Quantity { get; set; }
        public bool IsAttacking { get; set; }
    }
}
