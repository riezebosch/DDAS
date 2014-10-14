using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirst;
using System.Collections.Generic;
using System.Data.Entity;

namespace CodeFirst.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SnookerContext>());

            using (var context = new SnookerContext())
            {
                context.Games.Add(new Game
                    {
                        Id = 0,
                        Location = "Veenendaal",
                        Players = new List<Player>
                        {
                            new Player
                            {
                                Id = 0,
                                Name = "Pietje Puk",
                                Games = new List<Game>()
                            }
                        }
                    });
            }
        }
    }
}
