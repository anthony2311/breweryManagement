using Data.Models;
using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public Brewery GetById(int id)
        {
            return _dbContext.Brewery.FirstOrDefault(b => b.Id == id);
        }
    }
}
