using Data.Models;
using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{ 
    public interface IWholesalerOrderService
    {
        OrderQuotationDto OrderQuotation(int id, OrderDto orderQuotation);
    }
}