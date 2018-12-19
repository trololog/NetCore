using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace GraniteHouse.Models 
{
    public class ProductsViewModel
    {
        public Products Products { get; set; }
        public IEnumerable<ProductTypes> ProductTypes { get; set; }
        public IEnumerable<SpecialTags> SpecialTags { get; set; }
    }
}