using BookMark.Data.Data;
using BookMark.Data.Repositories.Interfaces;

namespace BookMark.Data.Repositories
{
    public class WishlistItemRepository : BaseRepository<WishlistItemEntity>, IWishlistItemRepository
    {
        public WishlistItemRepository(BookMarkDbContext context) : base(context) { }

        public async Task<WishlistItemEntity?> GetWishlistItemByIdAsync(int wishlistId, string bookId, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(new object[] { wishlistId, bookId }, cancellationToken);
        }

        public async Task<IEnumerable<WishlistItemEntity>> GetAllWishlistItemsByIdAsync(int wishlistId, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(wi => wi.WishlistId == wishlistId).ToListAsync(cancellationToken);
        }

        public async Task AddWishlistItemAsync(WishlistItemEntity wishlistItem, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(wishlistItem, cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateWishlistItemAsync(WishlistItemEntity wishlistItem, CancellationToken cancellationToken)
        {
            _dbSet.Update(wishlistItem);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteWishlistItemAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync(cancellationToken);
            }
        }
    }
}
