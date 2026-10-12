using BookMark.Data.Data;
using BookMark.Data.Repositories.Interfaces;

namespace BookMark.Data.Repositories
{
    public class ReadBooksRepository : BaseRepository<ReadBooksEntity>, IReadBooksRepository
    {
        public ReadBooksRepository(BookMarkDbContext context) : base(context) { }

        public async Task<ReadBooksEntity?> GetReadBookByBookIdAsync(int userId, string bookId, CancellationToken cancellationToken)
        {
            // Composite key: userId + bookId
            return await _dbSet.FindAsync(new object[] { userId, bookId }, cancellationToken);
        }

        public async Task<IEnumerable<ReadBooksEntity>> GetAllReadBooksByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(rb => rb.UserId == userId).ToListAsync(cancellationToken);
        }

        public async Task AddReadBookAsync(ReadBooksEntity readBook, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(readBook, cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateReadBookAsync(ReadBooksEntity readBook, CancellationToken cancellationToken)
        {
            _dbSet.Update(readBook);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteReadBookAsync(int userId, string bookId, CancellationToken cancellationToken)
        {
            var entity = await GetReadBookByBookIdAsync(userId, bookId, cancellationToken);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync(cancellationToken);
            }
        }
    }
}
