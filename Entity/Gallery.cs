using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.Security.Claims;

namespace DestinyHaven.Entity
{
    public class Gallery
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
        public string Description { get; set; }
    }
}
