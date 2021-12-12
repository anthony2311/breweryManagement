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

        public bool Exist(int beerId)
        {
            return _dbContext.Beers.Any(b => b.Id == beerId);
        }

        public IEnumerable<Beer> GetAll()
        {
            return _dbContext.Beers;
        }

        public double GetBeerPrice(int beerId)
        {
            return _dbContext.Beers.First(b => b.Id == beerId).Price;
        }

        public IEnumerable<Beer> GetByBreweryId(int id)
        {
            return _dbContext.Beers.Where(b=>b.BreweryId == id);
        }

        public Beer getById(int id)
        {
            return _dbContext.Beers.FirstOrDefault(b => b.Id == id);
        }
    }
}
