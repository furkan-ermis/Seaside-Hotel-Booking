namespace DestinyHaven.Entity
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string? Message { get; set; }
    }
}
