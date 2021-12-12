using Data.Models;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IBreweryRepository
    {
        IEnumerable<Brewery> GetAll();
        Brewery GetById(int id);
        void Delete(int id);
        bool Exist(int breweryId);
    }
}
