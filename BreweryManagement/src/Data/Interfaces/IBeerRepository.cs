using Data.Models;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> GetAll();
        IEnumerable<Beer> GetByBreweryId(int id);
        void Create(Beer beer);
        Beer getById(int id);
        double GetBeerPrice(int beerId);
    }
}
