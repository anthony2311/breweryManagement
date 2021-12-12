using Data.Models;
using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public Wholesaler GetById(int id)
        {
            return _dbContext.Wholesaler.FirstOrDefault(w => w.Id == id);
        }

        public IEnumerable<Beer> GetWholesalerBeers(int id)
        {
            return _dbContext.WholesalerStock.Where(ws => ws.WholesalerId == id).Select(b => b.Beer);
        }
        public void CreateWholesalerStock(WholesalerStock wholesalerStock)
        {
            _dbContext.WholesalerStock.Add(wholesalerStock);
            _dbContext.SaveChanges();
        }

        public void UpdateWholesalerStock(WholesalerStock wholesalerStock)
        {
            var entity = _dbContext.WholesalerStock.FirstOrDefault(ws => ws.BeerId == wholesalerStock.BeerId && ws.WholesalerId == wholesalerStock.WholesalerId);
            entity.quantity = wholesalerStock.quantity;
            _dbContext.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _dbContext.Wholesaler.Any(ws => ws.Id == id);
        }
    }
}
