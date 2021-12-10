using Data.Interfaces;
using Data.Models;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class BeerService : IBeerService
    {
        private IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public List<Beer> Get()
        {
            return _beerRepository.GetAll().ToList();
        }
    }
}
