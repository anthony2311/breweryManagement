using Data.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IBreweryService
    {
        List<Brewery> Get();
    }
}