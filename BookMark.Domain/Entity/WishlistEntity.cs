using System.ComponentModel.DataAnnotations.Schema;

namespace BookMark.Domain.Entity
{
    public class WishlistEntity
    {
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public required virtual UserEntity User { get; set; }
        public string WishlistName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<WishlistItemEntity> WishlistItems { get; set; } = new List<WishlistItemEntity>();
    }
}
