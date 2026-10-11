using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users", "Admin");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("BIGINT");
        builder.Property(b => b.UserName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("NVARCHAR(50)");
        builder.Property(b => b.PasswordHash)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("NVARCHAR(255)");
        builder.Property(b => b.DisplayName)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("NVARCHAR(255)");
        builder.Property(b => b.Email)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("NVARCHAR(255)");
        builder.Property(b => b.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .HasColumnType("DATETIME");
        builder.Property(b => b.ModifiedAt)
            .HasDefaultValueSql("GETDATE()")
            .HasColumnType("DATETIME");

        /*
         * Id BIGINT PRIMARY KEY CLUSTERED IDENTITY(999, 1),
	Username NVARCHAR(50) UNIQUE NOT NULL,
	PasswordHash NVARCHAR(255) NOT NULL,
	DisplayName NVARCHAR(255) NOT NULL,
	Email NVARCHAR(255) UNIQUE NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    ModifiedAt DATETIME DEFAULT GETDATE()
         */
    }
}