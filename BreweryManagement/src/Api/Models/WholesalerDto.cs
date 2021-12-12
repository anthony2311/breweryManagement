using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class WholesalerDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
