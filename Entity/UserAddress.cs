namespace DestinyHaven.Entity
{
    public class UserAddress
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
