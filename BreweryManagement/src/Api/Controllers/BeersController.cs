using Api.Models;
using AutoMapper;
using Data.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/beers")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IBeerService _beerService;
        private readonly IMapper _mapper;
        public BeersController(IBeerService beerService, IMapper mapper)
        {
            _beerService = beerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<BeerDto> Get()
        {
            List<Beer> beers = _beerService.Get();
            return _mapper.Map<IEnumerable<BeerDto>>(beers);
        }

        [HttpPost]
        public void Create([FromBody] BeerDto beerDto)
        {
            // TODO : add attribute validation on dto + add check here
            var beer = _mapper.Map<Beer>(beerDto);
            _beerService.Create(beer);
        }
    }
}
