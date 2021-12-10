using Data.Interfaces;
using Data.Models;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class WholesalerService : IWholesalerService
    {
        private IWholesalerRepository _wholesalerRepository;
        private IBeerRepository _beerRepository;

        public WholesalerService(IWholesalerRepository wholesalerRepository, IBeerRepository beerRepository)
        {
            _wholesalerRepository = wholesalerRepository;
            _beerRepository = beerRepository;
        }

        public List<Wholesaler> Get()
        {
            return _wholesalerRepository.GetAll().ToList();
        }

        public List<Beer> GetWholesalerBeers(int id)
        {
            var wholesaler = _wholesalerRepository.GetById(id);
            if (wholesaler == null)
            {
                throw new KeyNotFoundException($"Wholesaler with id {id} does not exist");
            }
            return _wholesalerRepository.GetWholesalerBeers(id).ToList();

        }
    }
}
