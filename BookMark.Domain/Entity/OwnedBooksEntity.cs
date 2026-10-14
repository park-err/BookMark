using System.ComponentModel.DataAnnotations.Schema;

namespace BookMark.Domain.Entity
{
    public class OwnedBooksEntity
    {
        public string BookId { get; set; } = string.Empty;
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public required virtual UserEntity User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
