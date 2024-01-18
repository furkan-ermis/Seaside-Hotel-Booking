using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DestinyHaven.Entity
{
    public class AppUser:IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public string? Role { get; set; }

        [NotMapped]
        public int? ConfirmCode { get; set; }
        
    }
}
