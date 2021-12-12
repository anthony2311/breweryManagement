using Data.Models;
using Data.Repositories;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Data;
using System.Linq;

namespace Domain.UnitTest
{
    public class BeerServiceTests
    {
        private BeerService _service;
        private BreweryManagementContext _dbContext;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BreweryManagementContext>()
                .UseInMemoryDatabase(databaseName: "BeerServiceTests")
                .Options;
            _dbContext = new BreweryManagementContext(options);
            _service = new BeerService(new BeerRepository(_dbContext));
        }
        [Test]
        public void Get_shouldReturnAllBeers()
        {
            var beers = _service.Get();
            Assert.AreEqual(_dbContext.Beers.Count(), beers.Count);
        }
        [Test]
        public void Create_shouldAddANewBeer()
        {
            var numberBeerBeforeCreate = _dbContext.Beers.Count();
            _service.Create(new Beer()
            {
                AlcoholDegree = 3.0,
                BreweryId = 1,
                Name = "testBeer",
                Price = 2.10,
            });
            Assert.AreEqual(_dbContext.Beers.Count(), numberBeerBeforeCreate + 1);
        }
    }
}