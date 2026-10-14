using BookMark.Data.Data;
using BookMark.Data.Repositories.Interfaces;

namespace BookMark.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly BookMarkDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(BookMarkDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}