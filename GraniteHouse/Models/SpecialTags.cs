using System;
using System.ComponentModel.DataAnnotations;

namespace GraniteHouse.Models 
{
    public class SpecialTags
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}