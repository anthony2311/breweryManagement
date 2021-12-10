using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Brewery
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
