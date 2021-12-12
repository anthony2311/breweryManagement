using Data.Interfaces;
using Data.Models;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class WholesalerService : IWholesalerService
    {
        private IWholesalerRepository _wholesalerRepository;
        private IWholesalerStockRepository _wholesalerStockRepository;
        private IBeerRepository _beerRepository;

        public WholesalerService(IWholesalerRepository wholesalerRepository, IBeerRepository beerRepository, IWholesalerStockRepository wholesalerStockRepository)
        {
            _wholesalerRepository = wholesalerRepository;
            _wholesalerStockRepository = wholesalerStockRepository;
            _beerRepository = beerRepository;
        }

        public List<Wholesaler> Get()
        {
            return _wholesalerRepository.GetAll().ToList();
        }

        public List<Beer> GetWholesalerBeers(int id)
        {
            if (!DoesWholesalerExist(id))
            {
                throw new KeyNotFoundException($"Wholesaler with id {id} does not exist");

            }
            return _wholesalerRepository.GetWholesalerBeers(id).ToList();

        }

        public void CreateWholesalerStock(int wholesalerId, int beerId, int quantity)
        {
            if (!DoesWholesalerExist(wholesalerId))
            {
                throw new KeyNotFoundException($"Wholesaler with id {wholesalerId} does not exist");
            }
            if (!DoesBeerExist(beerId))
            {
                throw new KeyNotFoundException($"Beer with id {beerId} does not exist");
            }
            // TODO : add check on primary key before save
            _wholesalerStockRepository.CreateWholesalerStock(new WholesalerStock() { WholesalerId = wholesalerId, BeerId = beerId, quantity = quantity });
        }

        public void UpdateWholesalerStock(int wholesalerId, int beerId, int quantity)
        {
            if (!DoesWholesalerExist(wholesalerId))
            {
                throw new KeyNotFoundException($"Wholesaler with id {wholesalerId} does not exist");
            }
            if (!DoesBeerExist(beerId))
            {
                throw new KeyNotFoundException($"Beer with id {beerId} does not exist");
            }
            // TODO : add check on primary key before save
            _wholesalerStockRepository.UpdateWholesalerStock(new WholesalerStock() { WholesalerId = wholesalerId, BeerId = beerId, quantity = quantity });
        }

        private bool DoesWholesalerExist(int wholesalerId)
        {
            var wholesaler = _wholesalerRepository.GetById(wholesalerId);
            return wholesaler != null;
        }
        private bool DoesBeerExist(int beerId)
        {
            var beer = _beerRepository.getById(beerId);
            return beer != null;
        }
    }
}
