using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class CountryInnovation
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int InnovationId { get; set; }
        public Innovation Innovation { get; set; }

    }
}
