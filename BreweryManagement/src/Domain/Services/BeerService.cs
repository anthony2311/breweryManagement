using Api.Controllers;
using Data.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
