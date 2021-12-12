using Data.Models;
using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public void Create(Beer beer)
        {
            _dbContext.Beers.Add(beer);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Beer> GetAll()
        {
            return _dbContext.Beers;
        }

        public IEnumerable<Beer> GetByBreweryId(int id)
        {
            return _dbContext.Beers.Where(b=>b.BreweryId == id);
        }
    }
}
