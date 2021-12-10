using Data.Models;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IWholesalerRepository
    {
        IEnumerable<Wholesaler> GetAll();
        Wholesaler GetById(int id);
        IEnumerable<Beer> GetWholesalerBeers(int id);
    }
}
