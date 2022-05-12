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
        private readonly AppDbContext _context;

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
            PlayerService sut = new(_context);

            Assert.AreEqual(1, sut.GetTenPlayers().Count());
        }

        [TestMethod]
        public void UpdateAddGame()
        {
            PlayerService sut = new(_context);

            sut.Update("First", 5);

            Assert.AreEqual(115.0/101.0, sut.GetTenPlayers().First(x => x.Name == "First").AverageAttempts);
        }
    }
}