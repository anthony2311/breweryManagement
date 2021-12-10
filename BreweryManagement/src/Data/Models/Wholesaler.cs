using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Wholesaler
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
