using System.ComponentModel.DataAnnotations.Schema;

namespace BookMark.Domain.Entity
{
    public class WishlistItemEntity
    {
        public int WishlistId { get; set; }
        [ForeignKey("WishlistId")]
        public required virtual WishlistEntity Wishlist { get; set; }
        public string BookId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
