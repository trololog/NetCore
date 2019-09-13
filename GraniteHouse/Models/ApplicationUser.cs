using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraniteHouse.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name="Sales Person")]
        public string Name { get; set; }

        [NotMapped]
        public bool IsSuperAdmin {get; set;}
    }
}