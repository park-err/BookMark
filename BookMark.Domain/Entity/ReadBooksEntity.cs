using System.ComponentModel.DataAnnotations.Schema;

namespace BookMark.Domain.Entity
{
    public class ReadBooksEntity
    {
        public string BookId { get; set; } = string.Empty;
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public required virtual UserEntity User { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; } = string.Empty;
        public DateTime FinishedAt { get; set; } = DateTime.UtcNow;
    }
}
