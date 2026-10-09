using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WishlistConfiguration : IEntityTypeConfiguration<WishlistEntity>
{
    public void Configure(EntityTypeBuilder<WishlistEntity> builder)
    {
        builder.ToTable("Wishlists", "Library");

        builder.HasKey(b => b.WishlistId);
    }
}