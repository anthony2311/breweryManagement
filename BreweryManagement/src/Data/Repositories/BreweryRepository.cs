using Data.Models;
using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public void Delete(int id)
        {
            // Delete cascade is not manage on entityFramework inMemory
            // need to include Beers and WholesalerStocks on the entity to ensure delete cascade
            // issue know here https://github.com/dotnet/efcore/issues/3924
            var entity = _dbContext.Brewery.Include(b=>b.Beers).ThenInclude(b=>b.WholesalerStocks).FirstOrDefault(b => b.Id == id);
            if(entity != null)
            {
                _dbContext.Remove(entity);
                _dbContext.SaveChanges();
            }
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
