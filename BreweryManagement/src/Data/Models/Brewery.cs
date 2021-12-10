using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Brewery
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
