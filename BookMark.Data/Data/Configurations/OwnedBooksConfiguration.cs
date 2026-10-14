using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookMark.Data.Data.Configurations
{
    public class OwnedBooksConfiguration : IEntityTypeConfiguration<OwnedBooksEntity>
    {
        public void Configure(EntityTypeBuilder<OwnedBooksEntity> builder)
        {
            builder.ToTable("OwnedBooks", "Library");

            builder.HasKey(b => new { b.UserId, b.BookId });

            builder.HasOne(b => b.User)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.BookId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("NVARCHAR(50)");

            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .HasColumnType("DATETIME");

            /*
             * BookId NVARCHAR(50) NOT NULL,		-- supplied by Google Book API
	UserId BIGINT NOT NULL FOREIGN KEY REFERENCES Admin.Users(Id) ON DELETE CASCADE,
	CreatedAt DATETIME DEFAULT GETDATE(),
	CONSTRAINT OwnedBooks_PK PRIMARY KEY (BookId, UserId)
             */
        }
    }
}
