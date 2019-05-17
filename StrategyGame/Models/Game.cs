using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Models
{
    public class Game
    {
        public int Id { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Battle> Battles { get; set; }
        public int Turn { get; set; }

        public Game()
        {
            Countries = new List<Country>();
            Battles = new List<Battle>();
        }
    }
}
