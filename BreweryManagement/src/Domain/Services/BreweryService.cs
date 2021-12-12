using Data.Interfaces;
using Data.Models;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class BreweryService : IBreweryService
    {
        private IBreweryRepository _breweryRepository;
        private IBeerRepository _beerRepository;

        public BreweryService(IBreweryRepository breweryRepository, IBeerRepository beerRepository)
        {
            _breweryRepository = breweryRepository;
            _beerRepository = beerRepository;
        }

        public List<Brewery> Get()
        {
            return _breweryRepository.GetAll().ToList();
        }

        public List<Beer> GetBreweryBeers(int id)
        {
            var brewery =  _breweryRepository.GetById(id);
            if(brewery == null)
            {
                throw new KeyNotFoundException($"Brewery with id {id} does not exist");
            }
            return _beerRepository.GetByBreweryId(id).ToList();
        }
        public void Delete(int id)
        {
            _breweryRepository.Delete(id);
        }
    }
}
