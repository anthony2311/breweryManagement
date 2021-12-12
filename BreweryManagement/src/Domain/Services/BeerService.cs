using Data.Interfaces;
using Data.Models;
using Domain.Exceptions;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Domain.Services
{
    public class BeerService : IBeerService
    {
        private IBeerRepository _beerRepository;
        private IBreweryRepository _breweryRepository;

        public BeerService(IBeerRepository beerRepository, IBreweryRepository breweryRepository)
        {
            _beerRepository = beerRepository;
            _breweryRepository = breweryRepository;
        }

        public void Create(Beer beer)
        {
            if (!_breweryRepository.Exist(beer.BreweryId))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, $"Brewery with id {beer.BreweryId} does not exist");
            }
            _beerRepository.Create(beer);
        }

        public List<Beer> Get()
        {
            return _beerRepository.GetAll().ToList();
        }
    }
}
