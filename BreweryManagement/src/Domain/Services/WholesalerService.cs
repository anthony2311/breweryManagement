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

        public WholesalerService(IWholesalerRepository wholesalerRepository)
        {
            _wholesalerRepository = wholesalerRepository;
        }

        public List<Wholesaler> Get()
        {
            return _wholesalerRepository.GetAll().ToList();
        }
    }
}
