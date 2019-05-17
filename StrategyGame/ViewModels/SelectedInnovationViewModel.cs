using StrategyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.ViewModels
{
    public class SelectedInnovationViewModel
    {
        public int Id { get; set; }
        public int InnovationId { get; set; }
        public List<Innovation> Innovations { get; set; }
    }
}
