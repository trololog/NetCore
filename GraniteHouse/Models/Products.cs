using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraniteHouse.Models 
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Price {get;set;}
        public bool Available {get;set;}

        public string Image {get;set;}

        public string ShadeColor {get;set;}

        [Display(Name="Product Type")]
        public int ProductTypeId {get;set;}

        [ForeignKey("ProductTypeId")]
        public virtual ProductTypes ProductTypes {get;set;}

        [Display(Name="Special Tags")]
        public int SpecialTagId {get;set;}

        [ForeignKey("SpecialTagId")]
        public virtual SpecialTags SpecialTags {get;set;}
    }
}