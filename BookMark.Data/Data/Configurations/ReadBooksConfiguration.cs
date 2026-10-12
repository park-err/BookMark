using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookMark.Data.Data.Configurations
{
    public class ReadBooksConfiguration : IEntityTypeConfiguration<ReadBooksEntity>
    {
        public void Configure(EntityTypeBuilder<ReadBooksEntity> builder)
        {
            builder.ToTable("ReadBooks", "Library");

            builder.HasKey(b => new { b.BookId, b.UserId });

            builder.HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.BookId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("NVARCHAR(50)");
            builder.Property(b => b.UserId)
                .IsRequired()
                .HasColumnType("BIGINT");
            builder.Property(b => b.Rating)
                .HasColumnType("INT");
            builder.Property(b => b.Comments)
                .HasMaxLength(255)
                .HasColumnType("NVARCHAR(255)");
            builder.Property(b => b.FinishedAt)
                .HasDefaultValueSql("GETDATE()")
                .HasColumnType("DATETIME");
            /*
             * BookId NVARCHAR(50) NOT NULL,		-- supplied by Google Book API
	UserId BIGINT NOT NULL FOREIGN KEY REFERENCES Admin.Users(Id) ON DELETE CASCADE,
	Rating INT CHECK (Rating BETWEEN 1 AND 10),
	Comments NVARCHAR(255) NULL,
	FinishedAt DATETIME DEFAULT GETDATE(),
	CONSTRAINT ReadBooks_PK PRIMARY KEY (BookId, UserId)
             */
        }
    }
}
