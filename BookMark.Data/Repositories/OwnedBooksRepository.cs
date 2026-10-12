using BookMark.Data.Data;
using BookMark.Data.Repositories.Interfaces;

namespace BookMark.Data.Repositories
{
    public class OwnedBooksRepository : BaseRepository<OwnedBooksEntity>, IOwnedBooksRepository
    {
        public OwnedBooksRepository(BookMarkDbContext context) : base(context) { }

        public async Task<OwnedBooksEntity?> GetOwnedBookByIdAsync(int userId, string bookId, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(new object[] { userId, bookId }, cancellationToken);
        }

        public async Task<IEnumerable<OwnedBooksEntity>> GetOwnedBooksByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(ob => ob.UserId == userId).ToListAsync(cancellationToken);
        }

        public async Task AddOwnedBookAsync(OwnedBooksEntity ownedBook, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(ownedBook, cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateOwnedBookAsync(OwnedBooksEntity ownedBook, CancellationToken cancellationToken)
        {
            _dbSet.Update(ownedBook);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteOwnedBookAsync(int userId, string bookId, CancellationToken cancellationToken)
        {
            var entity = await GetOwnedBookByIdAsync(userId, bookId, cancellationToken);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync(cancellationToken);
            }
        }
    }
}
