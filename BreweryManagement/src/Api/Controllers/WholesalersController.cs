using Api.Models;
using AutoMapper;
using Data.Models;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/whosalers")]
    [ApiController]
    public class WholesalersController : ControllerBase
    {
        private readonly IWholesalerService _wholesalerService;
        private readonly IWholesalerOrderService _wholesalerOrderService;
        private readonly IMapper _mapper;
        public WholesalersController(IWholesalerService wholesalerService, IWholesalerOrderService wholesalerOrderService, IMapper mapper)
        {
            _wholesalerService = wholesalerService;
            _wholesalerOrderService = wholesalerOrderService;
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


        [HttpPost("{id}/orderQuotation")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderQuotationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetWholesalerOrderQuotation(int id, [FromBody] OrderDto order)
        {
            if (order == null || order.Beers?.Count == 0)
            {
                return BadRequest("Your order is empty");
            }
            if (order.Beers.GroupBy(x => x.BeerId).Any(g => g.Count() > 1))
            {
                return BadRequest("You have duplicate beer in your order");
            }
            return Ok(_wholesalerOrderService.OrderQuotation(id, order));
        }

    }
}
