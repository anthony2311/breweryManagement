using Data.Models;
using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IWholesalerService
    {
        List<Wholesaler> Get();
        List<Beer> GetWholesalerBeers(int id);
        void CreateWholesalerStock(int wholesalerId, int beerId, int quantity);
        void UpdateWholesalerStock(int id, int beerId, int quantity);
    }
}