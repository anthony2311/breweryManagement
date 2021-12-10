using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Beer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double AlcoholDegree { get; set; }
        public double Price { get; set; }
        public int BreweryId { get; set; }
        public Brewery Brewery { get; set; }
        public ICollection<WholesalerStock> WholesalerStocks { get; set; }
    }
}
