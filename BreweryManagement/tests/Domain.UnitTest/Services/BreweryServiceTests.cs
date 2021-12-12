using Data.Models;
using Data.Repositories;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Data;
using System.Linq;
using System.Collections.Generic;

namespace Domain.UnitTest
{
    public class BreweryServiceTests
    {
        private BreweryService _service;
        private BreweryManagementContext _dbContext;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BreweryManagementContext>()
                .UseInMemoryDatabase(databaseName: "BreweryServiceTests")
                .Options;
            _dbContext = new BreweryManagementContext(options);
            _service = new BreweryService(new BreweryRepository(_dbContext), new BeerRepository(_dbContext));
        }
        [Test]
        public void Get_shouldReturnAllBreweries()
        {
            var breweries = _service.Get();
            Assert.AreEqual(_dbContext.Brewery.Count(), breweries.Count);
        }

        [Test]
        public void GetBreweryBeers_WithInvalidId_ShouldThrownException()
        {
            Assert.Throws<KeyNotFoundException>(()=>_service.GetBreweryBeers(int.MaxValue));
        }
        [Test]
        public void GetBreweryBeers_WithvalidId_ShouldReturnAListOfBeer()
        {
            var beers = _service.GetBreweryBeers(_dbContext.Brewery.First().Id);
            Assert.IsNotNull(beers);
        }
        [Test]
        public void Delete_ShouldDeleteBreweryInCascade()
        {
            int breweryIdToDelete = _dbContext.Brewery.First().Id;
            _service.Delete(breweryIdToDelete);
            Assert.IsFalse(_dbContext.Brewery.Any(b=>b.Id == breweryIdToDelete));
            Assert.IsFalse(_dbContext.Beers.Any(b => b.BreweryId == breweryIdToDelete));
        }
    }
}