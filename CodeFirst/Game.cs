using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirst
{
    public class Game
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public List<Player> Players { get; set; }
    }
}
