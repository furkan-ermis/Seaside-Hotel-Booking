namespace DestinyHaven.Entity
{
    public class UserAddress
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        
    }
}
