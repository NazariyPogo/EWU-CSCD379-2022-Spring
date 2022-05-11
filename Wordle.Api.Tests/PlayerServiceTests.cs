using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class PlayerServiceTests
    {
        private AppDbContext _context;

        public PlayerServiceTests()
        {
            var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Wordle.Api.Tests;Trusted_Connection=True;MultipleActiveResultSets=true");
            _context = new AppDbContext(contextOptions.Options);
            _context.Database.Migrate();
            PlayerService.Seed(_context);
        }

        [TestMethod]
        public void GetPlayers()
        {
            PlayerService sut = new PlayerService(_context);

            Assert.AreEqual(1, sut.GetPlayers().Count());
        }
    }
}