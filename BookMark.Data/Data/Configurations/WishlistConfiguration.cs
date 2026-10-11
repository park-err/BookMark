using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WishlistConfiguration : IEntityTypeConfiguration<WishlistEntity>
{
    public void Configure(EntityTypeBuilder<WishlistEntity> builder)
    {
        builder.ToTable("Wishlist", "Library");

        builder.HasKey(b => b.WishlistId);

        builder.HasOne(b => b.User)
            .WithMany()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(b => b.WishlistName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("NVARCHAR(50)");

        builder.Property(b => b.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .HasColumnType("DATETIME");

        /*
         * WishlistId BIGINT PRIMARY KEY CLUSTERED IDENTITY(99, 1),
	UserId BIGINT FOREIGN KEY REFERENCES Admin.Users(Id) ON DELETE CASCADE,
	WishlistName NVARCHAR(50) NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE()
         */
    }
}