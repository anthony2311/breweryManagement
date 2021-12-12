using Data.Models;
using Data.Repositories;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Domain.Models;
using System.Collections.Generic;
using System;
using Domain.Exceptions;

namespace Domain.UnitTest
{
    public class WholesalerOrderServiceTests
    {
        private WholesalerOrderService _service;
        private BreweryManagementContext _dbContext;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BreweryManagementContext>()
                .UseInMemoryDatabase(databaseName: "WholesalerOrderServiceTests")
                .Options;
            _dbContext = new BreweryManagementContext(options);
            _service = new WholesalerOrderService(new WholesalerRepository(_dbContext), new WholesalerStockRepository(_dbContext), new BeerRepository(_dbContext));
        }
        [Test]
        public void OrderQuotation_withInvalidWholesalerId_ShouldThrowAnException()
        {
            Assert.Throws<HttpResponseException>(() => _service.OrderQuotation(int.MaxValue, new OrderDto()));
        }
        [Test]
        public void OrderQuotation_withInvalidBeerId_ShouldThrowAnException()
        {
            var orderDto = new OrderDto()
            {
                Beers = new List<OrderQuotationBeer>()
                {
                    new OrderQuotationBeer()
                    {
                        BeerId = 200
                    }
                }
            };
            Assert.Throws<HttpResponseException>(()=>_service.OrderQuotation(1, orderDto));
        }
        [Test]
        public void OrderQuotation_withoutSellingTheBeer_ShouldThrowAnException()
        {
            var orderDto = new OrderDto()
            {
                Beers = new List<OrderQuotationBeer>()
                {
                    new OrderQuotationBeer()
                    {
                        BeerId = 5
                    }
                }
            };
            Assert.Throws<HttpResponseException>(()=>_service.OrderQuotation(1, orderDto));
        }
        [Test]
        public void OrderQuotation_withoutStock_ShouldThrowAnException()
        {
            var orderDto = new OrderDto()
            {
                Beers = new List<OrderQuotationBeer>()
                {
                    new OrderQuotationBeer()
                    {
                        BeerId = 1,
                        Quantity = int.MaxValue
                    }
                }
            };
            Assert.Throws<HttpResponseException>(()=>_service.OrderQuotation(1, orderDto));
        }
        [Test]
        public void OrderQuotation_withLessThan10Beers_HaveNoDiscount()
        {
            var orderDto = new OrderDto()
            {
                Beers = new List<OrderQuotationBeer>()
                {
                    new OrderQuotationBeer()
                    {
                        BeerId = 1,
                        Quantity = 9
                    }
                }
            };
            var result = _service.OrderQuotation(1, orderDto);
            var normalPrice = _dbContext.Beers.Find(orderDto.Beers[0].BeerId).Price * orderDto.Beers[0].Quantity;
            Assert.AreEqual(normalPrice, result.Price, 0.2);
        }

        [Test]
        public void OrderQuotation_withLessThan20Beers_Have10PurcentDiscount()
        {
            var orderDto = new OrderDto()
            {
                Beers = new List<OrderQuotationBeer>()
                {
                    new OrderQuotationBeer()
                    {
                        BeerId = 1,
                        Quantity = 19
                    }
                }
            };
            var result = _service.OrderQuotation(1, orderDto);
            var normalPrice = _dbContext.Beers.Find(orderDto.Beers[0].BeerId).Price * orderDto.Beers[0].Quantity;
            normalPrice -= normalPrice * 0.1;
            Assert.AreEqual(normalPrice, result.Price, 0.2);
        }
        [Test]
        public void OrderQuotation_withLessMore20Beers_Have20PurcentDiscount()
        {
            var orderDto = new OrderDto()
            {
                Beers = new List<OrderQuotationBeer>()
                {
                    new OrderQuotationBeer()
                    {
                        BeerId = 1,
                        Quantity = 22
                    }
                }
            };
            var result = _service.OrderQuotation(1, orderDto);
            var normalPrice = _dbContext.Beers.Find(orderDto.Beers[0].BeerId).Price * orderDto.Beers[0].Quantity;
            normalPrice -= normalPrice * 0.2;
            Assert.AreEqual(normalPrice, result.Price, 0.2);
        }

    }
}