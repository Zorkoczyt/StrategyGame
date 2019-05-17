using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Exceptions
{
    public class GameException : Exception
    {
        public string Key { get; set; }
        public string Description { get; set; }

        public GameException(string key, string description)
        {
            Key = key;
            Description = description;
        }
    }
}
