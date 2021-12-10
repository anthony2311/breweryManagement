using Data.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IWholesalerService
    {
        List<Wholesaler> Get();
    }
}