namespace BookMark.Domain.Entity
{
    public class WishlistEntity
    {
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        public string WishlistName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
