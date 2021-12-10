using Api.Models;
using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
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
    }
}
