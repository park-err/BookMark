namespace BookMark.Data.Data
{
    public class BookMarkDbContext(DbContextOptions<BookMarkDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookMarkDbContext).Assembly);
        }
    }
}
