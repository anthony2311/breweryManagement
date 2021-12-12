using Api.Models;
using AutoMapper;
using Data.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/whosalers")]
    [ApiController]
    public class WholesalersController : ControllerBase
    {
        private readonly IWholesalerService _wholesalerService;
        private readonly IMapper _mapper;
        public WholesalersController(IWholesalerService wholesalerService, IMapper mapper)
        {
            _wholesalerService = wholesalerService;
            _mapper = mapper;
        }

        /// <summary>
        /// List all wholesalers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WholesalerDto> Get()
        {
            List<Wholesaler> wholesalers = _wholesalerService.Get();
            return _mapper.Map<IEnumerable<WholesalerDto>>(wholesalers);
        }

        /// <summary>
        /// List the beers that the wholesaler sells
        /// </summary>
        /// <param name="id">Wholesaler id</param>
        /// <returns></returns>
        [HttpGet("{id}/beers")]
        public IEnumerable<BeerDto> GetWholesalerBeers(int id)
        {
            List<Beer> beers = _wholesalerService.GetWholesalerBeers(id);
            return _mapper.Map<IEnumerable<BeerDto>>(beers);
        }

        /// <summary>
        /// Add a beer in the wholesaler stock
        /// </summary>
        /// <param name="id">Wholesaler id</param>
        /// <returns></returns>
        [HttpPost("{id}/stock/{beerId}")]
        public void CreateWholesalerStock(int id, int beerId, [FromBody] int quantity)
        {
            _wholesalerService.CreateWholesalerStock(id, beerId, quantity);
        }

        /// <summary>
        /// Update the wholesaler stock
        /// </summary>
        /// <param name="id">Wholesaler id</param>
        /// <returns></returns>
        [HttpPut("{id}/stock/{beerId}")]
        public void UpdateWholesalerStock(int id, int beerId, [FromBody] int quantity)
        {
            _wholesalerService.UpdateWholesalerStock(id, beerId, quantity);
        }

    }
}
