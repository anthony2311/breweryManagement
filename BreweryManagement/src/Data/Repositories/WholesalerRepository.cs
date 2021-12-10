using Data.Models;
using Data.Interfaces;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class WholesalerRepository : IWholesalerRepository
    {
        private BreweryManagementContext _dbContext;

        public WholesalerRepository(BreweryManagementContext dbContext)
        {
            _dbContext = dbContext;
            // need to trigger this method to ensure seeding is called 
            _dbContext.Database.EnsureCreated();
        }
        public IEnumerable<Wholesaler> GetAll()
        {
            return _dbContext.Wholesaler;
        }
    }
}
