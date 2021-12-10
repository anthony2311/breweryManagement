using Data.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private BreweryManagementContext _dbContext;

        public BeerRepository(BreweryManagementContext dbContext)
        {
            _dbContext = dbContext;
            // need to trigger this method to ensure seeding is called 
            _dbContext.Database.EnsureCreated();
        }
        public IEnumerable<Beer> GetAll()
        {
            return _dbContext.Beers;
        }
    }
}
