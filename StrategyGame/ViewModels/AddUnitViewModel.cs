using Microsoft.AspNetCore.Mvc.Rendering;
using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class AddUnitViewModel
    {
        public int Id { get; set; }

        [Required]
        public int UnitId { get; set; }
        public List<Unit> Units { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
