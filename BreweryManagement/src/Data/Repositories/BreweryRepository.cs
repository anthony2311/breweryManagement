using Data.Models;
using Data.Interfaces;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class BreweryRepository : IBreweryRepository
    {
        private BreweryManagementContext _dbContext;

        public BreweryRepository(BreweryManagementContext dbContext)
        {
            _dbContext = dbContext;
            // need to trigger this method to ensure seeding is called 
            _dbContext.Database.EnsureCreated();
        }
        public IEnumerable<Brewery> GetAll()
        {
            return _dbContext.Brewery;
        }
    }
}
