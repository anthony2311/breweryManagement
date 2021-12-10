using Api.Models;
using AutoMapper;
using Data.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweriesController : ControllerBase
    {
        private readonly IBreweryService _breweryService;
        private readonly IMapper _mapper;
        public BreweriesController(IBreweryService breweryService, IMapper mapper)
        {
            _breweryService = breweryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<BreweryDto> Get()
        {
            List<Brewery> breweries = _breweryService.Get();
            return _mapper.Map<IEnumerable<BreweryDto>>(breweries);
        }
    }
}
