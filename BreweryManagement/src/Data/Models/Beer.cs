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
    }
}
