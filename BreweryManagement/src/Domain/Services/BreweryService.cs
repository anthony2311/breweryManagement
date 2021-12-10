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

        public BreweryService(IBreweryRepository breweryRepository)
        {
            _breweryRepository = breweryRepository;
        }

        public List<Brewery> Get()
        {
            return _breweryRepository.GetAll().ToList();
        }
    }
}
