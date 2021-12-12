﻿using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class BreweryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
