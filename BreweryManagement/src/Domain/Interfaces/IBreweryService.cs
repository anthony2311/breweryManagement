using Data.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IBreweryService
    {
        List<Brewery> Get();
        List<Beer> GetBreweryBeers(int id);
        void Delete(int id);
    }
}