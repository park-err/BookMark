using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItemEntity>
{
    public void Configure(EntityTypeBuilder<WishlistItemEntity> builder)
    {
        builder.ToTable("WishlistItem", "Library");

        builder.HasKey(b => new { b.WishlistId, b.BookId });

        builder.Property(b => b.WishlistId)
            .IsRequired()
            .HasColumnType("BIGINT");
        builder.Property(b => b.BookId)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("NVARCHAR(50)");
        builder.Property(b => b.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .HasColumnType("DATETIME");


        builder.HasOne(b => b.Wishlist)
            .WithMany(w => w.WishlistItems)
            .HasForeignKey(b => b.WishlistId)
            .OnDelete(DeleteBehavior.Cascade);

        /*
         * WishlistId BIGINT NOT NULL FOREIGN KEY REFERENCES Library.Wishlist(WishlistId) ON DELETE CASCADE,
	BookId NVARCHAR(50) NOT NULL,		-- supplied by Google Book API
	CreatedAt DATETIME DEFAULT GETDATE(),
	CONSTRAINT WishlistItem_PK PRIMARY KEY (WishlistId, BookId)
         */

    }
}