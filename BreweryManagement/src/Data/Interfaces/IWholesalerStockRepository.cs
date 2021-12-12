using Data.Models;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IWholesalerStockRepository
    {
        void CreateWholesalerStock(WholesalerStock wholesaler);
        void UpdateWholesalerStock(WholesalerStock wholesalerStock);
        bool Exist(int wholesalerStockId, int beerId);
        int GetStock(int id, int beerId);
    }
}
