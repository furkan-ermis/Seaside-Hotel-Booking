using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.Security.Claims;

namespace DestinyHaven.Entity
{
    public class Contact
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser AppUser{ get; set; }
        [Required]
        public string Message { get; set; }
    }
}
