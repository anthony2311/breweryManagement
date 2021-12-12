using Data.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IBeerService
    {
        List<Beer> Get();
        void Create(Beer beer);
    }
}