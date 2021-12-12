using System.Collections.Generic;

namespace Domain.Models
{
    public class OrderDto
    {
        public List<OrderQuotationBeer> Beers { get; set; }
    }    
    public class OrderQuotationDto : OrderDto
    {
        public double Price { get; set; }
    }
    public class OrderQuotationBeer
    {
        public int BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
