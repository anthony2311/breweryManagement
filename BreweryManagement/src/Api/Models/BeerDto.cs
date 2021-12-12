using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class BeerDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double AlcoholDegree { get; set; }
        public double Price { get; set; }
        public int BreweryId { get; set; }
    }
}
