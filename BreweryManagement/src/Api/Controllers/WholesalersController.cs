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

        [HttpGet]
        public IEnumerable<WholesalerDto> Get()
        {
            List<Wholesaler> wholesalers = _wholesalerService.Get();
            return _mapper.Map<IEnumerable<WholesalerDto>>(wholesalers);
        }
    }
}
