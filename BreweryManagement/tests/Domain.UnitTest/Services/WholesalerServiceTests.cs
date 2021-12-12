using Data.Models;
using Data.Repositories;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Data;
using System.Linq;
using System.Collections.Generic;
using System;
using Domain.Exceptions;

namespace Domain.UnitTest
{
    public class WholesalerServiceTests
    {
        private WholesalerService _service;
        private BreweryManagementContext _dbContext;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BreweryManagementContext>()
                .UseInMemoryDatabase(databaseName: "WholesalerServiceTests")
                .Options;
            _dbContext = new BreweryManagementContext(options);
            _service = new WholesalerService(new WholesalerRepository(_dbContext), new BeerRepository(_dbContext), new WholesalerStockRepository(_dbContext));
        }

        [Test]
        public void Get_shouldReturnAllWholesaler()
        {
            var wholesalers = _service.Get();
            Assert.AreEqual(_dbContext.Wholesaler.Count(), wholesalers.Count);
        }
        [Test]
        public void GetWholesalerBeers_WithInvalidId_ShouldThrownException()
        {
            Assert.Throws<HttpResponseException>(() => _service.GetWholesalerBeers(int.MaxValue));
        }
        [Test]
        public void GetWholesalerBeers_WithvalidId_ShouldReturnAListOfBeer()
        {
            var beers = _service.GetWholesalerBeers(_dbContext.Wholesaler.First().Id);
            Assert.IsNotNull(beers);
        }
        [Test]
        public void CreateWholesalerStock_shouldAddANewLine()
        {
            int numberWholeSalerStock = _dbContext.WholesalerStock.Count();
            _service.CreateWholesalerStock(3, 1, 10);
            Assert.AreEqual(numberWholeSalerStock+1, _dbContext.WholesalerStock.Count());
        }
        [Test]
        public void CreateWholesalerStock_OnExistingWholesalerStock_ShouldThrowAnException()
        {
            Assert.Throws<ArgumentException>(() => _service.CreateWholesalerStock(1, 1, 10));
        }
        [Test]
        public void CreateWholesalerStock_WithInvalidId_ShouldThrowAnException()
        {
            Assert.Throws<HttpResponseException>(() => _service.CreateWholesalerStock(1, int.MaxValue, 10));
            Assert.Throws<HttpResponseException>(() => _service.CreateWholesalerStock(int.MaxValue, 1, 10));
        }
        [Test]
        public void UpdateWholesalerStock_ShouldChangeTheQuantity()
        {
            _service.UpdateWholesalerStock(1, 1, 200);
            int? dbContextQuantity = _dbContext.WholesalerStock.FirstOrDefault(ws => ws.BeerId == 1 && ws.WholesalerId == 1)?.quantity;
            Assert.AreEqual(200, dbContextQuantity);
        }
        [Test]
        public void UpdateWholesalerStock_WithInvalidId_ShouldThrowAnException()
        {
            Assert.Throws<HttpResponseException>(() => _service.UpdateWholesalerStock(1, int.MaxValue, 10));
            Assert.Throws<HttpResponseException>(() => _service.UpdateWholesalerStock(int.MaxValue, 1, 10));
        }
    }
}