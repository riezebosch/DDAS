﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirst
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Game> Games { get; set; }
    }
}
