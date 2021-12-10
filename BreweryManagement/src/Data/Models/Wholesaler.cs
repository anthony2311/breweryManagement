using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Wholesaler
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WholesalerStock> WholesalerStocks { get; set; }
    }
}
