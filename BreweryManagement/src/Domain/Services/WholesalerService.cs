using Data.Interfaces;
using Data.Models;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
            if (!_wholesalerRepository.Exist(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, $"Wholesaler with id {id} does not exist");

            }
            return _wholesalerRepository.GetWholesalerBeers(id).ToList();

        }

        public void CreateWholesalerStock(int wholesalerId, int beerId, int quantity)
        {
            if (!_wholesalerRepository.Exist(wholesalerId))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, $"Wholesaler with id {wholesalerId} does not exist");
            }
            if (!_beerRepository.Exist(beerId))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, $"Beer with id {beerId} does not exist");
            }
            // TODO : add check on primary key before save
            _wholesalerStockRepository.CreateWholesalerStock(new WholesalerStock() { WholesalerId = wholesalerId, BeerId = beerId, quantity = quantity });
        }

        public void UpdateWholesalerStock(int wholesalerId, int beerId, int quantity)
        {
            if (!_wholesalerRepository.Exist(wholesalerId))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, $"Wholesaler with id {wholesalerId} does not exist");
            }
            if (!_beerRepository.Exist(beerId))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, $"Beer with id {beerId} does not exist");
            }
            // TODO : add check on primary key before save
            _wholesalerStockRepository.UpdateWholesalerStock(new WholesalerStock() { WholesalerId = wholesalerId, BeerId = beerId, quantity = quantity });
        }

    }
}
