using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CodeFirst
{
    public class SnookerContext : DbContext
    {
        public IDbSet<Game> Games { get; set; }
    }
}
