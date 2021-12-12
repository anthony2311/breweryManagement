using Data.Models;
using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class WholesalerStockRepository : IWholesalerStockRepository
    {
        private BreweryManagementContext _dbContext;

        public WholesalerStockRepository(BreweryManagementContext dbContext)
        {
            _dbContext = dbContext;
            // need to trigger this method to ensure seeding is called 
            _dbContext.Database.EnsureCreated();
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

        public bool Exist(int wholesalerStockId, int beerId)
        {
            return _dbContext.WholesalerStock.Any(ws => ws.BeerId == beerId && ws.WholesalerId == wholesalerStockId);
        }

        public int GetStock(int id, int beerId)
        {
            return _dbContext.WholesalerStock.First(ws => ws.BeerId == beerId && ws.WholesalerId == id).quantity;
        }
    }
}
